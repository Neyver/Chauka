namespace DataAccess
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Model.Core;
    using Model.Object;

    public class UserRepository : IUserRepository<User>
    {
        private DatabaseContext context;

        public UserRepository()
        {
            this.context = new DatabaseContext();
        }

        public IQueryable<User> GetAll()
        {
            return this.context.Set<User>();
        }

        public User GetById(int id)
        {
            return this.context.Users.Find(id);
        }

        public User GetUserByAccountName(string username)
        {
            return this.context.Users.FirstOrDefault(u => u.AccountName == username);
        }

        public void Update(User user)
        {
            this.context.Users.Attach(user);
            DbEntityEntry<User> entry = this.context.Entry(user);
            entry.Property(e => e.Latitude).IsModified = true;
            entry.Property(e => e.Longitude).IsModified = true;
            this.context.SaveChanges();
        }
    }
}
