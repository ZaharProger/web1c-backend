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

        public async Task<EntityWithRoute[]> BuildCollection (IDataBuilderStrategy strategy, GetParams queryParams)
        {
            return await strategy
                .BuildCollection(context, queryParams)
                .ToArrayAsync();
        }
    }
}
