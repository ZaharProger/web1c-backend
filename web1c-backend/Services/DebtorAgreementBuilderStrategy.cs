using web1c_backend.Constants;
using web1c_backend.Models.Entities;

namespace web1c_backend.Services
{
    public class DebtorAgreementBuilderStrategy : IDataBuilderStrategy
    {
        public List<EntityWithRoute> BuildFromResponse(long entityKey)
        {
            var data = new List<EntityWithRoute>();

            for (int i = 0; i < 5; ++i)
            {
                if (i == 0)
                {
                    data.Add(new En_debtor_agreement()
                    {
                        DebtorId = entityKey,
                        DebtorName = "Должник 1",
                        BaseName = "Договор контрагента 1",
                        StatusAgreement = "Закрыт",
                        DateAgreement = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        NumberAgreement = "Договор поставки N123 от 10.05.2023",
                        CurrencyName = "RUB",
                        BudgetName = "Расчёты по приобретению товаров",
                        TurnoverName = "Расчёты по приобретению товаров",
                        PaymentName = "Расчёты по приобретению товаров",
                        Comment = "Загружен из КСУ \"Торговый дом\"",
                        SocietyName = "Общество 1",
                        BusinessName = "Группа Прочие компании",
                        MarketViewName = "Не применимо",
                        CounterTypeName = "",
                        PublicStatus = true,
                        TypicalStatus = false,
                        DisabledStatus = true,
                        ResponsibleName = "Домолего Захар Андреевич",
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTOR_CONTRACTS]}" +
                           $"/{entityKey}"
                    });
                }
                else
                {
                    data.Add(new En_event_record
                    {
                        EventRecordId = i,
                        CreationDate = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        EventStateName = "Запись события 1",
                        Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.EVENTS]}" +
                           $"/{i}"
                    });
                }
            }

            return data;
        }
    }
}
