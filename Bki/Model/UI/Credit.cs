using System.ComponentModel.DataAnnotations;

namespace Bki.Model.UI
{
    public class Credit
    {
        [Required]
        public string Passport { get; set; }

        public int Amount { get; set; }

        public int BankId { get; set; }
    }
}
