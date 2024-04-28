using Newtonsoft.Json;
using System;
using web1c_backend.Constants;
using web1c_backend.Models.Contexts;
using web1c_backend.Models.Entities;
using System.Collections.Generic;
using static Grpc.Core.Metadata;

namespace web1c_backend.Services
{
    public class DebtorCardBuilderStrategy : ICachedDataBuilderStrategy
    {
        static readonly List<En_debtor_card> cards = new List<En_debtor_card>() {
        new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = 10003,
                        debtor_card_name = "12ММ",
                        debtor = "12ММ",
                        DebtorPaymentArrears = 28350.0D,
                        Inn = "0000000000",
                        Kpp = "772901001",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{10003}"
                    },
        new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = 10010,
                        debtor_card_name = "1ГБ.РУ АО",
                        debtor = "1ГБ.РУ АО",
                        DebtorPaymentArrears = 53200.0D,
                        Inn = "7720589079",
                        Kpp = "772901001",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{10010}"
                    },
        new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = 10011,
                        debtor_card_name = "38СПЕЦТЕХ ООО",
                        debtor = "38СПЕЦТЕХ ООО",
                        DebtorPaymentArrears = 27900.0D,
                        Inn = "3812524677",
                        Kpp = "381201001",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{10011}"
                    },
        new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = 10012,
                        debtor_card_name = "3Degrees Group, Inc",
                        debtor = "3Degrees Group, Inc",
                        DebtorPaymentArrears = 89000.0D,
                        Inn = "3812524677",
                        Kpp = "381201001",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{10012}"
                    },
        new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = 10013,
                        debtor_card_name = "40-СОРОКОВЫЕ ООО",
                        debtor = "40-СОРОКОВЫЕ ООО",
                        DebtorPaymentArrears = 45000.0D,
                        Inn = "2460099610",
                        Kpp = "246001001",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{10012}"
                    },
        new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = 10014,
                        debtor_card_name = "ACT Commodities B.V.",
                        debtor = "ACT Commodities B.V.",
                        DebtorPaymentArrears = 74200.0D,
                        Inn = "2536244980",
                        Kpp = "253601001",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{10012}"
                    },
        new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = 10015,
                        debtor_card_name = "BBS",
                        debtor = "BBS-CIS Ltd.",
                        DebtorPaymentArrears = 65000.0D,
                        Inn = "9729004828",
                        Kpp = "772901001",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{10012}"
                    },
        new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = 10016,
                        debtor_card_name = "Booking.com B.V.",
                        debtor = "Booking.com B.V.",
                        DebtorPaymentArrears = 23000.0D,
                        Inn = "9909287967",
                        Kpp = "775087001",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{10012}"
                    },
        new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = 10017,
                        debtor_card_name = "Grid Solutions SAS",
                        debtor = "Grid Solutions SAS",
                        DebtorPaymentArrears = 42000.0D,
                        Inn = "9909579913",
                        Kpp = "997789001",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{10012}"
                    },
        new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = 10019,
                        debtor_card_name = "Hengyang Nanfang Instrume",
                        debtor = "Hengyang",
                        DebtorPaymentArrears = 90000.0D,
                        Inn = "1000100010",
                        Kpp = "000000000",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{10012}"
                    }

    };
      
        static readonly HttpClient client = new HttpClient();
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

        public List<EntityWithRoute> BuildFromResponseAsync(long entityKey)
        {
            var data = new List<EntityWithRoute>();

            for (int i = 0; i < 10; ++i)
            {
                if (i == 0)
                {

                    //HttpResponseMessage response = client.GetAsync("http://localhost:80/InfoBase1/ws/WebInterfaceIntegration?id=" + entityKey + "&type=1").Result;  // Отправка запроса GET

                    // response.EnsureSuccessStatusCode(); // Проверка, что ответ успешный
                    // string responseBody = response.Content.ReadAsStringAsync().Result;
                    // var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);
                    // Dictionary<string, string> entity = (Dictionary<string, string>)dictionary["entity"];
                    /*data.Add(new En_debtor_card()
                    {
                        creation_date = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        debtor_card_id = entityKey,
                        debtor_card_name = "12ММ",
                        debtor = "12ММ",
                        DebtorPaymentArrears = 43800.0D,
                        Inn = "9729004828",
                        Kpp = "772901001",
                        IsSmp = true,
                        Sanctions = "Рисков не обнаружено",
                        IsBankrupt = false,
                        IsInCreditorsList = true,
                        Route = $"{ConstValues.ROUTES[Routes.CLASSES]}{ConstValues.ROUTES[Routes.DEBTORS]}" +
                           $"/{entityKey}"
                    });*/
                    var a = cards.Where(card => card.debtor_card_id == entityKey).ToList();
                    data.Add(a.Count != 0? a[0] : cards.First());
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
