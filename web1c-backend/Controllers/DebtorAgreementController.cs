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
    public class DebtorAgreementController : ControllerBase
    {
        private readonly Web1cDBContext _context;

        public DebtorAgreementController(Web1cDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetDebtorAgreement([FromQuery] GetParams getDebtorParams)
        {
            En_debtor_agreement[]? foundData = Array.Empty<En_debtor_agreement>();
            foundData = await _context.Debtor_Agreement
            .Where(debtor => debtor.debtor_id.ToString().Equals(getDebtorParams.Key))
            .Select(foundDebtor => new En_debtor_agreement()
            {
                debtor_id = foundDebtor.debtor_id,
                debtor_name = foundDebtor.debtor_name,
                base_id = foundDebtor.base_id,
                status_agreement = foundDebtor.status_agreement,
                date_agreement = foundDebtor.date_agreement,
                number_agreement = foundDebtor.number_agreement,
                currency_id = foundDebtor.currency_id,
                budget_id = foundDebtor.budget_id,
                turnover_id = foundDebtor.turnover_id,
                payment_id = foundDebtor.payment_id,
                comment = foundDebtor.comment,
                society_id = foundDebtor.society_id,
                business_id = foundDebtor.business_id,
                Market_view = foundDebtor.Market_view,
                counter_id = foundDebtor.counter_id,
                public_status = foundDebtor.public_status,
                typical_status = foundDebtor.typical_status,
                disabled_status = foundDebtor.disabled_status,
                responsible = foundDebtor.responsible,
            })
            .ToArrayAsync();


            var response = new DataResponse<En_debtor_agreement>()
            {
                Result = foundData.Length != 0,
                Message = "",
                Data = foundData
            };
            return new JsonResult(response);
        }


    }
}
