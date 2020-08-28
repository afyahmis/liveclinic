using LiveClinic.ClinicManager.Core.Domain.Facility;

namespace LiveClinic.ClinicManager.Core.Tests.TestArtifacts
{
    public class TestData
    {
        public static Clinic GetTestClinic()
        {
            return new Clinic("Demo","101 Street X","Y City",150);
        }
    }
}