using Microsoft.AspNetCore.Mvc;
using web1c_backend.Constants;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Responses;
using web1c_backend.Models.Http.Params;
using web1c_backend.Services;
using web1c_backend.Models.Contexts;

namespace web1c_backend.Controllers
{
    [Route("api/classes/debtors")]
    [ApiController]
    public class DebtorCardController : Web1cController
    {
        public DebtorCardController(Web1cDBContext context) : base(context)
        { }

        [HttpGet]
        public async Task<JsonResult> GetDebtorCards([FromQuery] GetParams getDebtorCardParams)
        {
            var sessionId = CheckSession(ConstValues.SESSION_ID);

            EntityWithRoute[]? foundData = null;
            if (sessionId != null)
            {
                var builder = new DataBuilder();
                var strategy = new DebtorCardBuilderStrategy();

                if (getDebtorCardParams.Type == 4)
                {
                    foundData = builder.BuildFromResponse(strategy, getDebtorCardParams);

                    if (foundData.Length != 0)
                    {
                        var foundSession = await context.Sessions.FindAsync(sessionId);
                        await UpdateHistory(foundData.First(), foundSession.En_user_id);
                    }                   
                }
                else
                {
                    foundData = await builder
                        .BuildFromCache(context, strategy, getDebtorCardParams);
                }
            }

            var response = new NestedDataResponse<EntityWithRoute>()
            {
                Result = foundData != null && foundData.Length != 0,
                Message = foundData != null ? "" : ConstValues.SESSION_NOT_FOUND,
                Data = getDebtorCardParams.Type != 4?                 
                    foundData
                    :
                    foundData != null && foundData.Length != 0 && getDebtorCardParams.Type == 4?
                    foundData
                        .Take(1)
                        .ToArray()
                    :
                    foundData,
                RelatedEvents = foundData != null? 
                    foundData
                        .Where(foundItem => foundItem is En_event_record)
                        .ToArray() 
                    : 
                    Array.Empty<En_event_record>(),
                RelatedAgreements = foundData != null ?
                    foundData
                        .Where(foundItem => foundItem is En_debtor_agreement)
                        .ToArray()
                    :
                    Array.Empty<En_debtor_agreement>(),
            };

            return new JsonResult(response);
        }

    }
}
