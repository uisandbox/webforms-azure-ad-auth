using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace TestADAuth.Utils
{
    public static class MsalAppBuilder
    {
        public static string GetAccountId(this ClaimsPrincipal claimsPrincipal)
        {
            string oid = claimsPrincipal.GetObjectId();
            string tid = claimsPrincipal.GetTenantId();
            return $"{oid}.{tid}";
        }

        private static IConfidentialClientApplication clientapp;

        public static IConfidentialClientApplication BuildConfidentialClientApplication()
        {
            if (clientapp == null)
            {
                clientapp = ConfidentialClientApplicationBuilder.Create(AuthConfig.ClientId)
                      .WithClientSecret(AuthConfig.ClientSecret)
                      .WithRedirectUri(AuthConfig.RedirectUri)
                      .WithAuthority(new Uri(AuthConfig.Authority))
                      .Build();

                clientapp.AddDistributedTokenCache(services =>
                {
                    // Do not use DistributedMemoryCache in production!
                    // This is a memory cache which is not distributed and is not persisted.
                    // It's useful for testing and samples, but in production use a durable distributed cache,
                    // such as Redis.
                    services.AddDistributedMemoryCache();

                    // The setting below shows encryption which works on a single machine. 
                    // In a distributed system, the encryption keys must be shared between all machines
                    // For details see https://github.com/AzureAD/microsoft-identity-web/wiki/L1-Cache-in-Distributed-(L2)-Token-Cache#distributed-systems
                    services.Configure<MsalDistributedTokenCacheAdapterOptions>(o =>
                    {
                        o.Encrypt = true;
                    });
                });
                /*
                                // Could also use other forms of cache, like Redis
                                // See https://aka.ms/ms-id-web/token-cache-serialization
                                clientapp.AddDistributedTokenCache(services =>
                                {
                                    services.AddStackExchangeRedisCache(options =>
                                    {
                                        options.Configuration = "localhost";
                                        options.InstanceName = "SampleInstance";
                                    });
                                });
                */
            }
            return clientapp;
        }

        public static async Task RemoveAccount()
        {
            BuildConfidentialClientApplication();

            var userAccount = await clientapp.GetAccountAsync(ClaimsPrincipal.Current.GetAccountId());
            if (userAccount != null)
            {
                await clientapp.RemoveAsync(userAccount);
            }
        }
    }
}