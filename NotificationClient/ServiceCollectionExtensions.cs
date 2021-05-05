using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationClient
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterNotificationClient(this IServiceCollection services, string keyFilePath)
        {
            var credential = GoogleCredential.FromFile(keyFilePath);
            FirebaseApp.Create(new AppOptions {Credential = credential});
            services.AddTransient<INotificationClient, NotificationClientImpl>(_ =>
                new NotificationClientImpl(FirebaseMessaging.DefaultInstance));
        }
    }
}