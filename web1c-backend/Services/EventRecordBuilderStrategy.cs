using System.Linq;
using web1c_backend.Constants;
using web1c_backend.Models;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Params;

namespace web1c_backend.Services
{
    public class EventRecordBuilderStrategy : IDataBuilderStrategy
    {
        public IQueryable<EntityWithRoute> BuildCollection(Web1cDBContext context, GetParams queryParams)
        {
            IQueryable<En_event_record> collection;

            if (queryParams.Key.Equals(""))
            {
                collection = from eventRecord in context.Events

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
                                 DebtorCardName = joinDebtorCard != null? joinDebtorCard.debtor_card_name : "",
                                 WorkTypeName = joinWorkType != null? joinWorkType.work_type_name : "",
                                 Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.EVENTS]}" +
                                    $"?Key={eventRecord.event_record_id}"
                             };
            }
            else
            {
                collection = from eventRecord in context.Events

                             where eventRecord.event_record_id.ToString().Equals(queryParams.Key)

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
                                 BaseName = joinEvent != null? $"Запись события {joinEvent.event_record_id}" : "",
                                 DebtorCardName = joinDebtorCard != null? joinDebtorCard.debtor_card_name : "",
                                 WorkTypeName = joinWorkType != null? joinWorkType.work_type_name : "",
                                 BusinessName = joinBusiness != null? joinBusiness.business_name : "",
                                 SocietyName = joinSociety != null? joinSociety.society_name : "",
                                 ResponsibleUserName = joinUser != null? joinUser.En_user_login : "",
                                 EventStateName = joinEventState != null? joinEventState.state_name : "",
                                 Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.EVENTS]}" +
                                    $"?Key={eventRecord.event_record_id}"
                             };
            }

            return collection;
        }
    }
}
