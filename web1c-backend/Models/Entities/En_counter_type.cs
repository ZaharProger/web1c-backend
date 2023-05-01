using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("CounterType")]
    public class En_counter_type
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("counter_id")]
        public long counter_id { get; set; }

        [Column("counter_name", TypeName = "varchar(50)")]
        public string counter_name { get; set; }
    }
}
