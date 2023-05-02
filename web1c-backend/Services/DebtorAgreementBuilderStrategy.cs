using web1c_backend.Constants;
using web1c_backend.Models;
using web1c_backend.Models.Entities;

namespace web1c_backend.Services
{
    public class DebtorAgreementBuilderStrategy : IDataBuilderStrategy
    {
        public IQueryable<EntityWithRoute> BuildCollection(Web1cDBContext context)
        {
            return from debtorAgreement in context.DebtorAgreements

                   join counterpartyAgreement in context.CounterpartyAgreements
                   on debtorAgreement.base_id equals counterpartyAgreement.agreement_id

                   select new En_debtor_agreement()
                   {
                       date_agreement = debtorAgreement.date_agreement,
                       debtor_id = debtorAgreement.debtor_id,
                       debtor_name = debtorAgreement.debtor_name,
                       BaseName = counterpartyAgreement.agreement_name,
                       Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.DEBTOR_CONTRACTS]}" +
                          $"?Key={debtorAgreement.debtor_id}"
                   };
        }

        public IQueryable<EntityWithRoute> BuildFullEntity(Web1cDBContext context, string entityKey)
        {
            return from debtorAgreement in context.DebtorAgreements

                   where debtorAgreement.debtor_id.ToString().Equals(entityKey)

                   join counterpartyAgreement in context.CounterpartyAgreements
                   on debtorAgreement.base_id equals counterpartyAgreement.agreement_id

                   join budget in context.Budgets
                   on debtorAgreement.budget_id equals budget.budget_id into joinBudgets
                   from joinBudget in joinBudgets.DefaultIfEmpty()

                   join business in context.Businesses
                   on debtorAgreement.business_id equals business.business_id into joinBusinesses
                   from joinBusiness in joinBusinesses.DefaultIfEmpty()

                   join turnover in context.Turnovers
                   on debtorAgreement.turnover_id equals turnover.turnover_id into joinTurnovers
                   from joinTurnover in joinTurnovers.DefaultIfEmpty()

                   join currency in context.Currencies
                   on debtorAgreement.currency_id equals currency.currency_id into joinCurrencies
                   from joinCurrency in joinCurrencies.DefaultIfEmpty()

                   join counterType in context.CounterTypes
                   on debtorAgreement.counter_id equals counterType.counter_id into joinCounterTypes
                   from joinCounterType in joinCounterTypes.DefaultIfEmpty()

                   join payment in context.PaymentProcesses
                   on debtorAgreement.payment_id equals payment.payment_id into joinPayments
                   from joinPayment in joinPayments.DefaultIfEmpty()

                   join society in context.Societies
                   on debtorAgreement.society_id equals society.society_id into joinSocieties
                   from joinSociety in joinSocieties.DefaultIfEmpty()

                   join market in context.Markets
                   on debtorAgreement.Market_view_id equals market.market_id into joinMarkets
                   from joinMarket in joinMarkets.DefaultIfEmpty()

                   join user in context.Users
                   on debtorAgreement.responsible_id equals user.En_user_id into joinUsers
                   from joinUser in joinUsers.DefaultIfEmpty()

                   select new En_debtor_agreement(debtorAgreement)
                   {
                       BaseName = counterpartyAgreement.agreement_name,
                       BudgetName = joinBudget != null ? joinBudget.budget_name : "",
                       BusinessName = joinBusiness != null ? joinBusiness.business_name : "",
                       TurnoverName = joinTurnover != null ? joinTurnover.turnover_name : "",
                       CurrencyName = joinCurrency != null ? joinCurrency.currency_name : "",
                       CounterTypeName = joinCounterType != null ? joinCounterType.counter_name : "",
                       PaymentName = joinPayment != null ? joinPayment.payment_name : "",
                       SocietyName = joinSociety != null? joinSociety.society_name : "",
                       MarketViewName = joinMarket != null ? joinMarket.market_name : "",
                       ResponsibleName = joinUser != null ? joinUser.En_user_login : "",
                       Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.DEBTOR_CONTRACTS]}" +
                          $"?Key={debtorAgreement.debtor_id}"
                   };
        }

        IQueryable<EntityWithRoute> IDataBuilderStrategy.BuildEntityFromHistory(Web1cDBContext context, long entityKey)
        {
            return from debtorAgreement in context.DebtorAgreements

                   where debtorAgreement.debtor_id == entityKey

                   join counterpartyAgreement in context.CounterpartyAgreements
                   on debtorAgreement.base_id equals counterpartyAgreement.agreement_id

                   select new En_debtor_agreement()
                   {
                       date_agreement = debtorAgreement.date_agreement,
                       debtor_id = debtorAgreement.debtor_id,
                       debtor_name = debtorAgreement.debtor_name,
                       BaseName = counterpartyAgreement.agreement_name,
                       Route = $"{ConstValues.ROUTES[Routes.DOCUMENTS]}{ConstValues.ROUTES[Routes.DEBTOR_CONTRACTS]}" +
                          $"?Key={debtorAgreement.debtor_id}"
                   };
        }
    }
}
