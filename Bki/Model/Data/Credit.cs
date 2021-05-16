using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bki.Model.Data
{
    [Index(nameof(Passport))]
    public class Credit
    {
        public Credit(int bankId, string passport, decimal amount)
        {
            BankId = bankId;
            Passport = passport;
            Amount = amount;
        }

        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public string Passport { get; set; }

        public decimal Amount { get; set; }

        public int BankId { get; set; }

        public Bank Bank { get; set; }
    }
}