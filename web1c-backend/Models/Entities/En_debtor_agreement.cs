using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace web1c_backend.Models.Entities
{
    [Table("Debtor_Agreement")]
    public class En_debtor_agreement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("debtor_id")]
        public long debtor_id { get; set; }

        [Column("debtor_name", TypeName = "varchar(200)")]
        public string debtor_name { get; set; }

        [Column("base_id", TypeName = "BIGINT")]
        public long base_id { get; set; }

        [Column("status_agreement", TypeName = "varchar(30)")]
        public string status_agreement { get; set; }

        [Column("date_agreement", TypeName = "BIGINT")]
        public long date_agreement { get; set; }

        [Column("number_agreement", TypeName = "varchar(200)")]
        public string number_agreement { get; set; }

        [Column("currency_id", TypeName = "BIGINT")]
        public long currency_id { get; set; }

        [Column("budget_id", TypeName = "BIGINT")]
        public long budget_id { get; set; }

        [Column("turnover_id", TypeName = "BIGINT")]
        public long turnover_id { get; set; }

        [Column("payment_id", TypeName = "BIGINT")]
        public long payment_id { get; set; }

        [Column("comment", TypeName = "varchar(1000)")]
        public string comment { get; set; }

        [Column("society_id", TypeName = "BIGINT")]
        public long society_id { get; set; }

        [Column("business_id", TypeName = "BIGINT")]
        public long business_id { get; set; }


        [Column("Market_view", TypeName = "varchar(200)")]
        public string Market_view { get; set; }

        [Column("counter_id", TypeName = "BIGINT")]
        public long counter_id { get; set; }


        [Column("public_status", TypeName = "bit")]
        public bool public_status { get; set; }

        [Column("typical_status", TypeName = "bit")]
        public bool typical_status { get; set; }

        [Column("disabled_status", TypeName = "bit")]
        public bool disabled_status { get; set; }

        [Column("responsible", TypeName = "varchar(100)")]
        public string responsible { get; set; }

    }
}