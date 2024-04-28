using Microsoft.EntityFrameworkCore;
using web1c_backend.Models.Contexts;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Params;

namespace web1c_backend.Services
{
    public class DataBuilder
    {
        public async Task<EntityWithRoute[]> BuildFromCache(Web1cDBContext context, 
            ICachedDataBuilderStrategy strategy, GetParams queryParams)
        {
            // В зависимости от значения Type используется тот или иной метод стратегии
            IQueryable<EntityWithRoute>? collection = queryParams.Type switch
            {
                1 => strategy.BuildCollection(context),
                2 => strategy.BuildEntityFromHistory(context, long.Parse(queryParams.Key)),
                3 => strategy.BuildCollectionByKey(context, queryParams.Key),
                _ => null
            };

            return collection != null? 
                await collection.ToArrayAsync() : 
                Array.Empty<EntityWithRoute>();
        }

        public EntityWithRoute[] BuildFromResponse(IDataBuilderStrategy strategy, GetParams queryParams)
        {
            return strategy
                .BuildFromResponseAsync(long.Parse(queryParams.Key))
                .ToArray();
        }
    }
}
