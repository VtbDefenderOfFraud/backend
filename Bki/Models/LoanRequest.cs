using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Bki.Models
{
    [Index(nameof(Passport))]
    public class LoanRequest
    {
        public LoanRequest(string passport, int amount)
        {
            Passport = passport;
            Amount = amount;
        }

        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public string Passport { get; set; }

        public int Amount { get; set; }
    }
}
