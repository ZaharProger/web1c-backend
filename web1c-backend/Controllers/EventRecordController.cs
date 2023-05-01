using Microsoft.AspNetCore.Mvc;
using web1c_backend.Models;
using web1c_backend.Constants;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Responses;
using web1c_backend.Models.Http.Params;
using web1c_backend.Services;
using System.Text.Json;
using System.Runtime.Serialization.Json;

namespace web1c_backend.Controllers
{
    [Route("api/docs/events")]
    [ApiController]
    public class EventRecordController : Web1cController
    {
        public EventRecordController(Web1cDBContext context): base(context)
        { }

        [HttpGet]
        public async Task<JsonResult> GetEventRecords([FromQuery] GetParams getEventParams)
        {
            var sessionId = CheckSession(ConstValues.SESSION_ID);

            var foundData = sessionId == null ?
                null
                :
                await new DataBuilder(context).BuildCollection(new EventRecordBuilderStrategy(), getEventParams);

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
