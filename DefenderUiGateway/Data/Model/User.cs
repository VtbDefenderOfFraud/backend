using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DefenderUiGateway.Data.Model
{
    [Index(nameof(Passport), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public string Passport { get; set; }

        [Required]
        public string Name { get; set; }

        public int CreditIndex { get; set; }

        public int RatingMin { get; set; }

        public int RatingMax { get; set; }

        public double CreditApprovalChance => (RatingMax - RatingMin) * 1.0 / CreditIndex;
    }
}