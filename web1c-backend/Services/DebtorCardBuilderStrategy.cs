using web1c_backend.Constants;
using web1c_backend.Models;
using web1c_backend.Models.Entities;

namespace web1c_backend.Services
{
    public class DebtorCardBuilderStrategy : IDataBuilderStrategy
    {
        public IQueryable<EntityWithRoute> BuildCollection(Web1cDBContext context)
        {
            return from debtorCard in context.DebtorCards

                   join counterparty in context.Counterparties
                   on debtorCard.debtor_id equals counterparty.counterparty_id into joinCounterparties
                   from joinCounterparty in joinCounterparties.DefaultIfEmpty()

                   select new En_debtor_card(debtorCard)
                   {
                       creation_date = debtorCard.creation_date,
                       debtor_card_id = debtorCard.debtor_card_id,
                       debtor_card_name = debtorCard.debtor_card_name,
                       debtor_id = debtorCard.debtor_id,
                       DebtorName = joinCounterparty != null ? joinCounterparty.counterparty_name : "",
                       Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"?Key={debtorCard.debtor_card_id}"
                   };
        }

        public IQueryable<EntityWithRoute> BuildFullEntity(Web1cDBContext context, long entityKey)
        {
            return from debtorCard in context.DebtorCards

                   where debtorCard.debtor_card_id == entityKey

                   join counterparty in context.Counterparties
                   on debtorCard.debtor_id equals counterparty.counterparty_id into joinCounterparties
                   from joinCounterparty in joinCounterparties.DefaultIfEmpty()

                   select new En_debtor_card(debtorCard)
                   {
                       DebtorName = joinCounterparty != null ? joinCounterparty.counterparty_name : "",
                       Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"?Key={debtorCard.debtor_card_id}"
                   };
        }

        IQueryable<EntityWithRoute> IDataBuilderStrategy.BuildEntityFromHistory(Web1cDBContext context, long entityKey)
        {
            return from debtorCard in context.DebtorCards

                   where debtorCard.debtor_card_id == entityKey

                   join counterparty in context.Counterparties
                   on debtorCard.debtor_id equals counterparty.counterparty_id into joinCounterparties
                   from joinCounterparty in joinCounterparties.DefaultIfEmpty()

                   select new En_debtor_card(debtorCard)
                   {
                       creation_date = debtorCard.creation_date,
                       debtor_card_id = debtorCard.debtor_card_id,
                       debtor_card_name = debtorCard.debtor_card_name,
                       debtor_id = debtorCard.debtor_id,
                       DebtorName = joinCounterparty != null ? joinCounterparty.counterparty_name : "",
                       Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"?Key={debtorCard.debtor_card_id}"
                   };
        }

        public IQueryable<EntityWithRoute> BuildCollectionByKey(Web1cDBContext context, string searchKey)
        {

            return from debtorCard in context.DebtorCards

                   join counterparty in context.Counterparties
                   on debtorCard.debtor_id equals counterparty.counterparty_id into joinCounterparties
                   from joinCounterparty in joinCounterparties.DefaultIfEmpty()

                   where (
                       debtorCard.debtor_card_name.Contains(searchKey) ||
                       debtorCard.inn.Contains(searchKey) ||
                       debtorCard.kpp.Contains(searchKey) ||
                       debtorCard.sanctions.Contains(searchKey) ||
                       joinCounterparty.counterparty_name.Contains(searchKey)
                   )

                   select new En_debtor_card(debtorCard)
                   {
                       creation_date = debtorCard.creation_date,
                       debtor_card_id = debtorCard.debtor_card_id,
                       debtor_card_name = debtorCard.debtor_card_name,
                       debtor_id = debtorCard.debtor_id,
                       DebtorName = joinCounterparty != null ? joinCounterparty.counterparty_name : "",
                       Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"?Key={debtorCard.debtor_card_id}"
                   };
        }
    }
}
