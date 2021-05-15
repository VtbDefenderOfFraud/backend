using DefenderUiGateway.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DefenderUiGateway.Data
{
    public class DefenderDbContext : DbContext
    {
        public DefenderDbContext(DbContextOptions<DefenderDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<CreditRequest> CreditRequests { get; set; }

        public DbSet<UserLastPolling> UsersLastPolling { get; set; }

        public DbSet<Push> Pushes { get; set; }
    }
}