using System;

namespace BkiPoller.Data.Model.Defender
{
    public class Push
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Updated { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime Since { get; set; }

        public DateTime? Pushed { get; set; }
    }
}