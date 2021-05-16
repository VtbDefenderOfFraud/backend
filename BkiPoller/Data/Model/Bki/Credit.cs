using System;

namespace BkiPoller.Data.Model.Bki
{
    public class Credit
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string Passport { get; set; }

        public decimal Amount { get; set; }

        public int BankId { get; set; }
    }
}