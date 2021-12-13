using Hless.Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hless.Api.Attributes
{
    // TODO: Change so it get api-keys from a database

    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiKey : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "x-api-key";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key was not provided"
                };
                return;
            }

            var key = context.HttpContext.RequestServices.GetService<IKeyRepository>().GetAll().Result.ToList().Find(x => x.Key == extractedApiKey);

            if (key == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key is not valid"
                };
                return;
            }

            await next();
        }
    }
}
