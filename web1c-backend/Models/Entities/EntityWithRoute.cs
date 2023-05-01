using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace web1c_backend.Models.Entities
{
    [JsonDerivedType(typeof(EntityWithRoute), typeDiscriminator: "entityWithRoute")]
    [JsonDerivedType(typeof(En_debtor_card), typeDiscriminator: "debtorCard")]
    [JsonDerivedType(typeof(En_debtor_agreement), typeDiscriminator: "debtorAgreement")]
    [JsonDerivedType(typeof(En_event_record), typeDiscriminator: "eventRecord")]
    public class EntityWithRoute
    {
        [NotMapped]
        public string Route { get; set; }
    }
}
