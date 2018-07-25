﻿namespace DataAccess
{
    using System;
    using System.Data.Entity;
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

            context.Users.Add(user);

            var event1 = new Event()
            {
                NameEvent = "Event1",
                StartDatetime = DateTime.Parse("28/07/2018 14:00"),
                UserId = 1
            };

            var event2 = new Event()
            {
                NameEvent = "Event2",
                StartDatetime = DateTime.Parse("26/07/2018 08:00"),
                UserId = 1
            };

            context.Events.Add(event1); 
            context.Events.Add(event2);

            context.SaveChanges();
        }
    }
}
