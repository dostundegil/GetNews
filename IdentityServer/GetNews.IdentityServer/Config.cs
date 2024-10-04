// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace GetNews.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
               new ApiResource("resource_client"){Scopes={"client_fullpermission"}},
               new ApiResource("resource_admin"){Scopes={"admin_fullpermission"}},
               new ApiResource("resource_gateway"){Scopes={"gateway_fullpermission"}},
               new ApiResource("mail_service_api", "Mail Service API") {Scopes = { "mail_service" }},
               new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
                 {
                    new IdentityResources.Email(),
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                    new IdentityResource(){Name="roles",DisplayName="Roles", Description="Admin Role",UserClaims=new[]{"role"} }
                };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("client_fullpermission","Client API için full erişim"),
                new ApiScope("admin_fullpermission","Admin API için full erişim"),
                new ApiScope("gateway_fullpermission","Gateway API için full erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
           new Client[]
            {
                new Client
                {
                    ClientName="Asp.Net Core",
                    ClientId="WebMvcClient",
                    ClientSecrets= {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes={ "gateway_fullpermission", "client_fullpermission",
                    IdentityServerConstants.LocalApi.ScopeName }
                },

                new Client
                {
                    ClientName="Asp.Net Core",
                    ClientId="WebMvcClientForAdmin",
                    AllowOfflineAccess=true,
                    ClientSecrets= {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,

                    AllowedScopes=
                    {
                    "gateway_fullpermission","admin_fullpermission","client_fullpermission",
                    IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.OfflineAccess,
                    "roles",IdentityServerConstants.LocalApi.ScopeName,
                    },

                    AccessTokenLifetime=1*60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RefreshTokenUsage=TokenUsage.ReUse
                },
                 new Client
                {
                    ClientId = "mail_service_client",
                    ClientSecrets = { new Secret("super_secret_password".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "mail_service" }
                }

            };
    }
}