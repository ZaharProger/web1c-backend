using web1c_backend.Constants;
using web1c_backend.Models.Entities;

namespace web1c_backend.Services
{
    public class EventRecordBuilderStrategy : IDataBuilderStrategy
    {
        public List<EntityWithRoute> BuildFromResponse(long entityKey)
        {
            var data = new List<EntityWithRoute>();

            for (int i = 0; i < 5; ++i)
            {
                data.Add(new En_event_record()
                {
                    EventRecordId = entityKey,
                    CreationDate = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    EventName = "Запись события 1",
                    SendDate = DateTimeOffset.Now.AddDays(1).ToUnixTimeSeconds(),
                    ExecutonDate = DateTimeOffset.Now.AddDays(10).ToUnixTimeSeconds(),
                    ExpExecutionDate = DateTimeOffset.Now.AddDays(10).ToUnixTimeSeconds(),
                    BaseName = "",
                    WorkTypeName = "Мероприятия по истребованию задолженности",
                    DebtorCardName = "Должник 1",
                    SocietyName = "Общество 1",
                    BusinessName = "Группа Прочие компании",
                    EventComment = "",
                    EventDescription = "",
                    ResponsibleUserName = "Домолего Захар Андреевич",
                    EventStateName = "Завершен",
                    Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.EVENTS]}" +
                           $"/{entityKey}"
                });
            }

            return data;
        }
    }
}
