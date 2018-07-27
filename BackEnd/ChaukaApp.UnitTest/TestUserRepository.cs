namespace ChaukaApp.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model.Core;
    using Model.Object;

    public class TestUserRepository : IUserRepository<User>
    {
        private List<User> entities = new List<User>();

        public TestUserRepository()
        {
            this.entities.Add(new User() { Id = 1, AccountName = "USR1", Name = "User1" });
            this.entities.Add(new User() { Id = 2, AccountName = "USR2", Name = "User2" });
            this.entities.Add(new User() { Id = 3, AccountName = "USR3", Name = "User3" });
        }

        private static IQueryable<User> Entities { get; set; }

        IQueryable<User> IRepository<User>.GetAll()
        {
            return Entities;
        }

        public User GetById(int id)
        {
            return this.entities.Find(elem => elem.Id == id);
        }

        public User GetUserByAccountName(string accountName)
        {
            User user = this.entities.Find(element => element.AccountName == accountName);
            return user;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
