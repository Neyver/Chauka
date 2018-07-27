namespace Model.Core
{
    using System.Collections.Generic;

    public interface IGuestRepository<T> : IRepository<T> where T : IEntity
    {
        void Create(T entity);

        IEnumerable<T> GetGuestByEventId(int eventId);
    }
}
