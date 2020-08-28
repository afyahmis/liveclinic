using System.Collections.Generic;
using LiveClinic.ClinicManager.Core.Domain.Facility;
using LiveClinic.ClinicManager.Core.Domain.Staff;

namespace LiveClinic.ClinicManager.Core.Tests.TestArtifacts
{
    public class TestData
    {
        public static List<Clinic> GetTestClinics()
        {
            return new List<Clinic>
            {
                new Clinic("Demo", "101 Street X", "Y City", 150)
            };
        }

        public static List<Doctor> GetTestDoctors()
        {
            return new List<Doctor>
            {
                new Doctor("John", "M", "Doe", "102 Street X", "A City", 100),
                new Doctor("Mary", "", "Doe", "103 Street X", "B City", 200)
            };
        }
    }
}
