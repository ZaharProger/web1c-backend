using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using web1c_backend.Models;
using web1c_backend.Constants;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Responses;
using web1c_backend.Models.Http.Params;
using static System.Collections.Specialized.BitVector32;
using System.Text;

namespace web1c_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRecordController : ControllerBase
    {
        private readonly Web1cDBContext _context;

        public EventRecordController(Web1cDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetEventRecord([FromQuery] GetParams getEventParams)
        {
            En_event_record[]? foundData = Array.Empty<En_event_record>();
            foundData = await _context.Events
                .Where(eventRec => eventRec.event_record_id.ToString().Equals(getEventParams.Key))
                .Select(foundEvent => new En_event_record()
                {
                    event_record_id= foundEvent.event_record_id,
                    creation_date= foundEvent.creation_date,
                    send_date= foundEvent.send_date,
                    exp_execution_date= foundEvent.exp_execution_date,
                    executon_date= foundEvent.executon_date,
                    base_document_id= foundEvent.base_document_id,
                    work_type_id= foundEvent.work_type_id,
                    debtor_card_id = foundEvent.debtor_card_id,
                    company_id= foundEvent.company_id,
                    business_id= foundEvent.business_id,
                    event_description= foundEvent.event_description,
                    event_comment= foundEvent.event_comment,
                    responsible_user= foundEvent.responsible_user,
                })
                .ToArrayAsync();

            var response = new DataResponse<En_event_record>()
            {
                Result = foundData.Length != 0,
                Message = "",
                Data = foundData
            };

            return new JsonResult(response);
        }

    }
}
