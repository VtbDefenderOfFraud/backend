using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.MemoryJoin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotificationPusher.Data;

namespace NotificationPusher
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceScopeFactory serviceScopeFactory, ILogger<Worker> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                try
                {
                    using var scope = _serviceScopeFactory.CreateScope();

                    var defenderDbContext = scope.ServiceProvider.GetRequiredService<DefenderDbContext>();

                    var pushes = await defenderDbContext.Pushes.Include(p => p.User).Where(p => p.Pushed == null)
                        .ToListAsync(stoppingToken);

                    if (pushes.Count > 0)
                    {
                        var usersWithMinSince =
                            pushes.GroupBy(p => p.UserId).SelectMany(g => g.Where(x => x.Since == g.Min(y => y.Since)))
                                .Select(s => new {s.UserId, s.Since})
                                .ToList();

                        var userWithMinSinceForQuery = defenderDbContext.FromLocalList(usersWithMinSince);

                        var creditRequestsForPushQuery =
                            from creditRequest in defenderDbContext.CreditRequests.AsNoTracking()
                            join userWithMinSince in userWithMinSinceForQuery on creditRequest.UserId equals
                                userWithMinSince.UserId
                            where creditRequest.OrderDate >= userWithMinSince.Since
                            select creditRequest;

                        var creditRequestsForPush = await creditRequestsForPushQuery.ToListAsync(stoppingToken);

                        foreach (var userCreditRequests in creditRequestsForPush.GroupBy(cr => cr.UserId))
                        {
                            var userId = userCreditRequests.Key;

                            var phone = pushes.First(x => x.UserId == userCreditRequests.Key).User.Phone;

                            // todo push
                            _logger.LogInformation("Push done to {Phone} with {CreditRequestsCount}", phone,
                                userCreditRequests.Count());


                            foreach (var push in pushes.Where(p => p.UserId == userId))
                                push.Pushed = push.Updated = DateTime.Now;
                        }

                        await defenderDbContext.SaveChangesAsync(stoppingToken);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Error");
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}