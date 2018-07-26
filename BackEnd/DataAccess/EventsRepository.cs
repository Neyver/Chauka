namespace DataAccess
{
    using System.Collections.Generic;
    using System.Linq;
    using Model.Core;
    using Model.Object;

    public class EventsRepository : IEventsRepository<Event>
    {
        private DatabaseContext context;

        public EventsRepository()
        {
            this.context = new DatabaseContext();
        }

        public IQueryable<Event> GetAll()
        {
            return this.context.Set<Event>();
        }

        public Event GetById(int id)
        {
            return this.context.Events.Find(id);
        }

        public IEnumerable<Event> GetEventsByUserId(int userId)
        {
            var events = this.context.Set<Event>();
            return events.Where(user => user.UserId == userId);
        }
    }
}
