using System;
using System.Collections.Generic;
using System.Linq;
using LiveClinic.SharedKernel.Infrastructure.Persistence;
using LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts;
using LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts.Domain;
using LiveClinic.SharedKernel.Interfaces.Persistence;
using LiveClinic.SharedKernel.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NUnit.Framework;
using Serilog;

namespace LiveClinic.SharedKernel.Infrastructure.Tests
{
    [SetUpFixture]
    public class TestInitializer
    {
        public static IServiceProvider ServiceProvider;
        private static IDatabaseSettings _databaseSettings;
        public static IMongoDatabase MongoDatabase;

        [OneTimeSetUp]
        public void Init()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            _databaseSettings = GetDatabaseSettings(config);


            var services = new ServiceCollection();
            services.AddSingleton<IDatabaseSettings>(_databaseSettings);
            services.AddTransient<ITestCarDocumentRepository, TestCarDocumentRepository>();
            services.AddSingleton<IMongoClient>(new MongoClient(_databaseSettings.ConnectionString));

            ServiceProvider = services.BuildServiceProvider();
            var client = ServiceProvider.GetService<IMongoClient>();
            MongoDatabase = client.GetDatabase(_databaseSettings.DatabaseName);
        }

        public static void ClearDb()
        {
            var client = ServiceProvider.GetService<IMongoClient>();
            var context = client.GetDatabase(_databaseSettings.DatabaseName);
            var collections = context.ListCollectionNames().ToList();
            foreach (var collection in collections)
                context.DropCollection(collection);
        }

        public static void SeedData(params IEnumerable<AggregateRoot>[] entities)
        {
            var client = ServiceProvider.GetService<IMongoClient>();

            foreach (var e in entities)
            {
                var entity= e.First();
                var collection = client.GetDatabase(_databaseSettings.DatabaseName)
                    .GetCollection<AggregateRoot>(entity.PreferredDocName);
                collection.InsertMany(e);
            }
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
