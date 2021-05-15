using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationClient;
using NotificationPusher.Data;

namespace NotificationPusher
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.RegisterNotificationClient(hostContext.Configuration.GetValue<string>("Files:FireBase"));

                    services.AddDbContext<DefenderDbContext>(options =>
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefenderDbContext")));
                });
    }
}