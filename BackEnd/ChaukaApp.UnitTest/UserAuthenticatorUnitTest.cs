namespace ChaukaApp.UnitTest
{
    using BusinessLogic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model.Object;
    using Model.Result;

    [TestClass]
    public class UserAuthenticatorUnitTest
    {
        #region Test User autentication 
        [TestMethod]
        public void TestAuthenticationWhenUserNotExistReturnIResultWithSuccessFalse()
        {
            IUserAuthenticator verifier = new UserAuthenticator();
            verifier.Repository = new TestUserRepository();
            IResult<Account> result = verifier.Authentication("USR4");
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("User not found", result.Message);
        }

        [TestMethod]
        public void TestAuthenticationWhenUserExistReturnIResultWithSuccessTrue()
        {
            IUserAuthenticator verifier = new UserAuthenticator();
            verifier.Repository = new TestUserRepository();
            IResult<Account> result = verifier.Authentication("USR1");
            Assert.AreEqual(true, result.Success);
            Assert.AreEqual("Successful sign in", result.Message);
        }

        [TestMethod]
        public void TestAuthenticationWhenAccountNameIsEmptyReturnIResultWithSuccessFalse()
        {
            IUserAuthenticator verifier = new UserAuthenticator();
            verifier.Repository = new TestUserRepository();
            IResult<Account> result = verifier.Authentication(string.Empty);
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("The account name must not be empty", result.Message);
        }

        [TestMethod]
        public void TestAuthenticationWhenRepositoryIsNullReturnIResultWithSuccessFalse()
        {
            IUserAuthenticator verifier = new UserAuthenticator();
            verifier.Repository = null;
            IResult<Account> result = verifier.Authentication("USR1");
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("It is not possible to access the data service", result.Message);
        }
        #endregion
    }
}
