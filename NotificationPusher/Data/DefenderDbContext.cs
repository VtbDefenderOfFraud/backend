using Microsoft.EntityFrameworkCore;
using NotificationPusher.Data.Model;

namespace NotificationPusher.Data
{
    public class DefenderDbContext : DbContext
    {
        public DefenderDbContext(DbContextOptions<DefenderDbContext> options) : base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Push> Pushes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CreditRequest> CreditRequests { get; set; }

        protected DbSet<EntityFrameworkCore.MemoryJoin.QueryModelClass> QueryData { get; set; }
    }
}