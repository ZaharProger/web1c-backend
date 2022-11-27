using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web1c_backend.Models.Entities
{
    [Table("En_user")]
    public class En_user
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("En_user_id")]
        public long En_user_id { get; set; }

        [Column("En_user_login", TypeName = "varchar(50)")]
        public string En_user_login { get; set; }

        [Column("En_user_password", TypeName = "varbinary(100)")]
        public byte[] En_user_password { get; set; }
    }
}
