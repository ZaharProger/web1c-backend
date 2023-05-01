using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("Budget")]
    public class En_budget
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("budget_id")]
        public long budget_id { get; set; }

        [Column("budget_name", TypeName = "varchar(50)")]
        public string budget_name { get; set; }
    }
}
