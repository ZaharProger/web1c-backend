using web1c_backend.Models;
using web1c_backend.Models.Entities;

namespace web1c_backend.Services
{
    public interface ICachedDataBuilderStrategy : IDataBuilderStrategy
    {
        //Метод для получения списка сущностей
        IQueryable<EntityWithRoute> BuildCollection(Web1cDBContext context);

        //Метод для получения сущности
        IQueryable<EntityWithRoute> BuildEntityFromHistory(Web1cDBContext context, long entityKey);

        //Этот метод необходимо реализовать у всех классов, реализующих IDataBuilderStrategy,
        //он определяет алгоритм получения списка сущностей по ключу поиска
        IQueryable<EntityWithRoute> BuildCollectionByKey(Web1cDBContext context, string searchKey);
    }
}
