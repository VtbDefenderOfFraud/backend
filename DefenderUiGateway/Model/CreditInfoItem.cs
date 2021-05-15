using System;

namespace DefenderUiGateway.Model
{
    public class CreditInfoItem
    {
        public string BankName { get; set; }
        public string BankIcoUrl { get; set; }
        public decimal TotalSum { get; set; }
        public decimal Payment { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public CreditState State { get; set; }
    }
}
