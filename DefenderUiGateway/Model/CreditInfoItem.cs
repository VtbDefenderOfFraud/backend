using System;

namespace DefenderUiGateway.Model
{
    public class CreditInfoItem
    {
        public string BankName { get; set; }
        public decimal TotalSum { get; set; }
        public decimal Payment { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public CreditState State { get; set; }

        public CreditInfoItem(string bankName, decimal totalSum, decimal payment, DateTime paymentDateTime, CreditState state)
        {
            BankName = bankName;
            TotalSum = totalSum;
            Payment = payment;
            PaymentDateTime = paymentDateTime;
            State = state;
        }
    }
}
