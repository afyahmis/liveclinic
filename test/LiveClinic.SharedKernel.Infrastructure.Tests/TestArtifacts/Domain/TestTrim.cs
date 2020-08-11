using System.Collections.Generic;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts.Domain
{
    public class TestTrim:ValueObject<TestTrim>
    {
        public string Transmission { get; set; }
        public string FuelType { get; set; }

        public TestTrim()
        {
        }

        public TestTrim(string transmission, string fuelType)
        {
            Transmission = transmission;
            FuelType = fuelType;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Transmission;
            yield return FuelType;
        }

        public override string ToString()
        {
            return $"{Transmission} {FuelType}";
        }
    }
}
