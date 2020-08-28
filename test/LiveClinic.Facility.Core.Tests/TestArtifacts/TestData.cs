using System;
using System.Collections.Generic;
using LiveClinic.ClinicManager.Core.Domain.Clients;
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

        public static List<Client> GetTestClients()
        {
            return new List<Client>
            {
                new Client( DateTime.Now,"H001-20", "John", "M", "James", "34 Street X", "NY City", DateTime.Now.AddYears(-24),"M"),
                new Client(DateTime.Now,"H002-20","Mary", "", "Jane", "43 Street X", "KSM City", DateTime.Now.AddYears(-17),"F")
            };
        }
    }
}
