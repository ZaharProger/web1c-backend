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
    public class DebtorCardController : ControllerBase
    {
        private readonly Web1cDBContext _context;

        public DebtorCardController(Web1cDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetDebtorCard([FromQuery] GetParams getCardParams)
        {
            En_debtor_card[]? foundData = Array.Empty<En_debtor_card>();
            foundData = await _context.Debtor_Cards
                .Where(cardRec => cardRec.debtor_card_id.ToString().Equals(getCardParams.Key))
                .Select(foundCard => new En_debtor_card()
                {
                    debtor_card_id = foundCard.debtor_card_id,
                    debtor_card_name = foundCard.debtor_card_name,
                    creation_date= foundCard.creation_date,
                    debtor_id = foundCard.debtor_id,
                    inn= foundCard.inn,
                    kpp= foundCard.kpp,
                    is_smp= foundCard.is_smp,
                    sanctions= foundCard.sanctions,
                    is_bankrupt= foundCard.is_bankrupt,
                    is_in_creditors_list = foundCard.is_in_creditors_list,
                    emergency_message_id= foundCard.emergency_message_id,
                })
                .ToArrayAsync();

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
