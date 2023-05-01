using web1c_backend.Constants;
using web1c_backend.Models;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Params;

namespace web1c_backend.Services
{
    public class DebtorCardBuilderStrategy : IDataBuilderStrategy
    {
        public IQueryable<EntityWithRoute> BuildCollection(Web1cDBContext context, GetParams queryParams)
        {
            IQueryable<En_debtor_card> collection;

            if (queryParams.Key.Equals(""))
            {
                collection = context.DebtorCards
                    .Select(debtorCard => new En_debtor_card()
                    {
                        creation_date = debtorCard.creation_date,
                        debtor_card_id = debtorCard.debtor_card_id,
                        debtor_card_name = debtorCard.debtor_card_name,
                        debtor_id = debtorCard.debtor_id
                    });                   
            }
            else
            {
                collection = context.DebtorCards
                    .Where(debtorCard => debtorCard.debtor_card_id.ToString().Equals(queryParams.Key));               
            }

            return from debtorCard in collection

                   join counterparty in context.Counterparties
                   on  debtorCard.debtor_id equals counterparty.counterparty_id into joinCounterparties
                   from joinCounterparty in joinCounterparties.DefaultIfEmpty()

                   select new En_debtor_card(debtorCard)
                   {
                       DebtorName = joinCounterparty != null? joinCounterparty.counterparty_name : "",
                       Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"?Key={debtorCard.debtor_card_id}"
                   };
        }
    }
}
