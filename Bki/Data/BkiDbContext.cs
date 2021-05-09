using Bki.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Bki.Data
{
    public class BkiDbContext : DbContext
    {
        public BkiDbContext(DbContextOptions<BkiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().HasData(
                new Bank
                {
                    Id = 1,
                    Name = "СберБанк",
                }, new Bank
                {
                    Id = 2,
                    Name = "Тинькофф",
                });
        }

        public DbSet<LoanRequest> LoanRequests { get; set; }

        public DbSet<Bank> Banks { get; set; }
    }
}