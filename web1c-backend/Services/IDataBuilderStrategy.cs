using web1c_backend.Models.Entities;

namespace web1c_backend.Services
{
    public interface IDataBuilderStrategy
    {
        public List<EntityWithRoute> BuildFromResponseAsync(long entityKey);
    }
}
