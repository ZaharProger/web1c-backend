using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("Event_states")]
    public class En_event_state
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("state_id")]
        public long state_id { get; set; }

        [Column("state_name", TypeName = "varchar(30)")]
        public string state_name { get; set; }
    }
}
