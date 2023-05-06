using web1c_backend.Constants;
using web1c_backend.Models;
using web1c_backend.Models.Entities;

namespace web1c_backend.Services
{
    public class EventRecordBuilderStrategy : IDataBuilderStrategy
    {
        public IQueryable<EntityWithRoute> BuildCollection(Web1cDBContext context)
        {
            return from eventRecord in context.Events

                   join debtorCard in context.DebtorCards
                   on eventRecord.debtor_card_id equals debtorCard.debtor_card_id into joinDebtorCards
                   from joinDebtorCard in joinDebtorCards.DefaultIfEmpty()

                   join workType in context.WorkTypes
                   on eventRecord.work_type_id equals workType.work_type_id into joinWorkTypes
                   from joinWorkType in joinWorkTypes.DefaultIfEmpty()

                   select new En_event_record()
                   {
                       creation_date = eventRecord.creation_date,
                       event_record_id = eventRecord.event_record_id,
                       DebtorCardName = joinDebtorCard != null ? joinDebtorCard.debtor_card_name : "",
                       WorkTypeName = joinWorkType != null ? joinWorkType.work_type_name : "",
                       Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.EVENTS]}" +
                          $"?Key={eventRecord.event_record_id}"
                   };
        }

        public IQueryable<EntityWithRoute> BuildFullEntity(Web1cDBContext context, long entityKey)
        {
            return from eventRecord in context.Events

                   where eventRecord.event_record_id == entityKey

                   join anotherEventRecord in context.Events
                   on eventRecord.base_id equals anotherEventRecord.event_record_id into joinEvents
                   from joinEvent in joinEvents.DefaultIfEmpty()

                   join debtorCard in context.DebtorCards
                   on eventRecord.debtor_card_id equals debtorCard.debtor_card_id into joinDebtorCards
                   from joinDebtorCard in joinDebtorCards.DefaultIfEmpty()

                   join workType in context.WorkTypes
                   on eventRecord.work_type_id equals workType.work_type_id into joinWorkTypes
                   from joinWorkType in joinWorkTypes.DefaultIfEmpty()

                   join business in context.Businesses
                   on eventRecord.business_id equals business.business_id into joinBusinesses
                   from joinBusiness in joinBusinesses.DefaultIfEmpty()

                   join society in context.Societies
                   on eventRecord.society_id equals society.society_id into joinSocieties
                   from joinSociety in joinSocieties.DefaultIfEmpty()

                   join user in context.Users
                   on eventRecord.responsible_user_id equals user.En_user_id into joinUsers
                   from joinUser in joinUsers.DefaultIfEmpty()

                   join eventState in context.Event_States
                   on eventRecord.event_state_id equals eventState.state_id into joinEventStates
                   from joinEventState in joinEventStates.DefaultIfEmpty()

                   select new En_event_record(eventRecord)
                   {
                       BaseName = joinEvent != null ? $"Запись события {joinEvent.event_record_id}" : "",
                       DebtorCardName = joinDebtorCard != null ? joinDebtorCard.debtor_card_name : "",
                       WorkTypeName = joinWorkType != null ? joinWorkType.work_type_name : "",
                       BusinessName = joinBusiness != null ? joinBusiness.business_name : "",
                       SocietyName = joinSociety != null ? joinSociety.society_name : "",
                       ResponsibleUserName = joinUser != null ? joinUser.En_user_login : "",
                       EventStateName = joinEventState != null ? joinEventState.state_name : "",
                       Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.EVENTS]}" +
                          $"?Key={eventRecord.event_record_id}"
                   };
        }

        IQueryable<EntityWithRoute> IDataBuilderStrategy.BuildEntityFromHistory(Web1cDBContext context, long entityKey)
        {
            return from eventRecord in context.Events

                   where eventRecord.event_record_id == entityKey

                   join debtorCard in context.DebtorCards
                   on eventRecord.debtor_card_id equals debtorCard.debtor_card_id into joinDebtorCards
                   from joinDebtorCard in joinDebtorCards.DefaultIfEmpty()

                   join workType in context.WorkTypes
                   on eventRecord.work_type_id equals workType.work_type_id into joinWorkTypes
                   from joinWorkType in joinWorkTypes.DefaultIfEmpty()

                   select new En_event_record()
                   {
                       creation_date = eventRecord.creation_date,
                       event_record_id = eventRecord.event_record_id,
                       DebtorCardName = joinDebtorCard != null ? joinDebtorCard.debtor_card_name : "",
                       WorkTypeName = joinWorkType != null ? joinWorkType.work_type_name : "",
                       Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.EVENTS]}" +
                          $"?Key={eventRecord.event_record_id}"
                   };
        }

        public IQueryable<EntityWithRoute> BuildCollectionByKey(Web1cDBContext context, string searchKey)
        {
            return from eventRecord in context.Events

                   // Поиск по событию-основанию не ведётся т.к. это значение предстаяляет собой просто id дургого события
                   // и поиск по нему может привести к путанице со стороны пользователя

                   join debtorCard in context.DebtorCards
                   on eventRecord.debtor_card_id equals debtorCard.debtor_card_id into joinDebtorCards
                   from joinDebtorCard in joinDebtorCards.DefaultIfEmpty()

                   join workType in context.WorkTypes
                   on eventRecord.work_type_id equals workType.work_type_id into joinWorkTypes
                   from joinWorkType in joinWorkTypes.DefaultIfEmpty()

                   join business in context.Businesses
                   on eventRecord.business_id equals business.business_id into joinBusinesses
                   from joinBusiness in joinBusinesses.DefaultIfEmpty()

                   join society in context.Societies
                   on eventRecord.society_id equals society.society_id into joinSocieties
                   from joinSociety in joinSocieties.DefaultIfEmpty()

                   join user in context.Users
                   on eventRecord.responsible_user_id equals user.En_user_id into joinUsers
                   from joinUser in joinUsers.DefaultIfEmpty()

                   join eventState in context.Event_States
                   on eventRecord.event_state_id equals eventState.state_id into joinEventStates
                   from joinEventState in joinEventStates.DefaultIfEmpty()

                   where(
                       eventRecord.event_record_id.ToString().Contains(searchKey) ||
                       eventRecord.event_description.Contains(searchKey) ||
                       eventRecord.event_comment.Contains(searchKey) ||
                       joinWorkType.work_type_name.Contains(searchKey) ||
                       joinDebtorCard.debtor_card_name.Contains(searchKey) ||
                       joinSociety.society_name.Contains(searchKey) ||
                       joinBusiness.business_name.Contains(searchKey) ||
                       joinUser.En_user_login.Contains(searchKey) ||
                       joinEventState.state_name.Contains(searchKey)
                   )

                   // В результате поиска возвращаем краткую форму записей
                   select new En_event_record()
                   {
                       creation_date = eventRecord.creation_date,
                       event_record_id = eventRecord.event_record_id,
                       DebtorCardName = joinDebtorCard != null ? joinDebtorCard.debtor_card_name : "",
                       WorkTypeName = joinWorkType != null ? joinWorkType.work_type_name : "",
                       Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.EVENTS]}" +
                          $"?Key={eventRecord.event_record_id}"
                   };
        }
    }
}
