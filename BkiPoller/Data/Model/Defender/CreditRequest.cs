using System;

namespace BkiPoller.Data.Model.Defender
{
    public class CreditRequest
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User User { get; set; }

        public int BankId { get; set; }

        public DateTime OrderDate { get; set; }

        public int? BkiId { get; set; }
    }
}