using Microsoft.AspNetCore.Mvc;
using web1c_backend.Constants;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Params;
using web1c_backend.Models.Http.Responses;
using web1c_backend.Models;
using web1c_backend.Services;

namespace web1c_backend.Controllers
{
    [Route("api/classes/debtor-contracts")]
    [ApiController]
    public class DebtorAgreementController : Web1cController
    {
        public DebtorAgreementController(Web1cDBContext context) : base(context)
        { }

        [HttpGet]
        public async Task<JsonResult> GetDebtorAgreementHandler([FromQuery] GetParams getDebtorAgreementParams)
        {
            var sessionId = CheckSession(ConstValues.SESSION_ID);

            EntityWithRoute[]? foundData = null;
            if (sessionId != null)
            {
                foundData = new DataBuilder()
                    .BuildFromResponse(new DebtorAgreementBuilderStrategy(), getDebtorAgreementParams);
            }

            var response = new NestedDataResponse<EntityWithRoute>()
            {
                Result = foundData != null && foundData.Length != 0,
                Message = foundData != null ? "" : ConstValues.SESSION_NOT_FOUND,
                Data = getDebtorAgreementParams.Type != 4?
                    foundData
                    :
                    foundData != null && foundData.Length != 0 && getDebtorAgreementParams.Type == 4?
                    foundData
                        .Take(1)
                        .ToArray()
                    :
                    foundData,
                RelatedEvents = foundData != null ?
                    foundData
                        .Where(foundItem => foundItem is En_event_record)
                        .ToArray()
                    :
                    Array.Empty<En_event_record>(),
                RelatedAgreements = Array.Empty<En_debtor_agreement>()
            };

            return new JsonResult(response);
        }


    }
}
