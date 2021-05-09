using System;
using System.ComponentModel.DataAnnotations;

namespace Bki.Data.Model
{
    public class Bank
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public string Name { get; set; }
    }
}
