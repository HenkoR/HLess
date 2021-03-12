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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HLess.Areas.Api.Controllers
{
    [Area("Api")]
    [ApiController]
    public class ApiController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            if (!request.PathBase.HasValue || request.PathBase.Value?.EndsWith("/api", StringComparison.OrdinalIgnoreCase) != true)
            {
                context.Result = new RedirectResult("/");
            }
        }
    }
}
