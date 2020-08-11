using System;
using System.Collections.Generic;
using LiveClinic.SharedKernel.Infrastructure.Persistence;
using LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts;
using LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts.Domain;
using LiveClinic.SharedKernel.Interfaces.Persistence;
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

            services.AddSingleton<IDatabaseSettings>(GetDatabaseSettings(config));
            services.AddTransient<ITestCarDocumentRepository, TestCarDocumentRepository>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public static void ClearDb()
        {
            var repository = ServiceProvider.GetService<ITestCarDocumentRepository>();
            var context = repository.DatabaseContext as IMongoDatabase;
            context.DropCollection("");
            context.CreateCollection("");
        }
        public static void SeedData(params IEnumerable<object>[] entities)
        {
            // var context = ServiceProvider.GetService<TestDbContext>();
            //
            // foreach (IEnumerable<object> t in entities)
            // {
            //     context.AddRange(t);
            // }
            //
            // context.SaveChanges();
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
