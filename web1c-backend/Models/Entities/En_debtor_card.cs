using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace web1c_backend.Models.Entities
{
    [Table("Debtor_cards")]
    public class En_debtor_card : EntityWithRoute
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("debtor_card_id")]
        public long debtor_card_id { get; set; }

        [Column("debtor_card_name", TypeName = "VARCHAR(100)")]
        public string debtor_card_name { get; set; }

        [Column("creation_date", TypeName = "BIGINT")]
        public long creation_date { get; set; }

        [Column("debtor_id", TypeName = "BIGINT")]
        public long? debtor_id { get; set; }

        [NotMapped]
        public string DebtorName { get; set; }

        [Column("inn", TypeName = "VARCHAR(10)")]
        public string? inn { get; set; }

        [Column("kpp", TypeName = "VARCHAR(9)")]
        public string? kpp { get; set; }

        [Column("is_smp", TypeName = "BIT")]
        public bool is_smp { get; set; }

        [Column("sanctions", TypeName = "VARCHAR(1000)")]
        public string? sanctions { get; set; }

        [Column("is_bankrupt", TypeName = "BIT")]
        public bool is_bankrupt { get; set; }

        [Column("is_in_creditors_list", TypeName = "BIT")]
        public bool is_in_creditors_list { get; set; }

        public En_debtor_card() { }

        public En_debtor_card(En_debtor_card debtorCard)
        {
            debtor_card_id = debtorCard.debtor_card_id;
            debtor_card_name = debtorCard.debtor_card_name;
            debtor_id = debtorCard.debtor_id;
            creation_date = debtorCard.creation_date;
            inn = debtorCard.inn;
            kpp = debtorCard.kpp;
            is_smp = debtorCard.is_smp;
            sanctions = debtorCard.sanctions;
            is_bankrupt = debtorCard.is_bankrupt;
            is_in_creditors_list = debtorCard.is_in_creditors_list;
        }
    }
}

/*
 debtor_card_id INT PRIMARY KEY IDENTITY NOT NULL,
    debtor_card_name VARCHAR,
    creation_date DATETIME,
    debtor_id INT,
    inn CHAR(10),
    kpp CHAR(9),
    is_smp BIT,
    sanctions VARCHAR,
    is_bankrupt BIT,
    is_in_creditors_list BIT
 */
