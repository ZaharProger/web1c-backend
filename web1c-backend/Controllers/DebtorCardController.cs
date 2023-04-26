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
    [Route("api/classes/debtors")]
    [ApiController]
    public class DebtorCardController : ControllerBase
    {
        private readonly Web1cDBContext _context;

        public DebtorCardController(Web1cDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetDebtorCards([FromQuery] GetParams getDebtorCardParams)
        {
            En_debtor_card[]? foundData = Array.Empty<En_debtor_card>();
            if (getDebtorCardParams.Type == -1)
            {
                foundData = await _context.Debtor_Cards
                    .Select(debtorCard=> new En_debtor_card()
                    {
                        creation_date = debtorCard.creation_date,
                        debtor_card_id = debtorCard.debtor_card_id,                      
                        debtor_card_name = debtorCard.debtor_card_name,
                        debtor_id = debtorCard.debtor_id
                    })
                    .ToArrayAsync();
            }
            else
            {
                foundData = await _context.Debtor_Cards
                    .Where(debtorCard => debtorCard.debtor_card_id.ToString().Equals(getDebtorCardParams.Key))
                    .ToArrayAsync();
            }

            var response = new DataResponse<En_debtor_card>()
            {
                Result = foundData.Length != 0,
                Message = "",
                Data = foundData
            };

            return new JsonResult(response);
        }

    }
}
