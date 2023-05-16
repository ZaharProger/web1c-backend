using web1c_backend.Constants;
using web1c_backend.Models;
using web1c_backend.Models.Entities;

namespace web1c_backend.Services
{
    public class DebtorCardBuilderStrategy : ICachedDataBuilderStrategy
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
                           $"/{debtorCard.debtor_card_id}"
                   };
        }

        public IQueryable<EntityWithRoute> BuildEntityFromHistory(Web1cDBContext context, long entityKey)
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
                           $"/{debtorCard.debtor_card_id}"
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
                           $"/{debtorCard.debtor_card_id}"
                   };
        }

        public List<EntityWithRoute> BuildFromResponse(long entityKey)
        {
            var data = new List<EntityWithRoute>();

            for (int i = 0; i < 10; ++i)
            {
                if (i == 0)
                {
                    data.Add(new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = entityKey,
                        debtor_card_name = "Должник 1",
                        debtor = "Контрагент 1",
                        DebtorPaymentArrears = 43800.0D,
                        Inn = "123456789",
                        Kpp = "123456",
                        IsSmp = true,
                        Sanctions = "",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{entityKey}"
                    });
                }
                else if (i > 0 && i < 8)
                {
                    data.Add(new En_debtor_agreement
                    {
                        DebtorId = i,
                        DebtorName = "Должник 1",
                        BaseName = "Договор контрагента 1",
                        DateAgreement = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTOR_CONTRACTS]}" +
                           $"/{i}"
                    });
                }
                else
                {
                    data.Add(new En_event_record
                    {
                        EventRecordId = i,
                        CreationDate = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        EventName = "Запись события 1",
                        Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.EVENTS]}" +
                           $"/{i}"
                    });
                }
            }

            return data;
        }
    }
}
