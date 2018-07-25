namespace DataAccess
{
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
            context.SaveChanges();

            ////context.Events.Add(new Event() {}); 
        }
    }
}
