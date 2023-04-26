using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web1c_backend.Models.Entities
{
    [Table("Event_records")]
    public class En_event_record
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("event_record_id")]
        public int event_record_id { get; set; }

        [Column("creation_date", TypeName = "DATETIME")]
        public DateTime creation_date { get; set; }
        [Column("send_date", TypeName = "DATETIME")]
        public DateTime send_date { get; set; }
        [Column("exp_execution_date", TypeName = "DATETIME")]
        public DateTime exp_execution_date { get; set; }
        [Column("execution_date", TypeName = "DATETIME")]
        public DateTime executon_date { get; set; }

        [Column("base_document_id", TypeName = "INT")]
        public int base_document_id { get; set; }
        [Column("work_type_id", TypeName = "INT")]
        public int work_type_id { get; set; }
        [Column("debtor_card_id", TypeName = "INT")]
        public int debtor_card_id { get; set; }
        [Column("company_id", TypeName = "INT")]
        public int company_id { get; set; }
        [Column("business_id", TypeName = "INT")]
        public int business_id { get; set; }
        [Column("event_description", TypeName = "VARCHAR(1000)")]
        public string event_description { get; set; }
        [Column("event_comment", TypeName = "VARCHAR(1000)")]
        public string event_comment { get; set; }
        [Column("responsible_user", TypeName = "VARCHAR(50)")]
        public string responsible_user { get; set; }
    }
}

/*
 event_record_id INT PRIMARY KEY IDENTITY NOT NULL,
    creation_date DATETIME,
    send_date DATETIME,
    exp_execution_date DATETIME,
    execution_date DATETIME,
    base_document_id INT,
    work_type_id INT,
    debtor_card_id INT,
    company_id INT,
    business_id INT,
    event_description VARCHAR,
    event_comment VARCHAR,
    responsible_user CHAR(50),
 */
