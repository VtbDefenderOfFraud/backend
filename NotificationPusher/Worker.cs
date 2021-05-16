using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.MemoryJoin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NotificationClient;
using NotificationPusher.Data;
using NotificationPusher.Model;

namespace NotificationPusher
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<Worker> _logger;
        private readonly INotificationClient _notificationClient;

        public Worker(IServiceScopeFactory serviceScopeFactory, ILogger<Worker> logger,
            INotificationClient notificationClient)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
            _notificationClient = notificationClient;
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
                            from creditRequest in defenderDbContext.CreditRequests.AsNoTracking().Include(r => r.Bank)
                            join userWithMinSince in userWithMinSinceForQuery on creditRequest.UserId equals
                                userWithMinSince.UserId
                            where creditRequest.OrderDate >= userWithMinSince.Since
                            select creditRequest;

                        var creditRequestsForPush = await creditRequestsForPushQuery.ToListAsync(stoppingToken);

                        foreach (var userCreditRequests in creditRequestsForPush.GroupBy(cr => cr.UserId))
                        {
                            var userId = userCreditRequests.Key;

                            var user = pushes.First(x => x.UserId == userCreditRequests.Key).User;

                            var creditsCount = userCreditRequests.Count();

                            var isMoreThenOneCredit = creditsCount > 1;

                            var firstCredit = userCreditRequests.First();

                            var pushMessage = new PushMessage
                            {
                                BankName = firstCredit.Bank.Name,
                                BankIcoUrl = firstCredit.Bank.IcoUrl,
                                OrderDate = firstCredit.OrderDate,
                                TotalSum = firstCredit.Amount,
                                Text = isMoreThenOneCredit
                                    ? $"На ваше имя взято более одного кредита: {creditsCount} шт!"
                                    : "На ваше имя взят кредит! Это были вы?"
                            };

                            var pushTitle = isMoreThenOneCredit
                                ? "Обнаружены новые кредиты!"
                                : "Обнаружен новый кредит!";

                            var pushMessageString = JsonConvert.SerializeObject(pushMessage);

                            await _notificationClient.SendAsync(new[] {user.Token}, pushTitle, pushMessageString);

                            _logger.LogInformation("Push done to {Phone}, total credits: {Count} with message {Message}", user.Phone,
                                creditsCount, pushMessageString);


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