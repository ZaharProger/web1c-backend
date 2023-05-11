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

        [Column("debtor", TypeName = "VARCHAR(100)")]
        public string debtor { get; set; }

        public En_debtor_card() { }

        public En_debtor_card(En_debtor_card debtorCard)
        {
            debtor_card_id = debtorCard.debtor_card_id;
            debtor_card_name = debtorCard.debtor_card_name;
            debtor = debtorCard.debtor;
            creation_date = debtorCard.creation_date;
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
