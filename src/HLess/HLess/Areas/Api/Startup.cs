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

using HLess.Shared;

using Microsoft.AspNetCore.Builder;

namespace HLess.Areas.Api
{
    public static class Startup
    {
        public static void ConfigureApi(this IApplicationBuilder app)
        {
            app.Map(Constants.ApiPrefix, appApi =>
            {
                appApi.UseRouting();
                
                //appApi.UseAuthentication();
                //appApi.UseAuthorization();

                appApi.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
        }
    }
}
