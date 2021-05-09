using System.ComponentModel.DataAnnotations;

namespace Bki.Model
{
    public class LoanRequest
    {
        [Required]
        public string Passport { get; set; }

        public int Amount { get; set; }

        public int BankId { get; set; }
    }
}
