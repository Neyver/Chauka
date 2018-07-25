namespace DataAccess
{
    using System.Data.Entity;
    using Model;
    using Model.Object;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=ChaukaContext")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
