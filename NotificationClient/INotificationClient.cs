using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationClient
{
    public interface INotificationClient
    {
        Task SendAsync(IEnumerable<string> clientTokens, string title, string body, Uri imageUri = null);
    }
}