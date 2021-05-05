using System;

namespace DefenderUiGateway.Model
{
    public class CreditOrder
    {
        public CreditOrder(string bankName, string registrationNumber, string tin, DateTime orderDate)
        {
            BankName = bankName;
            RegistrationNumber = registrationNumber;
            Tin = tin;
            OrderDate = orderDate;
        }

        public string BankName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Tin { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
