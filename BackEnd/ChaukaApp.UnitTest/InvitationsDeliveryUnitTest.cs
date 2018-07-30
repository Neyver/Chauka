﻿namespace ChaukaApp.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BusinessLogic;
    using Model.Object;
    using Model.Result;

    [TestClass]
    public class UnitTest1
    {
        #region test get invitations
        [TestMethod]
        public void TestGetInvitationsWhenUserIdIsNegativeReturnUserIdIsNotValid()
        {
            IResult<Event> resultEvent = new ResultEntity<Event>();
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
            IResult<Event> resultEvent = new ResultEntity<Event>();
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
            IResult<Event> resultEvent = new ResultEntity<Event>();
            IInvitationsDelivery invitationsDelivery = new InvitationsDelivery();
            invitationsDelivery.UserRepository = new TestUserRepository();
            invitationsDelivery.EventRepository = new TestEventsRepository();
            invitationsDelivery.GuestRepository = new TestGuestRepository();
            resultEvent = invitationsDelivery.GetInvitations(1);
            Assert.AreEqual(resultEvent.Message, "Successful Data.");
            Assert.AreEqual(resultEvent.Success, true);
        }
        #endregion
    }
}