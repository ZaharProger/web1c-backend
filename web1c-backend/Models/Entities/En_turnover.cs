using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("Turnover")]
    public class En_turnover
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("turnover_id")]
        public long turnover_id { get; set; }

        [Column("turnover_name", TypeName = "varchar(50)")]
        public string turnover_name { get; set; }
    }
}
