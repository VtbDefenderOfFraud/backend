using DefenderUiGateway.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DefenderUiGateway.Data
{
    public class DefenderDbContext : DbContext
    {
        public DefenderDbContext(DbContextOptions<DefenderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
                {Id = 1, Name = "Сидоров Иван Петрович", Passport = "1111222222"});

            modelBuilder.Entity<Bank>()
                .HasData(new Bank {Id = 1, Name = "СберБанк"}, new Bank {Id = 2, Name = "Тинькофф"});

            modelBuilder.Entity<Credit>().HasData(new Credit
                {Id = 1, BankId = 1, TotalSum = 200000, Payment = 50000, PaidSum = 0, StateId = 1, UserId = 1});
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Credit> Credits { get; set; }
    }
}