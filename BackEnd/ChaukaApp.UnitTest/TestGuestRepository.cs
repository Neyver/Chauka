namespace ChaukaApp.UnitTest
{
    using Model.Core;
    using Model.Object;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestGuestRepository : IGuestRepository<Guest>
    {
        public TestGuestRepository()
        {
            List<Guest> guestsList = new List<Guest>();
            guestsList.Add(new Guest { Id = 1, UserId = 1, EventId = 1 });
            guestsList.Add(new Guest { Id = 2, UserId = 2, EventId = 1 });
            guestsList.Add(new Guest { Id = 3, UserId = 1, EventId = 2 });
            guestsList.Add(new Guest { Id = 4, UserId = 3, EventId = 3 });
            guestsList.Add(new Guest { Id = 5, UserId = 3, EventId = 3 });
            this.guests = guestsList.AsEnumerable();
        }

        private IEnumerable<Guest> guests;

        public bool Create(Guest entity)
        {
            return true;
        }

        public Guest GetById(int id)
        {
            return null;
        }

        public IQueryable<Guest> GetAll()
        {
            return guests.AsQueryable();
        }

        public IEnumerable<Guest> GetGuestsByEventId(int eventId)
        {
            return guests.Where(guest => guest.EventId == eventId && String.Equals(guest.Status, "PENDING"));
        }

        public IEnumerable<Guest> GetEventsByUserId(int userId)
        {
            return guests.Where(guest => guest.UserId == userId && String.Equals(guest.Status, "PENDING"));
        }
    }
}

/*
 Id	UserId	EventId
1	1	1
2	2	1
3	1	2
4	3	2
5	3	3
 */
