namespace DataAccess
{
    using System.Collections.Generic;
    using System.Linq;
    using Model.Core;
    using Model.Object;

    public class EventsRepository : IEventsRepository<User>
    {
        private DatabaseContext context;

        public EventsRepository()
        {
            this.context = new DatabaseContext();
        }

        public IQueryable<User> GetAll()
        {
            return this.context.Set<User>();
        }

        public IEnumerable<User> GetEventsByUserId(int userId)
        {
            var events = this.context.Set<User>();
            return events.Where(user => user.Id == userId);
        }
    }
}
