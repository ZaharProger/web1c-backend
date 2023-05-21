using web1c_backend.Constants;
using web1c_backend.Models.Entities;

namespace web1c_backend.Tests.Moks
{
    public class HistoryMock
    {
        public static List<En_history> GetHistory()
        {
            return new List<En_history>()
            {
                new En_history()
                {
                    history_id = 52,
                    entity_type_id = (byte)EntityTypes.DEBTOR_CARD,
                    entity_id = 18,
                    user_id = 4
                },
                new En_history()
                {
                    history_id = 53,
                    entity_type_id = (byte)EntityTypes.DEBTOR_CARD,
                    entity_id = 15,
                    user_id = 4
                },
                new En_history()
                {
                    history_id = 54,
                    entity_type_id = (byte)EntityTypes.DEBTOR_CARD,
                    entity_id = 11,
                    user_id = 4
                }
            };
        }

        public static List<En_user> GetUserId()
        {
            return new List<En_user>
            {
                new En_user()
                {
                    En_user_id = 4
                }
            };
        }

        public static List<En_debtor_card> GetDebtorCards()
        {
            return new List<En_debtor_card>()
            {
                new En_debtor_card()
                {
                    debtor_card_id = 11,
                    debtor_card_name = "card name 5",
                    debtor = "Some Company 8",
                    creation_date = 45041
                },
                new En_debtor_card()
                {
                    debtor_card_id = 15,
                    debtor_card_name = "card name 5",
                    debtor = "Some Company 8",
                    creation_date = 45041
                },
                new En_debtor_card()
                {
                    debtor_card_id = 18,
                    debtor_card_name = "card name 8",
                    debtor = "Some Company 10",
                    creation_date = 45041
                }
            };
        }
    }
}
