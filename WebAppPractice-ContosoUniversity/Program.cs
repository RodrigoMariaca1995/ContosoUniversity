using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPractice_ContosoUniversity.Data;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppPractice_ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        //The EnsureCreated method takes no action if a database for the context exists.If no database exists, it creates the database and schema.
        //This workflow works early in development when the schema is rapidly evolving, as long as data doesn't need to be preserved.
        //The situation is different when data that has been entered into the database needs to be preserved. When that is the case, use migrations.
        private static void CreateDbIfNotExists(IHost host) 
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    //context.Database.EnsureCreated(); used for testing or rapid prototyping where the database is dropped and re-created frequently. Cannot be used with migration
                    DbInitializer.Initialize(context); //calls the DbInitializer class in the Data folder to check if the database has any data. If not, adds dummy data.
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
