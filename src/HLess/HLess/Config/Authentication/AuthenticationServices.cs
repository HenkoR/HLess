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

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HLess.Config.Authentication
{
    public static class AuthenticationServices
    {
        public static void AddHLessAuthentication(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            services.AddHLessIdentityServerAuthentication(environment, configuration);
            services.AddAuthentication();
        }
    }
}
