// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using HLess.Shared.Users;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HLess.Config.Authentication
{
    public static class IdentityServerServices
    {
        public static void AddHLessIdentityServerAuthentication(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            var connString = configuration.GetValue<string>("store:MSSQL:connectionString");

            var identityServer = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
            // this adds the config data from DB (clients, resources, CORS)
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(connString,
                        sql =>
                        {
                            sql.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                            sql.MigrationsHistoryTable("__ConfigMigrationsHistory", "identityConfig");
                        });
                options.DefaultSchema = "identityConfig";
            })
            // this adds the operational data from DB (codes, tokens, consents)
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(connString,
                    sql =>
                    {
                        sql.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        sql.MigrationsHistoryTable("__OpsMigrationsHistory", "identityOps");
                    });
                options.DefaultSchema = "identityOps";
                // this enables automatic token cleanup. this is optional.
                options.EnableTokenCleanup = true;
            })
            .AddAspNetIdentity<User>();

            // not recommended for production - you need to store your key material somewhere secure
            if (environment.IsDevelopment())
            {
                identityServer.AddDeveloperSigningCredential();
                //RegisterTestClient(identityServer);
            }
            else
            {
                identityServer.AddSigningCredential(GetSigningCertificate().Result);
                //throw new Exception("need to configure key material");
            }
        }
        static Task<X509Certificate2> GetSigningCertificate()
        {
            //var azureServiceTokenProvider = new AzureServiceTokenProvider();

            //// using managed identities
            //var kv = new KeyVaultClient(async (authority, resource, scope) =>
            //{
            //    var authContext = new AuthenticationContext(authority);
            //    var clientCred = new ClientCredential(Configuration["AppSettings_AppRegistrationId"], Configuration["AppSettings_AppRegistrationSecret"]);
            //    var result = await authContext.AcquireTokenAsync(resource, clientCred);

            //    if (result == null)
            //        throw new InvalidOperationException("Failed to obtain the JWT token");

            //    return result.AccessToken;
            //});

            //var certificateSecret = await kv.GetSecretAsync($"https://{Configuration["AppSettings_KeyVaultName"]}.vault.azure.net/", Configuration["AppSettings_CertificateName"]);
            //var privateKeyBytes = Convert.FromBase64String(certificateSecret.Value);

            //var certificate = new X509Certificate2(privateKeyBytes, (string)null);

            //return certificate;
            return default;
        }
    }
}
