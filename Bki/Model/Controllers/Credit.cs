using System;
using System.ComponentModel.DataAnnotations;

namespace Bki.Model.Controllers
{
    public class Credit
    {
        [Required]
        public string Passport { get; set; }

        public int Amount { get; set; }

        public int BankId { get; set; }

        public DateTime Requested { get; set; }
    }
}