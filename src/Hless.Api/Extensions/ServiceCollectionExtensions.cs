using Hless.Api.Data;
using Hless.Common.Repositories;
using Hless.Data.InMemory.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hless.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            //services.AddSingleton<ISchemaRepository, InMemorySchemaRepository>();
            services.AddSingleton<ISchemaRepository>(new SchemaRepository(services.BuildServiceProvider().GetService<ISchemaDatabaseExtension>()));
            return services;
        }

        public static IServiceCollection AddDatabaseObjects(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<ISchemaDatabaseExtension> (new SchemaDatabaseExtension(connectionString));

            SeedData.AddData();

            return services;
        }

    }
    
}