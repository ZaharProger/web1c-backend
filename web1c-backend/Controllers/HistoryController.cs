using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web1c_backend.Constants;
using web1c_backend.Models.Contexts;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Params;
using web1c_backend.Models.Http.Responses;
using web1c_backend.Services;

namespace web1c_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : Web1cController
    {
        public HistoryController(Web1cDBContext context) : base(context)
        { }

        [NonAction]
        public async Task<List<En_history>> GetHistory()
        {
            return await context.History
                .ToListAsync();
        }

        [NonAction]
        public async Task<En_user> GetUser()
        {
            return await context.Users
                .FirstAsync();
        }

        [HttpGet]
        public async Task<JsonResult> GetHistoryHandler([FromQuery] GetParams historyParams)
        {
            var sessionId = CheckSession(ConstValues.SESSION_ID);

            EntityWithRoute[]? foundData = null;
            if (sessionId != null)
            {
                var foundSession = await context.Sessions.FindAsync(sessionId);
                var historyArray = await GetUserHistory(foundSession.En_user_id);
                foundData = await MapHistoryToEntities(historyArray, historyParams);
            }

            var response = new DataResponse<EntityWithRoute>()
            {
                Result = foundData != null && foundData.Length != 0,
                Message = foundData != null ? "" : ConstValues.SESSION_NOT_FOUND,
                Data = foundData
            };

            return new JsonResult(response);
        }

        [NonAction]
        public async Task<En_history[]> GetUserHistory(long? userId)
        {
            return await context.History
                .Where(history => history.user_id == userId)
                .ToArrayAsync();
        }

        [NonAction]
        public async Task<EntityWithRoute[]> MapHistoryToEntities(En_history[] historyArray, GetParams historyParams)
        {
            var foundData = new EntityWithRoute[historyArray.Length];
            var dataBuilder = new DataBuilder();

            for (int i = 0; i < historyArray.Length; ++i)
            {
                historyParams.Key = historyArray[i].entity_id.ToString();

                var foundItem = await dataBuilder
                    .BuildFromCache(context, new DebtorCardBuilderStrategy(), historyParams);
                foundData[i] = foundItem.First();
            }

            return foundData;
        }
    }
}
