using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using web1c_backend.Models;
using web1c_backend.Constants;
using web1c_backend.Constants.ConstValues;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Responses;
using web1c_backend.Models.Http.Params;
using static System.Collections.Specialized.BitVector32;
using System.Text;

namespace web1c_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Web1cDBContext _context;

        public UsersController(Web1cDBContext context)
        {
            this._context = context;
        }

        //0 - by login
        //1- by id
        [HttpGet]
        public async Task<JsonResult> GetUsersHandler([FromQuery] GetParams getUsersParams)
        {
            var response = new DataResponse<En_user>()
            {
                Result = false,
                Message = ":(",
                Data = Array.Empty<En_user>()
            };

            if (getUsersParams.Type == AUTH_TYPE)
            {
                response = await GetUserByLogin(getUsersParams.Key);
            }
            else if (getUsersParams.Type == REG_TYPE)
            {
                response = await GetUserById(long.Parse(getUsersParams.Key));
            }

            return new JsonResult(response);
        }

        private async Task<DataResponse<En_user>> GetUserByLogin(string userLogin)
        {
            En_user[]? foundData = Array.Empty<En_user>();

            foundData = await _context.Users
                .Where(user => user.En_user_login.Equals(userLogin))
                .Select(foundUser => new En_user()
                {
                    En_user_id = foundUser.En_user_id,
                    En_user_login = foundUser.En_user_login,
                    En_user_password = foundUser.En_user_password
                })
                .ToArrayAsync();

            return new DataResponse<En_user>()
            {
                Result = foundData.Length != 0,
                Message = "",
                Data = foundData
            };
        }
        
        private async Task<DataResponse<En_user>> GetUserById(long id)
        {
            En_user[]? foundData = Array.Empty<En_user>();

            foundData = await _context.Users
                .Where(user => user.En_user_id.Equals(id))
                .Select(foundUser => new En_user()
                {
                    En_user_id = foundUser.En_user_id,
                    En_user_login = foundUser.En_user_login,
                    En_user_password = foundUser.En_user_password
                })
                .ToArrayAsync();

            return new DataResponse<En_user>()
            {
                Result = foundData.Length != 0,
                Message = "",
                Data = foundData
            };
        }

        // POST: /Users
        [HttpPost]
        public async Task<IActionResult> AuthHandler([FromForm] AuthParams authParams)
        {
            var passwordEncryptor = SHA256.Create();
            BaseResponse response;

            if (authParams.RequestType == 0)
            {
                response = await AuthorizeUser(authParams, passwordEncryptor);
            }
            //else if (authParams.RequestType == 1)
            else
            {
                response = await RegisterUser(authParams, passwordEncryptor);
            }

            return new JsonResult(response);
        }

        private async Task<BaseResponse> RegisterUser(AuthParams authParams, SHA256? passwordEncryptor)
        {
            var isUserExist = await _context.Users
                .AnyAsync(user => user.En_user_login.Equals(authParams.Login));

            if (!isUserExist)
            {
                var passwordByteArray = Encoding.UTF8.GetBytes(authParams.Password);
                var hashedPassword = passwordEncryptor.ComputeHash(passwordByteArray);

                await _context.Users.AddAsync(new En_user()
                {
                    En_user_login = authParams.Login,
                    En_user_password = hashedPassword
                });
                await _context.SaveChangesAsync();
            }

            return new BaseResponse()
            {
                Result = !isUserExist,
                Message = !isUserExist ? "Вы успешно зарегистрировались!" : "Пользователь с введеным логином уже существует!"
            };
        }

        private async Task<BaseResponse> AuthorizeUser(AuthParams authParams, SHA256? passwordEncryptor)
        {
            var foundUser = await _context.Users
                .Where(user => user.En_user_login.Equals(authParams.Login))
                .ToArrayAsync();

            var passwordByteArray = Encoding.UTF8.GetBytes(authParams.Password);
            var hashedPassword = passwordEncryptor.ComputeHash(passwordByteArray);

            var messageForClient = "Wrong Password";
            var incorrectFieldType = "login";
            var sessionId = -1L;

            if (foundUser.Length != 0)
            {
                if (foundUser[0].En_user_password.SequenceEqual(hashedPassword))
                {
                    messageForClient = "auth success";
                    sessionId = (long)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

                    await _context.Sessions.AddAsync(new En_session()
                    {
                        En_session_id = sessionId,
                        En_user_id = foundUser[0].En_user_id
                    });
                    await _context.SaveChangesAsync();

                    HttpContext.Response.Cookies.Append("session_id", sessionId.ToString(), new CookieOptions()
                    {
                        Path = "/",
                        Secure = true,
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTimeOffset.Now.AddDays(7)
                    });
                }
                else
                {
                    messageForClient = "Wrong Password";
                    incorrectFieldType = "login";
                }
            }

            return new BaseResponse()
            {
                Result = messageForClient == "auth success",
                Message = messageForClient
            };
        }



        // DELETE: api/Users/5
        [HttpDelete]
        public async Task<JsonResult> Delete()
        {
            En_session? sessionToRemove = null;
            var sessionId = CheckSession("session_id");
            try
            {
                sessionToRemove = await _context.Sessions
                    .FirstAsync(session => session.En_session_id == sessionId);
            }
            catch (Exception)
            { }

            if (sessionToRemove != null)
            {
                HttpContext.Response.Cookies.Delete("session_id");

                _context.Sessions.Remove(sessionToRemove);
                await _context.SaveChangesAsync();
            }

            return new JsonResult(new BaseResponse()
            {
                Result = sessionToRemove != null,
                Message = sessionToRemove != null ? "Session was delete" : "Session not found"
            });
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.En_user_id == id);
        }

        private long? CheckSession(string cookieKey)
        {
            long? sessionId = null;
            if (HttpContext.Request.Cookies[cookieKey] != null)
            {
                try
                {
                    sessionId = long.Parse(HttpContext.Request.Cookies[cookieKey]);
                }
                catch (FormatException)
                { }
            }

            return sessionId;
        }
    }
}
