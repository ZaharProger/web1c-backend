using web1c_backend.Models;
using web1c_backend.Models.Entities;

namespace web1c_backend.Services
{
    public interface IDataBuilderStrategy
    {
        //Метод для построения конкретной сущности (получение всей информации о сущности по её id)
        IQueryable<EntityWithRoute> BuildFullEntity(Web1cDBContext context, long entityKey);

        //Метод для получения списка сущностей
        IQueryable<EntityWithRoute> BuildCollection(Web1cDBContext context);

        //Метод для получения сущности из списка ранее просмотренных (таблица History в БД)
        IQueryable<EntityWithRoute> BuildEntityFromHistory(Web1cDBContext context, long entityKey);

        //Этот метод необходимо реализовать у всех классов, реализующих IDataBuilderStrategy,
        //он определяет алгоритм получения списка сущностей по ключу поиска
        IQueryable<EntityWithRoute> BuildCollectionByKey(Web1cDBContext context, string searchKey);
    }
}
