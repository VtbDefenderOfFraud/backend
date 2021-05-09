using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bki.Data.Model
{
    [Index(nameof(Passport))]
    public class LoanRequest
    {
        public LoanRequest(int bankId, string passport, int amount)
        {
            BankId = bankId;
            Passport = passport;
            Amount = amount;
        }

        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public string Passport { get; set; }

        public int Amount { get; set; }

        public int BankId { get; set; }

        public Bank Bank { get; set; }
    }
}