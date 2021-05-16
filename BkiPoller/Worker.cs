using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BkiPoller.Data;
using BkiPoller.Data.Model.Bki;
using BkiPoller.Data.Model.Defender;
using EntityFrameworkCore.MemoryJoin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BkiPoller
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

                    var usersLastPollings = await defenderDbContext.UsersLastPolling.ToListAsync(stoppingToken);

                    var (newCredits, lastPolled) = await GetNewCreditsAsync(scope, usersLastPollings, stoppingToken);

                    await AddNewCredits(defenderDbContext, newCredits, stoppingToken);

                    UpdateLastPolled(usersLastPollings, lastPolled);

                    await defenderDbContext.SaveChangesAsync(stoppingToken);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Error");
                }

                await Task.Delay(5000, stoppingToken);
            }
        }

        private async Task AddNewCredits(DefenderDbContext defenderDbContext, ICollection<Credit> newCredits,
            CancellationToken cancellationToken)
        {
            if (newCredits.Count == 0) return;

            foreach (var newCredit in newCredits)
            {
                var userId = (await defenderDbContext.Users.Where(u => u.Passport == newCredit.Passport)
                    .SingleOrDefaultAsync(cancellationToken))?.Id;

                if (userId == null) continue;

                if (defenderDbContext.CreditRequests.Any(c => c.BkiId == newCredit.Id))
                {
                    _logger.LogInformation($"Credit with BkiId {newCredit.Id} already added. Skip.");

                    continue;
                }

                defenderDbContext.CreditRequests.Add(new CreditRequest
                {
                    BankId = newCredit.BankId,
                    BkiId = newCredit.Id,
                    OrderDate = newCredit.Created,
                    UserId = userId.Value,
                    Amount = newCredit.Amount,
                });

                defenderDbContext.Pushes.Add(new Push
                {
                    UserId = userId.Value,
                    Since = TruncateMilliseconds(newCredit.Created),
                });

                _logger.LogInformation("New credit request added");
            }
        }

        private static DateTime TruncateMilliseconds(DateTime dateTime) =>
            dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond));

        private static void UpdateLastPolled(IEnumerable<UserLastPolling> usersLastPollings, DateTime lastPolled)
        {
            foreach (var userLastPolling in usersLastPollings)
            {
                userLastPolling.Updated = DateTime.Now;
                userLastPolling.LastPolled = lastPolled;
            }
        }

        private static async Task<(IList<Credit> Credits, DateTime lastPolled)> GetNewCreditsAsync(
            IServiceScope scope,
            IList<UserLastPolling> usersLastPollings,
            CancellationToken cancellationToken)
        {
            var newLastPolled = DateTime.Now;

            var bkiDbContext = scope.ServiceProvider.GetRequiredService<BkiDbContext>();

            var usersLastPollingsBki = bkiDbContext.FromLocalList(usersLastPollings);

            var query = from credit in bkiDbContext.Credits.AsNoTracking()
                join userCreditSince in usersLastPollingsBki on credit.Passport equals userCreditSince.Passport
                where credit.Created > userCreditSince.LastPolled && credit.Created < newLastPolled
                select credit;

            return (await query.ToListAsync(cancellationToken), newLastPolled);
        }
    }
}