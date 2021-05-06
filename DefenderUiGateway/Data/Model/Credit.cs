using System;

namespace DefenderUiGateway.Data.Model
{
    public class Credit
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int StateId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int BankId { get; set; }

        public Bank Bank { get; set; }

        public decimal TotalSum { get; set; }

        public decimal Payment { get; set; }

        public decimal PaidSum { get; set; }
    }
}