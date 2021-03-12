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
using System.Threading.Tasks;

using HLess.Data;
using HLess.Services;
using HLess.Shared.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HLess.Config.Authentication
{
    public static class IdentityServices
    {
        public static void AddHLessIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetValue<string>("store:MSSQL:connectionString");
            services.AddDbContext<IdentityDbContext>(options =>
                    options.UseSqlServer(connString, 
                    sqlOptions => {
                        sqlOptions.MigrationsHistoryTable("__MembershipMigrationsHistory", "identity");
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        }
                    ));

            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IdentityDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddSingleton<IEmailSender, EmailSender>();
        }
    }
}
