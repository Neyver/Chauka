namespace ChaukaApp.ServiceAPI
{
    using System;
    using BusinessLogic;
    using Microsoft.Owin.Hosting;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            string baseAddress = "http://localhost:5387/";
            DbConnection.DbStartUp();

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Service started at {baseAddress}");
                Console.ReadLine();
            }
        }
    }
}
