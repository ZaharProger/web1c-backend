using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web1c_backend.Models.Entities
{
    [Table("Event_records")]
    public class En_event_record : EntityWithRoute
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Column("event_record_id")]
        public long event_record_id { get; set; }

        [Column("creation_date", TypeName = "BIGINT")]
        public long creation_date { get; set; }

        [Column("send_date", TypeName = "BIGINT")]
        public long? send_date { get; set; }

        [Column("exp_execution_date", TypeName = "BIGINT")]
        public long? exp_execution_date { get; set; }

        [Column("execution_date", TypeName = "BIGINT")]
        public long? executon_date { get; set; }

        [Column("base_id", TypeName = "BIGINT")]
        public long? base_id { get; set; }

        [NotMapped]
        public string BaseName { get; set; }

        [Column("work_type_id", TypeName = "BIGINT")]
        public long? work_type_id { get; set; }

        [NotMapped]
        public string WorkTypeName { get; set; }

        [Column("debtor_card_id", TypeName = "BIGINT")]
        public long? debtor_card_id { get; set; }

        [NotMapped]
        public string DebtorCardName { get; set;}

        [Column("society_id", TypeName = "BIGINT")]
        public long? society_id { get; set; }

        [NotMapped]
        public string SocietyName { get; set; }

        [Column("business_id", TypeName = "BIGINT")]
        public long? business_id { get; set; }

        [NotMapped]
        public string BusinessName { get; set; }

        [Column("event_description", TypeName = "VARCHAR(1000)")]
        public string event_description { get; set; }

        [Column("event_comment", TypeName = "VARCHAR(1000)")]
        public string event_comment { get; set; }

        [Column("responsible_user", TypeName = "BIGINT")]
        public long? responsible_user_id { get; set; }

        [NotMapped]
        public string ResponsibleUserName { get; set; }

        [Column("event_state_id", TypeName = "BIGINT")]
        public long? event_state_id { get; set; }

        [NotMapped]
        public string EventStateName { get; set; }

        public En_event_record() { }

        public En_event_record(En_event_record eventRecord)
        {
            event_record_id = eventRecord.event_record_id;
            creation_date = eventRecord.creation_date;
            send_date = eventRecord.send_date;
            executon_date = eventRecord.executon_date;
            exp_execution_date = eventRecord.exp_execution_date;
            base_id = eventRecord.base_id;
            work_type_id = eventRecord.work_type_id;
            debtor_card_id = eventRecord.debtor_card_id;
            business_id = eventRecord.business_id;
            society_id = eventRecord.society_id;
            event_description = eventRecord.event_description;
            event_comment = eventRecord.event_comment;
            responsible_user_id = eventRecord.responsible_user_id;
            event_state_id = eventRecord.event_state_id;
        }
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
