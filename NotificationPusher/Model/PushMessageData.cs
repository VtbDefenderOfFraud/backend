using System;

namespace NotificationPusher.Model
{
    public class PushMessageData
    {
        public string BankName { get; set; }
        public string BankIcoUrl { get; set; }
        public decimal TotalSum { get; set; }
        public DateTime OrderDate { get; set; }
        public string Text { get; set; }
    }
}