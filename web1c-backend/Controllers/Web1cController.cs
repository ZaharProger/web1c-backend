using Microsoft.AspNetCore.Mvc;
using web1c_backend.Models;
using web1c_backend.Services;

namespace web1c_backend.Controllers
{
    public class Web1cController : ControllerBase
    {
        protected Web1cDBContext context;

        public Web1cController(Web1cDBContext context)
        {
            this.context = context;
        }

        protected long? CheckSession(string cookieKey)
        {
            long? sessionId;
            if (HttpContext.Request.Cookies[cookieKey] != null)
            {
                try
                {
                    sessionId = long.Parse(HttpContext.Request.Cookies[cookieKey]);
                }
                catch (FormatException)
                {
                    sessionId = null;
                }
            }
            else
            {
                sessionId = null;
            }

            return sessionId;
        }
    }
}
