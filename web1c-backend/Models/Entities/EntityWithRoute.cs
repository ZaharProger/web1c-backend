using System.ComponentModel.DataAnnotations.Schema;

namespace web1c_backend.Models.Entities
{
    public class EntityWithRoute
    {
        [NotMapped]
        public string Route { get; set; }
    }
}
