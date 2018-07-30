namespace ChaukaApp.UnitTest
{
    using System;
    using System.Linq;
    using BusinessLogic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model.Object;
    using Model.Result;

    [TestClass]
    public class EventHostUnitTest
    {
        #region Test Get Events User
        [TestMethod]
        public void TestGetUserEventsWhenUserNotExistsRepositoryReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            IResult<UserEvent> result = eventHost.GetUserEvents(10);
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("User not found", result.Message);
        }

        [TestMethod]
        public void TestGetUserEventsWhenInvalidFormatIdReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            IResult<UserEvent> result = eventHost.GetUserEvents(0);
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("The user ID is not valid", result.Message);
        }

        [TestMethod]
        public void TestGetUserEventsWhenExistsEventsReturnIResultWithSuccessTrue()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            IResult<UserEvent> result = eventHost.GetUserEvents(1);
            Assert.AreEqual(true, result.Success);
            Assert.IsTrue(result.Data.Events.Count() > 0);
        }

        [TestMethod]
        public void TestGetUserEventsWhenNotExistsEventsByUserReturnIResultWithSuccessTrueEmpptyList()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            IResult<UserEvent> result = eventHost.GetUserEvents(3);
            Assert.AreEqual(true, result.Success);
            Assert.IsTrue(result.Data.Events.Count() == 0);
        }
        #endregion

        #region Test Get Event
        [TestMethod]
        public void TestGetEventWhenEventDoesNotExistsRepositoryReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.EventRepository = new TestEventsRepository();
            IResult<Event> result = eventHost.GetEvent(15);
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("Event not found", result.Message);
        }

        [TestMethod]
        public void TestGetEventWhenInvalidEventIdReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.EventRepository = new TestEventsRepository();
            IResult<Event> result = eventHost.GetEvent(0);
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("The event ID is not valid", result.Message);
        }

        [TestMethod]
        public void TestGetEventWhenEventExistReturnIResultWithSuccessTrue()
        {
            IEventHost eventHost = new EventHost();
            eventHost.EventRepository = new TestEventsRepository();
            IResult<Event> result = eventHost.GetEvent(1);
            Assert.AreEqual(true, result.Success);
        }
        #endregion

        #region Test Register Event
        [TestMethod]
        public void TestRegisterEventWhenExceptionAppearsReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            ResultSimplified result = eventHost.RegisterEvent(new Event()
            {
                UserId = 10,
                NameEvent = "New Event",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0),
            });
            Assert.AreEqual(result.Success, false);
            Assert.AreEqual(result.Message, "Interal Exception: No connection string named 'ChaukaContext' could be found in the application config file.");
        }

        [TestMethod]
        public void TestRegisterEventWhenUserRepositoryIsNullReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = null;
            eventHost.EventRepository = new TestEventsRepository();
            ResultSimplified result = eventHost.RegisterEvent(new Event()
            {
                UserId = 10,
                NameEvent = "New Event",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0),
            });
            Assert.AreEqual(result.Success, false);
            Assert.AreEqual(result.Message, "Interal Exception: Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void TestRegisterEventWhenRepositortesAreNullReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = null;
            eventHost.EventRepository = null;
            ResultSimplified result = eventHost.RegisterEvent(new Event()
            {
                UserId = 1,
                NameEvent = "New Event",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0)
            });
            Assert.AreEqual(result.Success, false);
            Assert.AreEqual(result.Message, "It is not possible to access the data service.");
        }

        [TestMethod]
        public void TestRegisterEventWhenEventIsNullReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            ResultSimplified result = eventHost.RegisterEvent(null);
            Assert.AreEqual(result.Success, false);
            Assert.AreEqual(result.Message, "The register of the Event can not be created.");
        }

        [TestMethod]
        public void TestRegisterEventWhenUserIdIsNullReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            ResultSimplified result = eventHost.RegisterEvent(new Event()
            {
                UserId = 0,
                NameEvent = "New Event",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0)
            });
            Assert.AreEqual(result.Success, false);
            Assert.AreEqual(result.Message, "The User Id can not be empty.");
        }

        [TestMethod]
        public void TestRegisterEventWhenUserIdIsNegativeReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            ResultSimplified result = eventHost.RegisterEvent(new Event()
            {
                UserId = -1,
                NameEvent = "New Event",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0)
            });
            Assert.AreEqual(result.Success, false);
            Assert.AreEqual(result.Message, "The User Id can not be negative.");
        }

        [TestMethod]
        public void TestRegisterEventWhenUserNotExistsRepositoryReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            ResultSimplified result = eventHost.RegisterEvent(new Event()
            {
                UserId = 10,
                NameEvent = "New Event",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0)
            });
            Assert.AreEqual(result.Success, false);
            Assert.AreEqual(result.Message, "The User can not be found.");
        }

        [TestMethod]
        public void TestRegisterEventWhenEventNameIsEmptyReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            ResultSimplified result = eventHost.RegisterEvent(new Event()
            {
                UserId = 1,
                NameEvent = string.Empty,
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0)
            });
            Assert.AreEqual(result.Success, false);
            Assert.AreEqual(result.Message, "The Event name must not be empty.");
        }

        [TestMethod]
        public void TestRegisterEventWhenEventIsValidWithoutEndDatatimeReturnIResultWithSuccessTrue()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            Event newEvent = new Event()
            {
                UserId = 1,
                NameEvent = "New Event",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0)
            };
            ResultSimplified result = eventHost.RegisterEvent(newEvent);
            Assert.AreEqual(result.Success, true);
            Assert.AreEqual(result.Message, "The Event was successfully registered.");
        }

        [TestMethod]
        public void TestRegisterEventWhenEventIsValidWithEndDatatimeReturnIResultWithSuccessTrue()
        {
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();

            Event newEvent = new Event()
            {
                UserId = 1,
                NameEvent = "New Event",
                StartDatetime = new DateTime(2018, 05, 24, 14, 30, 0),
                EndDatetime = new DateTime(2018, 05, 24, 14, 30, 0),
            };

            ResultSimplified result = eventHost.RegisterEvent(newEvent);
            Assert.AreEqual(result.Success, true);
            Assert.AreEqual(result.Message, "The Event was successfully registered.");
        }
        #endregion

        #region Test Get Guest List
        [TestMethod]
        public void TestGetGuestListWhenExceptionAppearsReturnEventIdIsNotValid()
        {
            IResult<EventGuests> resultEvent = new ResultEntity<EventGuests>();
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            eventHost.GuestRepository = new TestGuestRepository();
            resultEvent = eventHost.GetGuestList(-1);
            Assert.AreEqual(resultEvent.Message, "Event ID is not valid.");
            Assert.AreEqual(resultEvent.Success, false);
        }

        [TestMethod]
        public void TestGuestListWhenExceptionAppearsReturnEventNotfound()
        {
            IResult<EventGuests> resultEvent = new ResultEntity<EventGuests>();
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            eventHost.GuestRepository = new TestGuestRepository();
            resultEvent = eventHost.GetGuestList(10);
            Assert.AreEqual(resultEvent.Message, "Event not found.");
            Assert.AreEqual(resultEvent.Success, false);
        }

        [TestMethod]
        public void TestGuestListWhenReturnSuccesfulData()
        {
            IResult<EventGuests> resultEvent = new ResultEntity<EventGuests>();
            IEventHost eventHost = new EventHost();
            eventHost.Repository = new TestUserRepository();
            eventHost.EventRepository = new TestEventsRepository();
            eventHost.GuestRepository = new TestGuestRepository();
            resultEvent = eventHost.GetGuestList(1);
            Assert.AreEqual(resultEvent.Message, "Successful Data.");
            Assert.AreEqual(resultEvent.Success, true);
        }
        #endregion
    }
}
