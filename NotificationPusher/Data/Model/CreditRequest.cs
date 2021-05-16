using System;

namespace NotificationPusher.Data.Model
{
    public class CreditRequest
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Amount { get; set; }

        public int BankId { get; set; }

        public Bank Bank { get; set; }
    }
}