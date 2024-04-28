using System.Numerics;

namespace web1c_backend.Models.Entities
{
    public class En_event_record : EntityWithRoute
    {
        public long EventRecordId { get; set; }

        public long CreationDate { get; set; }

        public string? EventName { get; set; }

        public long? SendDate { get; set; }

        public long? ExpExecutionDate { get; set; }

        public long? ExecutonDate { get; set; }

        public string? BaseName { get; set; }

        public string? WorkTypeName { get; set; }

        public string? DebtorCardName { get; set;}

        public string? SocietyName { get; set; }

        public string? BusinessName { get; set; }

        public string? EventDescription { get; set; }

        public string? EventComment { get; set; }

        public string? ResponsibleUserName { get; set; }

        public string? EventStateName { get; set; }
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
