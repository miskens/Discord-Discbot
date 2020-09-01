using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MiskDiscBot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Resources;
using MiskDiscBot.Properties;
using Microsoft.EntityFrameworkCore;

namespace MiskDiscBot
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Resources.ResourceManager.GetString("DGSqlConnString");
            services.AddDbContext<DiscGolfContext>(options =>
            {
                options.UseSqlServer(connString,
                    x => x.MigrationsAssembly("MiskDiscBot.DAL.Migrations"));
            });
            
            var serviceProvider = services.BuildServiceProvider();

            var miskDiscBot = new MiskDiscBot(serviceProvider);
            services.AddSingleton(miskDiscBot);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
