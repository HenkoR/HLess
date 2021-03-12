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

using HLess.Data.Repositories;
using HLess.Domain.Entities;
using HLess.Domain.Interfaces.Repositories;
using HLess.Domain.Interfaces.Services;
using HLess.Domain.Services;

using Microsoft.Extensions.DependencyInjection;

namespace HLess.Config.Domain
{
    public static class AppsServices
    {
        public static void AddHLessApps(this IServiceCollection services)
        {
            services.AddScoped<IDataRepository<App>, AppRepository>();

            services.AddScoped<IAppService, AppService>();
        }
    }
}
