using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web1c_backend.Models.Entities
{
    [Table("Debtor_Agreement")]
    public class En_debtor_agreement : EntityWithRoute
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("debtor_id")]
        public long debtor_id { get; set; }

        [Column("debtor_name", TypeName = "varchar(200)")]
        public string debtor_name { get; set; }

        [Column("base_id", TypeName = "BIGINT")]
        public long base_id { get; set; }

        [NotMapped]
        public string BaseName { get; set; }

        [Column("status_agreement", TypeName = "varchar(30)")]
        public string? status_agreement { get; set; }

        [Column("date_agreement", TypeName = "BIGINT")]
        public long date_agreement { get; set; }

        [Column("number_agreement", TypeName = "varchar(200)")]
        public string number_agreement { get; set; }

        [Column("currency_id", TypeName = "BIGINT")]
        public long? currency_id { get; set; }

        [NotMapped]
        public string CurrencyName { get; set; }

        [Column("budget_id", TypeName = "BIGINT")]
        public long? budget_id { get; set; }

        [NotMapped]
        public string BudgetName { get; set; }

        [Column("turnover_id", TypeName = "BIGINT")]
        public long? turnover_id { get; set; }

        [NotMapped]
        public string TurnoverName { get; set; }

        [Column("payment_id", TypeName = "BIGINT")]
        public long? payment_id { get; set; }

        [NotMapped]
        public string PaymentName { get; set; }

        [Column("comment", TypeName = "varchar(1000)")]
        public string? comment { get; set; }

        [Column("society_id", TypeName = "BIGINT")]
        public long? society_id { get; set; }

        [NotMapped]
        public string SocietyName { get; set; }

        [Column("business_id", TypeName = "BIGINT")]
        public long? business_id { get; set; }

        [NotMapped]
        public string BusinessName { get; set; }

        [Column("Market_view", TypeName = "BIGINT")]
        public long? Market_view_id { get; set; }

        [NotMapped]
        public string MarketViewName { get; set; }

        [Column("counter_id", TypeName = "BIGINT")]
        public long? counter_id { get; set; }

        [NotMapped]
        public string CounterTypeName { get; set; }

        [Column("public_status", TypeName = "bit")]
        public bool public_status { get; set; }

        [Column("typical_status", TypeName = "bit")]
        public bool typical_status { get; set; }

        [Column("disabled_status", TypeName = "bit")]
        public bool disabled_status { get; set; }

        [Column("responsible", TypeName = "BIGINT")]
        public long? responsible_id { get; set; }

        [NotMapped]
        public string ResponsibleName { get; set; }

        public En_debtor_agreement() { }

        public En_debtor_agreement(En_debtor_agreement debtorAgreement)
        {
            debtor_id = debtorAgreement.debtor_id;
            debtor_name = debtorAgreement.debtor_name;
            base_id = debtorAgreement.base_id;
            status_agreement = debtorAgreement.status_agreement;
            number_agreement = debtorAgreement.number_agreement;
            date_agreement = debtorAgreement.date_agreement;
            currency_id = debtorAgreement.currency_id;
            budget_id = debtorAgreement.budget_id;
            turnover_id = debtorAgreement.turnover_id;
            payment_id = debtorAgreement.payment_id;
            comment = debtorAgreement.comment;
            business_id = debtorAgreement.business_id;
            society_id = debtorAgreement.society_id;
            Market_view_id = debtorAgreement.Market_view_id;
            counter_id = debtorAgreement.counter_id;
            public_status = debtorAgreement.public_status;
            typical_status = debtorAgreement.typical_status;
            disabled_status = debtorAgreement.disabled_status;
            responsible_id = debtorAgreement.responsible_id;
        }
    }
}