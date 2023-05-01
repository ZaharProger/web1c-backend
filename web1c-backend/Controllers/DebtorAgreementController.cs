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
    [Route("api/docs/debtor-contracts")]
    [ApiController]
    public class DebtorAgreementController : ControllerBase
    {
        private readonly Web1cDBContext _context;

        public DebtorAgreementController(Web1cDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetDebtorAgreements([FromQuery] GetParams getDebtorAgreementParams)
        {
            En_debtor_agreement[]? foundData = Array.Empty<En_debtor_agreement>();
            if (getDebtorAgreementParams.Key.Equals(""))
            {
                foundData = await _context.Debtor_Agreement
                    .Select(debtorAgreement => new En_debtor_agreement()
                    {
                        date_agreement = debtorAgreement.date_agreement,
                        debtor_id = debtorAgreement.debtor_id,                     
                        debtor_name = debtorAgreement.debtor_name,
                        base_id = debtorAgreement.base_id
                    })
                    .ToArrayAsync();
            }
            else
            {
                foundData = await _context.Debtor_Agreement
                    .Where(debtorAgreement => debtorAgreement.debtor_id.ToString().Equals(getDebtorAgreementParams.Key))
                    .ToArrayAsync();
            }

            foreach (var item in foundData)
            {
                item.Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.DEBTOR_CONTRACTS]}?Key={item.debtor_id}";
            }

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
