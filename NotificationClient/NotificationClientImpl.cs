using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;

namespace NotificationClient
{
    public class NotificationClientImpl : INotificationClient
    {
        private readonly FirebaseMessaging _firebaseMessaging;

        public NotificationClientImpl(FirebaseMessaging firebaseMessaging)
        {
            _firebaseMessaging = firebaseMessaging;
        }

        public Task SendAsync(IEnumerable<string> clientTokens, string title, string body, Uri imageUri = null)
        {
            var notification = new Notification {Body = body, Title = title, ImageUrl = imageUri?.AbsoluteUri};
            var message = new MulticastMessage {Tokens = clientTokens.ToList(), Notification = notification};
            return _firebaseMessaging.SendMulticastAsync(message);
        }
    }
}