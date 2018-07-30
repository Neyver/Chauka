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

            var user2 = new User()
            {
                Name = "Juancito Pinto",
                AccountName = "juancito"
            };

            context.Users.Add(user);
            context.Users.Add(user1);
            context.Users.Add(user2);

            var event1 = new Event()
            {
                NameEvent = "Event1",
                StartDatetime = new DateTime(2018, 07, 25, 18, 00, 00, 00),
                EndDatetime = new DateTime(2018, 07, 25, 18, 00, 00, 00),
                UserId = 1,
                Longitude = -66.16181373596191,
                Latitude = -17.379228036179715
            };

            var event2 = new Event()
            {
                NameEvent = "Event2",
                StartDatetime = new DateTime(2018, 07, 24, 18, 00, 00, 00),
                EndDatetime = new DateTime(2018, 07, 24, 18, 00, 00, 00),
                UserId = 1,
                Longitude = -66.15511894226074,
                Latitude = -17.381030100202818
            };

            var event3 = new Event()
            {
                NameEvent = "Event3",
                StartDatetime = new DateTime(2018, 07, 25, 18, 00, 00, 00),
                EndDatetime = new DateTime(2018, 07, 25, 18, 00, 00, 00),
                UserId = 1,
                Longitude = -66.15340232849121,
                Latitude = -17.373535035574807
            };

            var event4 = new Event()
            {
                NameEvent = "Event4",
                StartDatetime = new DateTime(2018, 07, 25, 18, 00, 00, 00),
                EndDatetime = new DateTime(2018, 07, 25, 18, 00, 00, 00),
                UserId = 1,
                Longitude = -66.14131275079887,
                Latitude = -17.378066127011543
            };

            var event5 = new Event()
            {
                NameEvent = "Event5",
                StartDatetime = new DateTime(2018, 07, 25, 18, 00, 00, 00),
                EndDatetime = new DateTime(2018, 07, 25, 18, 00, 00, 00),
                UserId = 1,
                Longitude = -66.17550231653593,
                Latitude = -17.365956276431145
            };

            context.Events.Add(event1);
            context.Events.Add(event2);
            context.Events.Add(event3);
            context.Events.Add(event4);
            context.Events.Add(event5);

            context.Guests.Add(new Guest() { EventId = 1, UserId = 1, Status = "ACCEPTED" });
            context.Guests.Add(new Guest() { EventId = 1, UserId = 2, Status = "ACCEPTED" });
            context.Guests.Add(new Guest() { EventId = 2, UserId = 1, Status = "ACCEPTED" });
            context.Guests.Add(new Guest() { EventId = 2, UserId = 3, Status = "ACCEPTED" });
            context.Guests.Add(new Guest() { EventId = 3, UserId = 3, Status = "PENDING" });

            context.SaveChanges();
        }
    }
}
