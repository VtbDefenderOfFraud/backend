using System;

namespace DefenderUiGateway.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Passport { get; set; }

        public string Name { get; set; }

        public int CreditIndex { get; set; }

        public int RatingMin { get; set; }

        public int RatingMax { get; set; }

        public double CreditApprovalChance => Math.Round((RatingMax - RatingMin) * 100.0 / CreditIndex, 2);
    }
}