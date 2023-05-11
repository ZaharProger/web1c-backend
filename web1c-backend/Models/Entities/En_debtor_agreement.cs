namespace web1c_backend.Models.Entities
{
    public class En_debtor_agreement : EntityWithRoute
    {
        public long DebtorId { get; set; }

        public string DebtorName { get; set; }

        public string BaseName { get; set; }

        public string? StatusAgreement { get; set; }

        public long DateAgreement { get; set; }

        public string NumberAgreement { get; set; }

        public string CurrencyName { get; set; }

        public string BudgetName { get; set; }

        public string TurnoverName { get; set; }

        public string PaymentName { get; set; }

        public string? Comment { get; set; }

        public string SocietyName { get; set; }

        public string BusinessName { get; set; }

        public string MarketViewName { get; set; }

        public string CounterTypeName { get; set; }

        public bool PublicStatus { get; set; }

        public bool TypicalStatus { get; set; }

        public bool DisabledStatus { get; set; }

        public string ResponsibleName { get; set; }
    }
}