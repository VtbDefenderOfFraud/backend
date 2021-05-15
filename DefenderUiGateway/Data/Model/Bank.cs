using System;
using System.ComponentModel.DataAnnotations;

namespace DefenderUiGateway.Data.Model
{
    public class Bank
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public string Name { get; set; }

        public string RegistrationNumber { get; set; }

        public string Tin { get; set; }
        
        public string IcoUrl { get; set; }
    }
}