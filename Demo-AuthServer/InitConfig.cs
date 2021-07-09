using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_AuthServer
{
    public class InitConfig
    {

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ApiName", "ApiName")
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
             {
                 new ApiScope(name: "api1",   displayName: "Read your data."),
                 new ApiScope(name: "write",  displayName: "Write your data."),
                 new ApiScope(name: "delete", displayName: "Delete your data."),
                 new ApiScope(name: "identityserverapi", displayName: "manage identityserver api endpoints.")
             };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId="xiaowu",
                    ClientSecrets=new []{ new Secret("123456".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes=new []{ "api1" }
                }
            };
        }
    }
}
