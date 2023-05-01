using Microsoft.AspNetCore.Mvc;
using web1c_backend.Models;
using web1c_backend.Constants;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Responses;
using web1c_backend.Models.Http.Params;
using web1c_backend.Services;

namespace web1c_backend.Controllers
{
    [Route("api/docs/debtor-contracts")]
    [ApiController]
    public class DebtorAgreementController : Web1cController
    {
        public DebtorAgreementController(Web1cDBContext context) : base(context)
        { }

        [HttpGet]
        public async Task<JsonResult> GetDebtorAgreements([FromQuery] GetParams getDebtorAgreementParams)
        {
            var sessionId = CheckSession(ConstValues.SESSION_ID);

            var foundData = sessionId == null ? 
                null
                :
                await new DataBuilder(context).BuildCollection(new DebtorAgreementBuilderStrategy(), getDebtorAgreementParams);

            var response = new DataResponse<EntityWithRoute>()
            {
                Result = foundData != null && foundData.Length != 0,
                Message = foundData != null? "" : ConstValues.SESSION_NOT_FOUND,
                Data = foundData
            };

            return new JsonResult(response);
        }


    }
}
