namespace ChaukaApp.UnitTest
{
    using System.Collections.Generic;
    using System.Linq;
    using BusinessLogic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model.Core;
    using Model.Object;
    using Model.Result;
    
    [TestClass]
    public class UserVerifierUnitTest
    {
        [TestMethod]
        public void TestAuthenticationWhenUserNotExistReturnIResultWithSuccessFalse()
        {
            IUserVerifier verifier = new UserVerifier();
            verifier.Repository = new TestUserRepository();
            IResult<Account> result = verifier.Authentication("USR2");
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("User not found", result.Message);
        }

        [TestMethod]
        public void TestAuthenticationWhenUserExistReturnIResultWithSuccessTrue()
        {
            IUserVerifier verifier = new UserVerifier();
            verifier.Repository = new TestUserRepository();
            IResult<Account> result = verifier.Authentication("USR1");
            Assert.AreEqual(true, result.Success);
            Assert.AreEqual("Successful sign in", result.Message);
        }

        [TestMethod]
        public void TestAuthenticationWhenAccountNameIsEmptyReturnIResultWithSuccessFalse()
        {
            IUserVerifier verifier = new UserVerifier();
            verifier.Repository = new TestUserRepository();
            IResult<Account> result = verifier.Authentication(string.Empty);
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("The account name must not be empty", result.Message);
        }

        [TestMethod]
        public void TestAuthenticationWhenRepositoryIsNullReturnIResultWithSuccessFalse()
        {
            IUserVerifier verifier = new UserVerifier();
            IResult<Account> result = verifier.Authentication("USR1");
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("It is not possible to access the data service", result.Message);
        }
    }

    public class TestUserRepository : IUserRepository<User>
    {
        private List<User> entities = new List<User>();

        public TestUserRepository()
        {
            this.entities.Add(new User() { AccountName = "USR1", Name = "User1" });
        }

        private static IQueryable<User> Entities { get; set; }

        IQueryable<User> IRepository<User>.GetAll()
        {
            return Entities;
        }

        public User GetUserByAccountName(string accountName)
        {
            User user = this.entities.Find(element => element.AccountName == accountName);
            return user;
        }
    }
}
