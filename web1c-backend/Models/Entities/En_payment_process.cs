using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web1c_backend.Models.Entities
{
    [Table("Payment_process")]
    public class En_payment_process
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("payment_id")]
        public long payment_id { get; set; }

        [Column("payment_name", TypeName = "varchar(50)")]
        public string payment_name { get; set; }
    }
}
