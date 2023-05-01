using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web1c_backend.Models.Entities
{
    [Table("Counterparty_Agreement")]
    public class En_counterparty_agreement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("agreement_id")]
        public long agreement_id { get; set; }

        [Column("agreement_name", TypeName = "varchar(50)")]
        public string agreement_name { get; set; }
    }
}