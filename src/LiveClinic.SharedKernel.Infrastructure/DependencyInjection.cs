using System.Collections.Generic;
using System.Reflection;
using LiveClinic.SharedKernel.Infrastructure.Messaging;
using LiveClinic.SharedKernel.Infrastructure.Persistence;
using LiveClinic.SharedKernel.Interfaces.Messaging;
using LiveClinic.SharedKernel.Interfaces.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace LiveClinic.SharedKernel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services,
            IConfiguration configuration)
        {
         
            var databaseSettings = GetDatabaseSettings(configuration);
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);

            services.AddSingleton<IDatabaseSettings>(databaseSettings);
            services.AddSingleton<IMongoClient>(client);
            services.AddSingleton<IMongoDatabase>(db);

            return services;
        }

        public static IServiceCollection AddEventPublisher(this IServiceCollection services,
            List<Assembly> assemblies)
        {
            services.AddMediatR(assemblies.ToArray());
            services.AddSingleton<IEventPublisher, EventPublisher>();
            return services;
        }

        private static DatabaseSettings GetDatabaseSettings(IConfiguration config)
        {
            return
                new DatabaseSettings(
                    config[$"{nameof(DatabaseSettings)}:{nameof(DatabaseSettings.ConnectionString)}"],
                    config[$"{nameof(DatabaseSettings)}:{nameof(DatabaseSettings.DatabaseName)}"]);
        }
    }
}
