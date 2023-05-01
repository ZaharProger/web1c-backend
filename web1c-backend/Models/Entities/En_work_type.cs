using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("Work_types")]
    public class En_work_type
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("work_type_id")]
        public long work_type_id { get; set; }

        [Column("work_type_name", TypeName = "varchar(50)")]
        public string work_type_name { get; set; }
    }
}
