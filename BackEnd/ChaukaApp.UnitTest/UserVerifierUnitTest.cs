namespace ChaukaApp.UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using BusinessLogic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model.Core;
    using Model.Object;
    using Model.Result;

    [TestClass]
    public class UserVerifierUnitTest
    {
        #region Test User autentication 
        [TestMethod]
        public void TestAuthenticationWhenUserNotExistReturnIResultWithSuccessFalse()
        {
            IEventHost verifier = new EventHost();
            verifier.Repository = new TestUserRepository();
            IResult<Account> result = verifier.Authentication("USR4");
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("User not found", result.Message);
        }

        [TestMethod]
        public void TestAuthenticationWhenUserExistReturnIResultWithSuccessTrue()
        {
            IEventHost verifier = new EventHost();
            verifier.Repository = new TestUserRepository();
            IResult<Account> result = verifier.Authentication("USR1");
            Assert.AreEqual(true, result.Success);
            Assert.AreEqual("Successful sign in", result.Message);
        }

        [TestMethod]
        public void TestAuthenticationWhenAccountNameIsEmptyReturnIResultWithSuccessFalse()
        {
            IEventHost verifier = new EventHost();
            verifier.Repository = new TestUserRepository();
            IResult<Account> result = verifier.Authentication(string.Empty);
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("The account name must not be empty", result.Message);
        }

        [TestMethod]
        public void TestAuthenticationWhenRepositoryIsNullReturnIResultWithSuccessFalse()
        {
            IEventHost verifier = new EventHost();
            verifier.Repository = null;
            IResult<Account> result = verifier.Authentication("USR1");
            Assert.AreEqual(false, result.Success);
            Assert.AreEqual("It is not possible to access the data service", result.Message);
        }
        #endregion

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

        #region Test Register Event
        [TestMethod]
        public void TestRegisterEventWhenExceptionAppearsReturnIResultWithSuccessFalse()
        {
            IEventHost eventHost = new EventHost();
            ResultSimplified result = eventHost.RegisterEvent(new Event()
            {
                UserId = 10,
                NameEvent = "New Event",
                StartDatetime = DateTime.Parse("07/28/2018 14:00", new CultureInfo("en-US")),
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
                StartDatetime = DateTime.Parse("07/28/2018 14:00", new CultureInfo("en-US")),
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
                StartDatetime = DateTime.Parse("07/28/2018 14:00", new CultureInfo("en-US")),
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
                StartDatetime = DateTime.Parse("07/28/2018 14:00", new CultureInfo("en-US")),
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
                StartDatetime = DateTime.Parse("07/28/2018 14:00", new CultureInfo("en-US")),
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
                StartDatetime = DateTime.Parse("07/28/2018 14:00", new CultureInfo("en-US")),
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
                StartDatetime = DateTime.Parse("07/28/2018 14:00", new CultureInfo("en-US")),
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
                StartDatetime = DateTime.Parse("07/28/2018 14:00", new CultureInfo("en-US")),
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
                StartDatetime = DateTime.Parse("07/28/2018 14:00", new CultureInfo("en-US")),
                EndDatetime = DateTime.Parse("07/28/2018 19:00", new CultureInfo("en-US")),
            };

            ResultSimplified result = eventHost.RegisterEvent(newEvent);
            Assert.AreEqual(result.Success, true);
            Assert.AreEqual(result.Message, "The Event was successfully registered.");
        }
        #endregion
    }

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

    public class TestEventsRepository : IEventsRepository<Event>
    {
        private List<Event> entities = new List<Event>();

        public TestEventsRepository()
        {
            this.entities.Add(new Event()
            {
                NameEvent = "Event1",
                StartDatetime = DateTime.Parse("07/08/2018 14:00", new CultureInfo("en-US")),
                UserId = 1
            });

            this.entities.Add(new Event()
            {
                NameEvent = "Event2",
                StartDatetime = DateTime.Parse("07/26/2018 08:00", new CultureInfo("en-US")),
                UserId = 1
            });

            this.entities.Add(new Event()
            {
                NameEvent = "Event3",
                StartDatetime = DateTime.Parse("07/26/2018 08:00", new CultureInfo("en-US")),
                UserId = 1
            });
        }

        private static IQueryable<Event> Entities { get; set; }

        public bool Add(Event eventObject)
        {
            this.entities.Add(eventObject);
            return true;
        }

        public IQueryable<Event> GetAll()
        {
            return null;
        }

        public Event GetById(int id)
        {
            return this.entities.Find(elem => elem.Id == id);
        }

        public IEnumerable<Event> GetEventsByUserId(int userId)
        {
            List<Event> events = this.entities.FindAll(elem => elem.UserId == userId);
            return events;
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
