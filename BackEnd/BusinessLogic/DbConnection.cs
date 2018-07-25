namespace BusinessLogic
{
    using DataAccess;

    public static class DbConnection
    {
        public static void DbStartUp()
        {
            DatabaseStartUp.SetInitializer();
        }
    }
}
