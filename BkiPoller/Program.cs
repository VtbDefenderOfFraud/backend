using BkiPoller.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BkiPoller
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    services.AddDbContext<DefenderDbContext>(options =>
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefenderDbContext")));

                    services.AddDbContext<BkiDbContext>(options =>
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("BkiDbContext")));
                });
    }
}