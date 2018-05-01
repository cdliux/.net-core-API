using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VIC.DataAccess.Config;
using VIC.DataAccess.MSSql;

namespace New3C_API
{
    public class Program
    {
        private static string currentDirectory = Directory.GetCurrentDirectory();
        private static string dbDirectory = Path.Combine(currentDirectory, "DB");
        private static string[] dbFileList = { "Item.xml", "User.xml" };

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        private static void InitDB(IServiceCollection services)
        {
            services.UseDataAccess()
            .UseDataAccessConfig(dbDirectory, false, null, dbFileList);
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseContentRoot(currentDirectory)
        .ConfigureServices(services => InitDB(services))
        .UseStartup<Startup>()
        .Build();
    }
}
