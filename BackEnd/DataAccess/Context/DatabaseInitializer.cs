namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Globalization;
    using Model.Object;

    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            var user = new User()
            {
                Name = "Steve Jobs",
                AccountName = "steve"
            };

            var user1 = new User()
            {
                Name = "Steve Jobs 2",
                AccountName = "steve2"
            };

            context.Users.Add(user);
            context.Users.Add(user1);

            var event1 = new Event()
            {
                NameEvent = "Event1",
                StartDatetime = DateTime.Parse("07/28/2018 14:00", new CultureInfo("en-US")),
                EndDatetime = DateTime.Parse("07/28/2018 21:00", new CultureInfo("en-US")),
                UserId = 1
            };

            var event2 = new Event()
            {
                NameEvent = "Event2",
                StartDatetime = DateTime.Parse("07/26/2018 08:00", new CultureInfo("en-US")),
                EndDatetime = DateTime.Parse("07/26/2018 17:00", new CultureInfo("en-US")),
                UserId = 1
            };

            var event3 = new Event()
            {
                NameEvent = "Event3",
                StartDatetime = DateTime.Parse("07/26/2018 08:00", new CultureInfo("en-US")),
                EndDatetime = DateTime.Parse("07/26/2018 17:00", new CultureInfo("en-US")),
                UserId = 1
            };

            var event4 = new Event()
            {
                NameEvent = "Event4",
                StartDatetime = DateTime.Parse("26/07/2018 08:00", new CultureInfo("en-US")),
                EndDatetime = DateTime.Parse("26/07/2018 17:00", new CultureInfo("en-US")),
                UserId = 1
            };

            var event5 = new Event()
            {
                NameEvent = "Event5",
                StartDatetime = DateTime.Parse("07/26/2018 14:00", new CultureInfo("en-US")),
                EndDatetime = DateTime.Parse("07/28/2018 21:00", new CultureInfo("en-US")),
                UserId = 1
            };

            context.Events.Add(event1);
            context.Events.Add(event2);
            context.Events.Add(event3);
            context.Events.Add(event4);
            context.Events.Add(event5);

            context.SaveChanges();
        }
    }
}
