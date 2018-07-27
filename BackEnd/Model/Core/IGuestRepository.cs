namespace Model.Core
{
    using System.Collections.Generic;

    public interface IGuestRepository<T> : IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetGuestByEventId(int eventId);
    }
}
