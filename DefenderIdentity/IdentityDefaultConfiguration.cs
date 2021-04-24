using System.Collections.Generic;
using IdentityServer4.Models;

namespace DefenderIdentity
{
    public static class IdentityDefaultConfiguration
    {
        public static IEnumerable<Client> GetClients()
        {
            return new[]
                {CreateClient("testuser1", "testuser1".Sha256()), CreateClient("testuser2", "testuser2".Sha256())};
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[] {new ApiScope("api1.all", "Full access to api")};
        }

        private static Client CreateClient(string name, string sha256Password)
        {
            return new()
            {
                ClientId = name,
                ClientName = "Client for tests",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {new(sha256Password)},
                AllowedScopes = new []{"api1.all"}
            };
        }
    }
}