using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace DotNetCoreApp
{
    public class Program
    {
        private static object hostingcontext;

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingcontext, Logger) =>
                {
                    Logger.AddConfiguration(hostingcontext.Configuration.GetSection("Logging"));
                    Logger.AddConsole();
                    Logger.AddDebug();
                    Logger.AddEventSourceLogger();
                    Logger.AddNLog();

                })
                .UseStartup<Startup>();
    }
}
