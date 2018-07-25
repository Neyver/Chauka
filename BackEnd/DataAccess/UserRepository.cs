namespace DataAccess
{
    using System;
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

        public User GetUserByAccountName(string username)
        {
            return this.context.Users.FirstOrDefault(u => u.AccountName == username);
        }
    }
}
