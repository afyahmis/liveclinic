using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LiveClinic.ClinicManager.Core.Tests.TestArtifacts;
using LiveClinic.ClinicManager.Infrastructure;
using LiveClinic.SharedKernel.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NUnit.Framework;
using Serilog;

namespace LiveClinic.ClinicManager.Core.Tests
{
    [SetUpFixture]
    public class TestInitializer
    {
        public static IServiceProvider ServiceProvider;
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

            var services = new ServiceCollection();
            services.AddInfrastructure(config, new List<Assembly> {typeof(TestEventHandler).Assembly});

        services.AddApplication();
            
            ServiceProvider = services.BuildServiceProvider();
            MongoDatabase = ServiceProvider.GetService<IMongoDatabase>();
        }

        public static void ClearDb()
        {
            var collections = MongoDatabase.ListCollectionNames().ToList();
            foreach (var collection in collections)
                MongoDatabase.DropCollection(collection);
        }

        public static void SeedData(params IEnumerable<AggregateRoot>[] entities)
        {
            foreach (var e in entities)
            {
                var entity = e.First();
                var collection = MongoDatabase
                    .GetCollection<AggregateRoot>(entity.PreferredDocName);
                collection.InsertMany(e);
            }
        }
    }
}
