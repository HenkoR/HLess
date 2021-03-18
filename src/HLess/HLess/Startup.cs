// ==========================================================================
//  HLess CMS
// ==========================================================================
//  Copyright (c) HLess (Henko Rabie)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HLess.Areas.Api;
using HLess.Areas.Identity;
using HLess.Config.Authentication;
using HLess.Config.Domain;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HLess
{
    public sealed class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddHLessApps();
            services.AddHLessStoreServices(Configuration);
            services.AddHLessIdentity(Configuration);
            services.AddHLessAuthentication(Environment, Configuration);
            services.AddHLessNotifications(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.ConfigureApi();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.ConfigureIdentity();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            // Migrate and Seed DB
            app.InitializeIdentityDatabase();
        }
    }
}
