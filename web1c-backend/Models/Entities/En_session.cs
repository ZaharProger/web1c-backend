using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web1c_backend.Models.Entities
{
    [Table("En_session")]
    public class En_session
    {
        [Column("En_session_id"), Key]
        public long En_session_id { get; set; }

        [Column("En_user_id")]
        public long? En_user_id { get; set; }
        [Column("En_session_date")] 
        public long? En_session_date { get; set; }
        [Column("En_session_time")]
        public long? En_session_time { get; set; }
    }
}
