using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("Society")]
    public class En_society
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("society_id")]
        public long society_id { get; set; }

        [Column("society_name", TypeName = "varchar(50)")]
        public string society_name { get; set; }
    }
}
