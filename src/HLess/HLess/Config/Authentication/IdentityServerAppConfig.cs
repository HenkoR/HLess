using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HLess.Data;

using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HLess.Config.Authentication
{
    public static class IdentityServerAppConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
               new IdentityResource[]
               {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
               };

        public static void InitializeIdentityDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
