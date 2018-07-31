namespace ChaukaApp.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model.Core;
    using Model.Object;

    public class TestGuestRepository : IGuestRepository<Guest>
    {
        private IEnumerable<Guest> guests;

        public TestGuestRepository()
        {
            List<Guest> guestsList = new List<Guest>();
            guestsList.Add(new Guest { Id = 1, UserId = 1, EventId = 1 });
            guestsList.Add(new Guest { Id = 2, UserId = 2, EventId = 1 });
            guestsList.Add(new Guest { Id = 3, UserId = 1, EventId = 2 });
            guestsList.Add(new Guest { Id = 4, UserId = 3, EventId = 3 });
            guestsList.Add(new Guest { Id = 5, UserId = 1, EventId = 3 });
            this.guests = guestsList.AsEnumerable();
        }

        public bool Create(Guest entity)
        {
            if (entity.Status == null || entity.EventId == 0 || entity.UserId == 0)
            {
                return false;
            }

            return true;
        }

        public Guest GetById(int id)
        {
            return null;
        }

        public IQueryable<Guest> GetAll()
        {
            return this.guests.AsQueryable();
        }

        public IEnumerable<Guest> GetGuestsByEventId(int eventId)
        {
            return this.guests.Where(guest => guest.EventId == eventId && string.Equals(guest.Status, "PENDING"));
        }

        public bool Exist(Guest entity)
        {
            return this.guests.Any(elem => elem.UserId == entity.UserId && elem.EventId == entity.EventId);
        }

        public IEnumerable<Guest> GetGuestsByUserId(int userId)
        {
            return this.guests.Where(guest => guest.UserId == userId && string.Equals(guest.Status, "PENDING"));
        }

        public IEnumerable<Guest> GetGuestsByUserIdAccepted(int userId)
        {
            return this.guests.Where(guest => guest.UserId == userId && string.Equals(guest.Status, "ACCEPTED"));
        }

        public bool UpdateStatusGuest(Guest entity)
        {
            return true;
        }

        public IEnumerable<Guest> GetEventsByUserId(int userId)
        {
            return this.guests.Where(guest => guest.UserId == userId && string.Equals(guest.Status, "PENDING"));
        }
    }
}
