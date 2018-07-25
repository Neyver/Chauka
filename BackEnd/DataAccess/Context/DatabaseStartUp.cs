namespace DataAccess
{
    using System.Data.Entity;

    public static class DatabaseStartUp
    {
        public static void SetInitializer()
        {
            Database.SetInitializer(new DatabaseInitializer());
            using (var context = new DatabaseContext())
            {
                context.Database.Initialize(force: true);
            }
        }
    }
}
