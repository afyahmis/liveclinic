using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using FizzWare.NBuilder;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts.Domain
{
    [Table(nameof(TestCar))]
    public class TestCar : AggregateRoot
    {
        public string Name { get; set; }
        public virtual ICollection<TestCarModel> TestCarModels  { get; set; }=new List<TestCarModel>();

        public TestCar()
        {
        }
        public TestCar(string name)
        {
            Name = name;
        }

        public static List<TestCar> CreateTestCars(int count = 2, int modelCount = 3)
        {
            var cars = Builder<TestCar>.CreateListOfSize(count).Build().ToList();

            foreach (var testCar in cars)
            {
                var models = Builder<TestCarModel>.CreateListOfSize(modelCount).All()
                    .With(x => x.TestCarId = testCar.Id)
                    .With(x => x.Trim = Builder<TestTrim>.CreateNew().Build())
                    .Build().ToList();
                testCar.TestCarModels = models;
            }

            return cars;
        }

        public void AddModel(string name, int year, string transmission, string fuelType)
        {
            TestCarModels.Add(new TestCarModel(name, year, new TestTrim(transmission, fuelType), Id));
        }

        public override string ToString()
        {
            return $"{Name} |{Id}";
        }
    }
}
