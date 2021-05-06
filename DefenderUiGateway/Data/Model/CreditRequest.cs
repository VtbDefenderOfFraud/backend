using System;

namespace DefenderUiGateway.Data.Model
{
    public class CreditRequest
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User User { get; set; }

        public int BankId { get; set; }

        public Bank Bank { get; set; }

        public string RegistrationNumber { get; set; }

        public string Tin { get; set; }

        public DateTime OrderDate { get; set; }
    }
}