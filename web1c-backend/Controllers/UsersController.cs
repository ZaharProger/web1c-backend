using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web1c_backend.Models;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Responses;
using web1c_backend.Models.Http.Params;

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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<En_user>> PostUser(En_user user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.En_user_id }, user);
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
