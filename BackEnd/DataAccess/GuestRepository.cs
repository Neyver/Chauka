namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model.Core;
    using Model.Object;

    public class GuestRepository : IGuestRepository<Guest>
    {
        private DatabaseContext context;

        public GuestRepository()
        {
            this.context = new DatabaseContext();
        }

        public bool Create(Guest entity)
        {
            try
            {
                this.context.Set<Guest>().Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public IQueryable<Guest> GetAll()
        {
            return this.context.Set<Guest>();
        }

        public Guest GetById(int id)
        {
            return this.context.Guests.Find(id);
        }

        public IEnumerable<Guest> GetGuestByEventId(int eventId)
        {
            var guest = this.context.Set<Guest>();
            return guest.Where(user => user.UserId == eventId);
        }
    }
}
