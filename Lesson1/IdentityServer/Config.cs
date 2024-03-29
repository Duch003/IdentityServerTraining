﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            { new ApiScope("Api1", "My API") };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                //a.k.a. login
                ClientId = "client",

                //no interaqctive user, use the clientidsecret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                //secret for authentication
                //a.k.a. password
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                //scopes that client has access to
                AllowedScopes = { "Api1" }
            }
        };
    }
}