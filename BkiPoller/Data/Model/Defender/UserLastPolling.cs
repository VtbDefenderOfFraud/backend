using System;
using System.ComponentModel.DataAnnotations;

namespace BkiPoller.Data.Model.Defender
{
    public class UserLastPolling
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? Updated { get; set; }

        [Required]
        public string Passport { get; set; }

        public DateTime LastPolled { get; set; }
    }
}