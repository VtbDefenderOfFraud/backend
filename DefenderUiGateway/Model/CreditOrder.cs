using System;

namespace DefenderUiGateway.Model
{
    public class CreditOrder
    {
        public string BankName { get; set; }
        public string BankIcoUrl { get; set; }
        public string RegistrationNumber { get; set; }
        public string Tin { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
    }
}
