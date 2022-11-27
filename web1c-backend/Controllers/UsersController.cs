using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using web1c_backend.Models;
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

            if (getUsersParams.Type == 0)
            {
                response = await GetUserByLogin(getUsersParams.Key);
            }
            else if (getUsersParams.Type == 1)
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

            /*
            if(authParams.RequestType == 0)
            {
                var response = await AuthorizeUser(authParams, passwordEncryptor);
            }
            */

            var response = await AuthorizeUser(authParams, passwordEncryptor);

            return new JsonResult(response);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.En_user_id == id);
        }
    }
}
