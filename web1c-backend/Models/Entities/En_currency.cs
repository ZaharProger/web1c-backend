using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("Currency")]
    public class En_currency
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("currency_id")]
        public long currency_id { get; set; }

        [Column("currency_name", TypeName = "varchar(50)")]
        public string currency_name { get; set; }
    }
}
