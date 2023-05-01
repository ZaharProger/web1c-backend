using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("Business")]
    public class En_business
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("business_id")]
        public long business_id { get; set; }

        [Column("business_name", TypeName = "varchar(50)")]
        public string business_name { get; set; }
    }
}
