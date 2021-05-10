using System;

namespace BkiPoller.Data.Model.Defender
{
    public class UserLastPolling
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? Updated { get; set; }

        public string Passport { get; set; }

        public DateTime LastPolled { get; set; }
    }
}