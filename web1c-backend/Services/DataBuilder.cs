using Microsoft.EntityFrameworkCore;
using web1c_backend.Models;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Params;

namespace web1c_backend.Services
{
    public class DataBuilder
    {
        private readonly Web1cDBContext context;

        public DataBuilder(Web1cDBContext context) 
        {
            this.context = context;
        }

        public async Task<EntityWithRoute[]> Build(IDataBuilderStrategy strategy, GetParams queryParams)
        {
            // В зависимости от значения Type используется тот или иной метод стратегии
            IQueryable<EntityWithRoute> collection = queryParams.Type switch
            {
                1 => strategy.BuildCollection(context),
                2 => strategy.BuildFullEntity(context, long.TryParse(queryParams.Key, out long res)? res : 0L),
                _ => strategy.BuildEntityFromHistory(context, long.Parse(queryParams.Key)),
            };

            return await collection.ToArrayAsync();
        }
    }
}
