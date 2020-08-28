using System.Collections.Generic;
using System.Linq;
using LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts.Domain;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NUnit.Framework;
using Serilog;

namespace LiveClinic.SharedKernel.Infrastructure.Tests.Persistence
{
    [TestFixture]
    public class DocumentRepositoryTests
    {
        private ITestCarDocumentRepository _testEntityRepository;
        private List<TestCar> _testEntities;
        private IMongoCollection<TestCar> _collection;

        [OneTimeSetUp]
        public void Init()
        {
            _testEntities = TestCar.CreateTestCars();
            TestInitializer.ClearDb();
            TestInitializer.SeedData(_testEntities);
            _collection= TestInitializer.MongoDatabase.GetCollection<TestCar>(_testEntities.First().PreferredDocName);
        }
        [SetUp]
        public void SetUp()
        {
            _testEntityRepository = TestInitializer.ServiceProvider.GetService<ITestCarDocumentRepository>();
        }

        [Test]
        public void should_Create()
        {
            var testEntity = new TestCar("VelarX");
            _testEntityRepository.Create(testEntity).Wait();

            var newTestEntity = _collection
                .Find(x => x.Id == testEntity.Id)
                .First();

            Assert.NotNull(newTestEntity);
        }
        [Test]
        public void should_Read_By_Id()
        {
            var testEntity = _testEntityRepository.Read(_testEntities.First().Id).Result;
            Assert.NotNull(testEntity);
            Log.Debug(testEntity.ToString());
        }

        [Test]
        public void should_Read()
        {
            var testEntities = _testEntityRepository.Read().Result.ToList();
            Assert.True(testEntities.Count > 0);
        }

        [Test]
        public void should_Read_By_Predicate()
        {
            var name = _testEntities.Last().Name;
            var testEntity = _testEntityRepository
                .Read(x => x.Name.ToLower().Contains( "ame"))
                .Result.First();
            Assert.NotNull(testEntity);
            Log.Debug(testEntity.ToString());
        }


        [Test]
        public void should_Update()
        {
            var testEntityForUpdate = _testEntities.First();
            testEntityForUpdate.Name = "GLE Benzx";

            _testEntityRepository.Update(testEntityForUpdate).Wait();


            var updatedTestEntity = _collection
                .Find(x => x.Id == testEntityForUpdate.Id)
                .First();

            Assert.AreEqual("GLE Benzx", updatedTestEntity.Name);
        }


        [Test]
        public void should_Delete()
        {
            var entities = TestCar.CreateTestCars();
            TestInitializer.SeedData(entities);

            var testEntityForDelete = entities.Last();
            _testEntityRepository.Delete(testEntityForDelete).Wait();

            var deletedTestEntity = _collection
                .Find(x => x.Id == testEntityForDelete.Id)
                .FirstOrDefault();

            Assert.IsNull(deletedTestEntity);
        }
    }
}
