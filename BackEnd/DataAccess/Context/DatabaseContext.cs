namespace DataAccess
{
    using System.Data.Entity;
    using Model.Object;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=ChaukaContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Guest> Guests { get; set; }
    }
}
