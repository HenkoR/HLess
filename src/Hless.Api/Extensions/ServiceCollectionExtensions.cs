using Hless.Common.Repositories;
using Hless.Data.InMemory.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hless.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ISchemaRepository, InMemorySchemaRepository>();
            services.AddSingleton<IApplicationRepository, InMemoryApplicationRepository>();
            services.AddSingleton<IContentRepository>(new InMemoryContentRepository(services.BuildServiceProvider().GetService<ISchemaRepository>()));
            return services;
        }
    }
}