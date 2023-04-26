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
    [Route("api/docs/events")]
    [ApiController]
    public class EventRecordController : ControllerBase
    {
        private readonly Web1cDBContext _context;

        public EventRecordController(Web1cDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetEventRecords([FromQuery] GetParams getEventParams)
        {
            En_event_record[]? foundData = Array.Empty<En_event_record>();
            if (getEventParams.Type == -1)
            {
                foundData = await _context.Events
                    .Select(eventRecord => new En_event_record()
                    {                        
                        creation_date = eventRecord.creation_date,                     
                        event_record_id = eventRecord.event_record_id,
                        base_document_id = eventRecord.base_document_id,
                        responsible_user = eventRecord.responsible_user
                    })
                    .ToArrayAsync();
            }
            else
            {
                foundData = await _context.Events
                    .Where(eventRec => eventRec.event_record_id.ToString().Equals(getEventParams.Key))
                    .ToArrayAsync();
            }

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
