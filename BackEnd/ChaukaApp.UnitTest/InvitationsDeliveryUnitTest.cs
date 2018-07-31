namespace ChaukaApp.UnitTest
{
    using BusinessLogic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model.Object;
    using Model.Result;

    [TestClass]
    public class UnitTest1
    {
        #region test get invitations
        [TestMethod]
        public void TestGetInvitationsWhenUserIdIsNegativeReturnUserIdIsNotValid()
        {
            IResult<UserEvent> resultEvent = new ResultEntity<UserEvent>();
            IInvitationsDelivery invitationsDelivery = new InvitationsDelivery();
            invitationsDelivery.UserRepository = new TestUserRepository();
            invitationsDelivery.EventRepository = new TestEventsRepository();
            invitationsDelivery.GuestRepository = new TestGuestRepository();
            resultEvent = invitationsDelivery.GetInvitations(-1);
            Assert.AreEqual(resultEvent.Message, "The user ID is not valid.");
            Assert.AreEqual(resultEvent.Success, false);
        }

        [TestMethod]
        public void TestGetInvitationsWhenUserIdNotExistReturnUserNotfound()
        {
            IResult<UserEvent> resultEvent = new ResultEntity<UserEvent>();
            IInvitationsDelivery invitationsDelivery = new InvitationsDelivery();
            invitationsDelivery.UserRepository = new TestUserRepository();
            invitationsDelivery.EventRepository = new TestEventsRepository();
            invitationsDelivery.GuestRepository = new TestGuestRepository();
            resultEvent = invitationsDelivery.GetInvitations(10);
            Assert.AreEqual(resultEvent.Message, "User not found.");
            Assert.AreEqual(resultEvent.Success, false);
        }

        [TestMethod]
        public void TestGetInvitationsWhenUserIdIsValidReturnSuccesfulData()
        {
            IResult<UserEvent> resultEvent = new ResultEntity<UserEvent>();
            IInvitationsDelivery invitationsDelivery = new InvitationsDelivery();
            invitationsDelivery.UserRepository = new TestUserRepository();
            invitationsDelivery.EventRepository = new TestEventsRepository();
            invitationsDelivery.GuestRepository = new TestGuestRepository();
            resultEvent = invitationsDelivery.GetInvitations(1);
            Assert.AreEqual(resultEvent.Message, "Successful Data.");
            Assert.AreEqual(resultEvent.Success, true);
        }
        #endregion

        #region Change Invitation Reponse
        [TestMethod]
        public void TestChangeInvitationReponseWhenGuestIdIsNegativeReturnGuestIdIsNotValid()
        {
            ResultSimplified result = new ResultSimplified();
            IInvitationsDelivery invitationsDelivery = new InvitationsDelivery();
            invitationsDelivery.GuestRepository = new TestGuestRepository();

            var guest = new Guest() { Id=-1, UserId=1, EventId=1, Status= "ACCEPTED" };
            result = invitationsDelivery.ChangeInvitationReponse(guest);

            Assert.AreEqual(result.Message, "The guest ID is not valid.");
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void TestChangeInvitationReponseWhenGuestStatusNotVaildReturnResponseNotValid()
        {
            ResultSimplified result = new ResultSimplified();
            IInvitationsDelivery invitationsDelivery = new InvitationsDelivery();
            invitationsDelivery.GuestRepository = new TestGuestRepository();

            var guest = new Guest() { Id = 1, UserId = 1, EventId = 1, Status = "" };
            result = invitationsDelivery.ChangeInvitationReponse(guest);

            Assert.AreEqual(result.Message, "The response is not valid.");
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void TestChangeInvitationReponseWhenChangeIsValidReturnResponseUpdated()
        {
            ResultSimplified result = new ResultSimplified();
            IInvitationsDelivery invitationsDelivery = new InvitationsDelivery();
            invitationsDelivery.GuestRepository = new TestGuestRepository();

            var guest = new Guest() { Id = 1, UserId = 1, EventId = 1, Status = "ACCEPTED" };
            result = invitationsDelivery.ChangeInvitationReponse(guest);

            Assert.AreEqual(result.Message, "Response updated.");
            Assert.AreEqual(result.Success, true);
        }
        #endregion
    }
}