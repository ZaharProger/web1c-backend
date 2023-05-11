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

                   select new En_debtor_card(debtorCard)
                   {
                       creation_date = debtorCard.creation_date,
                       debtor_card_id = debtorCard.debtor_card_id,
                       debtor_card_name = debtorCard.debtor_card_name,
                       debtor = debtorCard.debtor,
                       Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"?Key={debtorCard.debtor_card_id}"
                   };
        }

        IQueryable<EntityWithRoute> IDataBuilderStrategy.BuildEntity(Web1cDBContext context, long entityKey)
        {
            return from debtorCard in context.DebtorCards

                   where debtorCard.debtor_card_id == entityKey

                   select new En_debtor_card(debtorCard)
                   {
                       creation_date = debtorCard.creation_date,
                       debtor_card_id = debtorCard.debtor_card_id,
                       debtor_card_name = debtorCard.debtor_card_name,
                       debtor = debtorCard.debtor,
                       Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"?Key={debtorCard.debtor_card_id}"
                   };
        }

        public IQueryable<EntityWithRoute> BuildCollectionByKey(Web1cDBContext context, string searchKey)
        {

            return from debtorCard in context.DebtorCards

                   where (
                       debtorCard.debtor_card_id.ToString().Equals(searchKey) ||
                       debtorCard.debtor_card_name.Contains(searchKey) ||
                       debtorCard.debtor.Contains(searchKey)
                   )

                   select new En_debtor_card(debtorCard)
                   {
                       creation_date = debtorCard.creation_date,
                       debtor_card_id = debtorCard.debtor_card_id,
                       debtor_card_name = debtorCard.debtor_card_name,
                       debtor = debtorCard.debtor,
                       Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"?Key={debtorCard.debtor_card_id}"
                   };
        }
    }
}
