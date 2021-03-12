using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HLess.Config.Options.EmailOptions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HLess.Config.Domain
{
    public static class NotificationServices
    {
        public static void AddHLessNotifications(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SendGridOptions>(configuration.GetSection("email").GetSection("sendgrid"));
            services.Configure<EmailaddressesOptions>(configuration.GetSection("email").GetSection("addresses"));
        }
    }
}
