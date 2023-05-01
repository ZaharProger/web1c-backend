using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using web1c_backend.Models;
using web1c_backend.Constants;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Responses;
using web1c_backend.Models.Http.Params;
using System.Text;

namespace web1c_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Web1cController
    {
        public UsersController(Web1cDBContext context) : base(context)
        { }

        //0 - by login
        //1- by id
        //2- by SessionId
        [HttpGet]
        public async Task<JsonResult> GetUsersHandler([FromQuery] GetParams getUsersParams)
        {
            var sessionId = CheckSession(ConstValues.SESSION_ID);

            var response = new DataResponse<En_user>()
            {
                Result = false,
                Message = ConstValues.TYPE_FAILURE,
                Data = Array.Empty<En_user>()
            };

            if (getUsersParams.Type == ConstValues.LOGIN_TYPE)
            {
                response = await GetUserByLogin(getUsersParams.Key);
            }
            else if (getUsersParams.Type == ConstValues.ID_TYPE)
            {
                response = await GetUserById(long.Parse(getUsersParams.Key));
            }
            else if (getUsersParams.Type == ConstValues.SESSION_TYPE)
            {
                response = await GetUserBySessionId(sessionId);
            }

            return new JsonResult(response);
        }

        private async Task<DataResponse<En_user>> GetUserByLogin(string userLogin)
        {
            En_user[]? foundData = Array.Empty<En_user>();

            foundData = await context.Users
                .Where(user => user.En_user_login.Equals(userLogin))
                .Select(foundUser => new En_user()
                {
                    En_user_id = foundUser.En_user_id,
                    En_user_login = foundUser.En_user_login,
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

            foundData = await context.Users
                .Where(user => user.En_user_id.Equals(id))
                .Select(foundUser => new En_user()
                {
                    En_user_id = foundUser.En_user_id,
                    En_user_login = foundUser.En_user_login,
                })
                .ToArrayAsync();

            return new DataResponse<En_user>()
            {
                Result = foundData.Length != 0,
                Message = "",
                Data = foundData
            };
        }

        private async Task<DataResponse<En_user>> GetUserBySessionId(long? sessionId)
        {
            En_user[]? foundData = Array.Empty<En_user>();

            if(sessionId != null)
            {
                foundData = await context.Sessions
                .Where(session => session.En_session_id == sessionId)
                .Join(context.Users, session => session.En_user_id, user => user.En_user_id, (session, user) => new
                {
                    sessionId = session.En_session_id,
                    userData = new En_user()
                    {
                        En_user_id = user.En_user_id,
                        En_user_login = user.En_user_login,
                    }
                })
                .Select(foundItem => foundItem.userData)
                .ToArrayAsync();
            }
            
            return new DataResponse<En_user>()
            {
                Result = foundData.Length != 0,
                Message = "",
                Data = foundData
            };
        }

        // POST: /Users
        //0 - autorize
        //1 - registration
        [HttpPost]
        public async Task<IActionResult> AuthHandler([FromForm] AuthParams authParams)
        {
            var passwordEncryptor = SHA256.Create();
            var response = new PostResponse()
            {
                Result = false,
                Message = ConstValues.TYPE_FAILURE,
                IncorrectFieldType = ConstValues.EMPTY_STRING,
            };

            if (authParams.RequestType == ConstValues.AUTH_TYPE)
            {
                response = await AuthorizeUser(authParams, passwordEncryptor);
            }
            else if (authParams.RequestType == ConstValues.REG_TYPE)
            {
                response = await RegisterUser(authParams, passwordEncryptor);
            }

            return new JsonResult(response);
        }

        private async Task<PostResponse> RegisterUser(AuthParams authParams, SHA256? passwordEncryptor)
        {
            var isUserExist = await context.Users
                .AnyAsync(user => user.En_user_login.Equals(authParams.Login));
            var incorrectFieldType = ConstValues.L_FIELD_TYPE;

            if (!isUserExist)
            {
                incorrectFieldType = ConstValues.EMPTY_STRING;
                var passwordByteArray = Encoding.UTF8.GetBytes(authParams.Password);
                var hashedPassword = passwordEncryptor.ComputeHash(passwordByteArray);

                await context.Users.AddAsync(new En_user()
                {
                    En_user_login = authParams.Login,
                    En_user_password = hashedPassword
                });
                await context.SaveChangesAsync();
            }

            return new PostResponse()
            {
                Result = !isUserExist,
                Message = !isUserExist ? ConstValues.REG_SUCCESS : ConstValues.REG_FAILED,
                IncorrectFieldType = incorrectFieldType,
            };
        }

        private async Task<PostResponse> AuthorizeUser(AuthParams authParams, SHA256? passwordEncryptor)
        {
            var foundUser = await context.Users
                .Where(user => user.En_user_login.Equals(authParams.Login))
                .ToArrayAsync();

            var passwordByteArray = Encoding.UTF8.GetBytes(authParams.Password);
            var hashedPassword = passwordEncryptor.ComputeHash(passwordByteArray);

            var messageForClient = ConstValues.AUTH_W_LOGIN;
            var incorrectFieldType = ConstValues.L_FIELD_TYPE;
            var sessionId = -1L;

            if (foundUser.Length != 0)
            {
                if (foundUser[0].En_user_password.SequenceEqual(hashedPassword))
                {
                    incorrectFieldType = ConstValues.EMPTY_STRING;
                    messageForClient = ConstValues.AUTH_SUCCESS;
                    sessionId = (long)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

                    await context.Sessions.AddAsync(new En_session()
                    {
                        En_session_id = sessionId,
                        En_user_id = foundUser[0].En_user_id
                    });
                    await context.SaveChangesAsync();

                    HttpContext.Response.Cookies.Append(ConstValues.SESSION_ID, sessionId.ToString(), new CookieOptions()
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
                    messageForClient = ConstValues.AUTH_W_PASS;
                    incorrectFieldType = ConstValues.P_FIELD_TYPE;
                }
            }


            return new PostResponse()
            {
                Result = messageForClient == ConstValues.AUTH_SUCCESS,
                Message = messageForClient,
                IncorrectFieldType = incorrectFieldType,
            };
        }



        // DELETE: api/Users/5
        [HttpDelete]
        public async Task<JsonResult> Delete()
        {
            En_session? sessionToRemove;
            var sessionId = CheckSession(ConstValues.SESSION_ID);
            try
            {
                sessionToRemove = await context.Sessions
                    .FirstAsync(session => session.En_session_id == sessionId);
            }
            catch (Exception)
            {
                sessionToRemove = null;
            }

            if (sessionToRemove != null)
            {
                HttpContext.Response.Cookies.Delete(ConstValues.SESSION_ID);

                context.Sessions.Remove(sessionToRemove);
                await context.SaveChangesAsync();
            }

            return new JsonResult(new BaseResponse()
            {
                Result = sessionToRemove != null,
                Message = sessionToRemove != null ? ConstValues.SESSION_REMOVED : ConstValues.SESSION_NOT_FOUND
            });
        }
    }
}
