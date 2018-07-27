namespace ChaukaApp.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Model.Core;
    using Model.Object;

    public class TestEventsRepository : IEventsRepository<Event>
    {
        private List<Event> entities = new List<Event>();

        public TestEventsRepository()
        {
            this.entities.Add(new Event()
            {
                Id = 1,
                NameEvent = "Event1",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0),
                UserId = 1
            });

            this.entities.Add(new Event()
            {
                NameEvent = "Event2",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0),
                UserId = 1
            });

            this.entities.Add(new Event()
            {
                NameEvent = "Event3",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0),
                UserId = 1
            });
        }

        private static IQueryable<Event> Entities { get; set; }

        public bool Add(Event eventObject)
        {
            this.entities.Add(eventObject);
            return true;
        }

        public IQueryable<Event> GetAll()
        {
            return null;
        }

        public Event GetById(int id)
        {
            return this.entities.Find(elem => elem.Id == id);
        }

        public IEnumerable<Event> GetEventsByUserId(int userId)
        {
            List<Event> events = this.entities.FindAll(elem => elem.UserId == userId);
            return events;
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
