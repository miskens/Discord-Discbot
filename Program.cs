using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MiskDiscBot.DAL;
using System;

namespace MiskDiscBot
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bot = new MiskDiscBot();
            //bot.RunAsync().GetAwaiter().GetResult();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(WebHostBuilder =>
        {
            WebHostBuilder.UseStartup<Startup>();
        });
    }
}
