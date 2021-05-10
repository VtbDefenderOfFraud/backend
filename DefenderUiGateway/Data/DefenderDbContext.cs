using System;
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
            const string passport = "1111222222";

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Сидоров Иван Петрович",
                    Passport = passport,
                    Phone = "+7(123)1234567",
                    RatingMin = 300,
                    RatingMax = 850,
                    CreditIndex = 707
                });

            modelBuilder.Entity<Bank>().HasData(
                new Bank
                {
                    Id = 1,
                    Name = "МФО \"Копеечка онлайн\"",
                    RegistrationNumber = "8503708019",
                    Tin = "75034648"
                }, new Bank
                {
                    Id = 2,
                    Name = "СберБанк",
                    RegistrationNumber = "1234143124",
                    Tin = "3434343"
                }, new Bank
                {
                    Id = 3,
                    Name = "Тинькофф",
                    RegistrationNumber = "4536556456",
                    Tin = "45645645"
                });

            modelBuilder.Entity<Credit>().HasData(
                new Credit
                {
                    Id = 1,
                    BankId = 2,
                    InActionSince = DateTime.Now.AddDays(-10),
                    TotalSum = 200000,
                    Payment = 50000,
                    PaidSum = 0,
                    StateId = 1,
                    PaymentDateTime = DateTime.Now.AddDays(-5),
                    UserId = 1
                },
                new Credit
                {
                    Id = 2,
                    BankId = 2,
                    InActionSince = DateTime.Now.AddDays(-6),
                    TotalSum = 500000,
                    Payment = 45000,
                    PaidSum = 90000,
                    StateId = 0,
                    PaymentDateTime = DateTime.Now.AddDays(-3),
                    UserId = 1
                },
                new Credit
                {
                    Id = 3,
                    BankId = 3,
                    InActionSince = DateTime.Now.AddDays(-4),
                    TotalSum = 150000,
                    Payment = 3000,
                    PaidSum = 3000,
                    StateId = 0,
                    PaymentDateTime = DateTime.Now.AddDays(-2),
                    UserId = 1
                });

            modelBuilder.Entity<CreditRequest>().HasData(
                new CreditRequest
                {
                    Id = 1,
                    UserId = 1,
                    BankId = 2,
                    OrderDate = DateTime.Now.AddDays(-5)
                }, new CreditRequest
                {
                    Id = 2,
                    UserId = 1,
                    BankId = 2,
                    OrderDate = DateTime.Now.AddDays(-3)
                }, new CreditRequest
                {
                    Id = 3,
                    UserId = 1,
                    BankId = 3,
                    OrderDate = DateTime.Now.AddDays(-2)
                });

            modelBuilder.Entity<UserLastPolling>().HasData(
                new UserLastPolling
                {
                    Id = 1,
                    Passport = passport,
                    LastPolled = DateTime.Now
                });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<CreditRequest> CreditRequests { get; set; }

        public DbSet<UserLastPolling> UsersLastPolling { get; set; }

        public DbSet<Push> Pushes { get; set; }
    }
}