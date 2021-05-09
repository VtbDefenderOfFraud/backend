using Bki.Model.Data;
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
                    Name = "МФО \"Копеечка онлайн\"",
                },
                new Bank
                {
                    Id = 2,
                    Name = "СберБанк",
                }, new Bank
                {
                    Id = 3,
                    Name = "Тинькофф",
                });
        }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<Bank> Banks { get; set; }

        protected DbSet<EntityFrameworkCore.MemoryJoin.QueryModelClass> QueryData { get; set; }
    }
}