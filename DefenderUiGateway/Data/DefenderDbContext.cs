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
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Сидоров Иван Петрович",
                Passport = "1111222222",
                RatingMin = 300,
                RatingMax = 850,
                CreditIndex = 707
            });

            modelBuilder.Entity<Bank>()
                .HasData(new Bank {Id = 1, Name = "СберБанк"}, new Bank {Id = 2, Name = "Тинькофф"});

            modelBuilder.Entity<Credit>().HasData(new Credit
                {
                    Id = 1,
                    BankId = 1,
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
                    BankId = 1,
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
                    BankId = 2,
                    TotalSum = 150000,
                    Payment = 3000,
                    PaidSum = 3000,
                    StateId = 0,
                    PaymentDateTime = DateTime.Now.AddDays(-2),
                    UserId = 1
                });

            modelBuilder.Entity<CreditRequest>().HasData(new CreditRequest
            {
                Id = 1,
                UserId = 1,
                BankId = 1,
                RegistrationNumber = "1234143124",
                Tin = "3434343",
                OrderDate = DateTime.Now.AddDays(-5)
            }, new CreditRequest
            {
                Id = 2,
                UserId = 1,
                BankId = 1,
                RegistrationNumber = "1234143124",
                Tin = "3434343",
                OrderDate = DateTime.Now.AddDays(-3)
            }, new CreditRequest
            {
                Id = 3,
                UserId = 1,
                BankId = 2,
                RegistrationNumber = "4536556456",
                Tin = "45645645",
                OrderDate = DateTime.Now.AddDays(-2)
            });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<CreditRequest> CreditRequests { get; set; }
    }
}