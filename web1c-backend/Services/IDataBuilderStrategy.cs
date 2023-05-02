using web1c_backend.Models;
using web1c_backend.Models.Entities;

namespace web1c_backend.Services
{
    public interface IDataBuilderStrategy
    {
        IQueryable<EntityWithRoute> BuildFullEntity(Web1cDBContext context, string entityKey);

        IQueryable<EntityWithRoute> BuildCollection(Web1cDBContext context);

        IQueryable<EntityWithRoute> BuildEntityFromHistory(Web1cDBContext context, long entityKey);
    }
}
