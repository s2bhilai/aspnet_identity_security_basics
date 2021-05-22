using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace identityserver1
{
    public static class Configuration
    {

        //Maps to Identity Token
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name="rc.scope",
                    UserClaims =
                    {
                        "rc.grandma"
                    }
                }
            };

        //Map claims to access token
        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource> { 
                new ApiResource("ApiOne",new string[] { "rc.api.grandma" }) { Scopes = { "ApiOne" } },
                new ApiResource("ApiTwo") { Scopes = { "ApiTwo" } }
            };

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope(name: "ApiOne", displayName: "API One ."),
                new ApiScope(name: "ApiTwo", displayName: "API Two .")
            };
        }

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes = { "ApiOne" }
                },
                new Client
                {
                    ClientId = "client_id_mvc",
                    ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:44372/signin-oidc" },

                    AllowedScopes = { 
                        "ApiOne",
                        "ApiTwo",
                        IdentityServerConstants.StandardScopes.OpenId,
                        //IdentityServerConstants.StandardScopes.Profile,
                        "rc.scope"
                    },

                    RequireConsent = false, // Disabling consent in this example
                    AllowOfflineAccess = true //For refresh token
                    
                    //Puts all the claims in id token
                    //AlwaysIncludeUserClaimsInIdToken = true
                },
                new Client
                {
                    ClientId = "client_id_js",
                    
                    AllowedGrantTypes = GrantTypes.Implicit,
                    
                    RedirectUris = { "https://localhost:44389/Home/signin" },
                    AllowedCorsOrigins = { "https://localhost:44389" },

                     AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "ApiOne"
                     },

                     AllowAccessTokensViaBrowser = true,
                     RequireConsent = false

                }
            };

    }
}
