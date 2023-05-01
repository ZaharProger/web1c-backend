using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("Counterparties")]
    public class En_counterparty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("counterparty_id")]
        public long counterparty_id { get; set; }

        [Column("counterparty_name", TypeName = "varchar(50)")]
        public string counterparty_name { get; set; }
    }
}
