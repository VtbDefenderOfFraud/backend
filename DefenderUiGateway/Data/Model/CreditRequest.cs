using System;
using Microsoft.EntityFrameworkCore;

namespace DefenderUiGateway.Data.Model
{
    [Index(nameof(BkiId), IsUnique = true)]
    public class CreditRequest
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User User { get; set; }

        public int BankId { get; set; }

        public Bank Bank { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Amount { get; set; }

        public int? BkiId { get; set; }
    }
}