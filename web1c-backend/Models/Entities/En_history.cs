using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("History")]
    public class En_history
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("history_id")]
        public long history_id { get; set; }

        [Column("entity_type_id", TypeName = "TINYINT")]
        public byte entity_type_id { get; set; }

        [Column("entity_id", TypeName = "BIGINT")]
        public long entity_id { get; set; }

        [Column("user_id", TypeName = "BIGINT")]
        public long? user_id { get; set; }
    }
}
