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

using Microsoft.AspNetCore.Builder;

namespace HLess.Areas.Identity
{
    public static class Startup
    {
        public static void ConfigureIdentity(this IApplicationBuilder app)
        {
            app.UseIdentityServer();
            app.UseAuthorization();
        }
    }
}
