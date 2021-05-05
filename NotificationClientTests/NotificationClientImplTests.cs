using Microsoft.Extensions.DependencyInjection;
using NotificationClient;
using NUnit.Framework;

namespace NotificationClientTests
{
    [TestFixture]
    public class NotificationClientImplTests
    {
        [Test]
        public void SendAsync_WhenDone_SuccessfulSendsMessage()
        {
            var keyFilePath = @"C:\GIT\VtbDefender\vtb-defender-firebase-adminsdk-ge43h-202d57a073.json";
            var clientTokens = new[] {"rugarusik.vtb.defender"};
            var client = CreateNotificationClient(keyFilePath);

            Assert.DoesNotThrowAsync(() => client.SendAsync(clientTokens, "HI", "HelloWorld"));
        }

        private INotificationClient CreateNotificationClient(string keyFilePath)
        {
            var services = new ServiceCollection();
            services.RegisterNotificationClient(keyFilePath);
            var provider = services.BuildServiceProvider();
            return provider.GetService<INotificationClient>();
        }
    }
}
