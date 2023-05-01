using web1c_backend.Models;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Params;

namespace web1c_backend.Services
{
    public interface IDataBuilderStrategy
    {
        IQueryable<EntityWithRoute> BuildCollection(Web1cDBContext context, GetParams queryParams);
    }
}
