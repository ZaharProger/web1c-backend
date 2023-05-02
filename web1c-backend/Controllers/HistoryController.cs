using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web1c_backend.Constants;
using web1c_backend.Models;
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

        [HttpGet]
        public async Task<JsonResult> GetHistoryHandler([FromQuery] GetParams historyParams)
        {
            var sessionId = CheckSession(ConstValues.SESSION_ID);

            EntityWithRoute[]? foundData = null;
            if (sessionId != null)
            {
                var foundSession = await context.Sessions.FindAsync(sessionId);

                var historyArray = await context.History
                    .Where(history => history.user_id == foundSession.En_user_id)
                    .ToArrayAsync();

                foundData = new EntityWithRoute[historyArray.Length];
                var dataBuilder = new DataBuilder(context);

                for (int i = 0; i < historyArray.Length; ++i)
                {
                    historyParams.Key = historyArray[i].entity_id.ToString();

                    IDataBuilderStrategy strategy = historyArray[i].entity_type_id switch
                    {
                        (byte) EntityTypes.DEBTOR_CARD => strategy = new DebtorCardBuilderStrategy(),
                        (byte) EntityTypes.DEBTOR_AGREEMENT => strategy = new DebtorAgreementBuilderStrategy(),
                        _ => strategy = new EventRecordBuilderStrategy()
                    };

                    var foundItem = await dataBuilder.Build(strategy, historyParams);
                    foundData[i] = foundItem.First();
                }
            }

            var response = new DataResponse<EntityWithRoute>()
            {
                Result = foundData != null && foundData.Length != 0,
                Message = foundData != null ? "" : ConstValues.SESSION_NOT_FOUND,
                Data = foundData
            };

            return new JsonResult(response);
        }
    }
}
