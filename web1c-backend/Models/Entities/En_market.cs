using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("Markets")]
    public class En_market
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("market_id")]
        public long market_id { get; set; }

        [Column("market_name", TypeName = "varchar(50)")]
        public string market_name { get; set; }
    }
}
