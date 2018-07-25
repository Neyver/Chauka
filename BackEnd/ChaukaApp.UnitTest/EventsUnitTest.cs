using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Object;
using Model.Result;

namespace ChaukaApp.UnitTest
{
    public class EventsUnitTest
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
    }
}
