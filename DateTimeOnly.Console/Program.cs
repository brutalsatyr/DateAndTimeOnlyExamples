using DateTimeOnly.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeOnly.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<TestDbContext>(options =>
                        {
                            options.UseSqlServer(hostContext.Configuration.GetValue<string>("DatabaseConnectionString"));
                        },ServiceLifetime.Singleton);
                    services.AddHostedService<Worker>();
                });
    }
}
