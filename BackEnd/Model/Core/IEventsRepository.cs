namespace Model.Core
{
    using System.Collections.Generic;

    public interface IEventsRepository<T> : IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetEventsByUserId(int userId);

        bool Add(T eventObject);

        int SaveChanges();
    }
}
