using System.Collections.Generic;
using System.Linq;
using LiveClinic.ClinicManager.Core.Application.Services;
using LiveClinic.ClinicManager.Core.Domain.Staff;
using LiveClinic.ClinicManager.Core.Tests.TestArtifacts;
using LiveClinic.SharedKernel.Common;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serilog;

namespace LiveClinic.ClinicManager.Core.Tests.Application.Services
{
    [TestFixture]
    public class DoctorServiceTests
    {
        private IDoctorService _doctorService;
        private List<Doctor> _doctors;

        [OneTimeSetUp]
        public void Init()
        {
            _doctors = TestData.GetTestDoctors();
            TestInitializer.ClearDb();
            TestInitializer.SeedData(_doctors);
        }

        [SetUp]
        public void SetUp()
        {
            _doctorService = TestInitializer.ServiceProvider.GetService<IDoctorService>();
        }

        [Test]
        public void should_Load_Doctor()
        {
            var result = _doctorService.LoadDoctor(_doctors.First().Id).Result;
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);

            Log.Debug(result.Value.ToString());
        }

        [Test]
        public void should_Load_Doctors()
        {
            var result = _doctorService.LoadDoctors().Result;
            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());

            foreach (var doctor in result.Value)
                Log.Debug(doctor.ToString());
        }

        [Test]
        public void should_Hire_Doctor()
        {
            var doctor = new Doctor("Ken", "A", "Lusaka", "444 Street X", "M City", 10);
            var result = _doctorService.HireDoctor(doctor).Result;
            Assert.True(result.IsSuccess);
        }

        [Test]
        public void should_Remove_Doctor()
        {
            var doctorId = _doctors.Last().Id;
            var result = _doctorService.RemoveDoctor(doctorId).Result;
            Assert.True(result.IsSuccess);

            var voidDoctor = _doctorService.LoadDoctor(doctorId).Result;
            Assert.True(voidDoctor.IsSuccess);
            Assert.True(voidDoctor.Value.Voided);
        }

        [Test]
        public void should_Change_Doctor_Details()
        {
            var doctorId = _doctors.First().Id;
            var result = _doctorService.ChangeDoctorDetails(doctorId,"Jane", "A", "Doe", "555 Street X", "J City").Result;
            Assert.True(result.IsSuccess);

            var updateDoctor = _doctorService.LoadDoctor(doctorId).Result;
            Assert.True(updateDoctor.IsSuccess);
            Assert.AreEqual(new PersonName("Jane", "A", "Doe"),updateDoctor.Value.Name);
            Assert.AreEqual(new Address("555 Street X", "J City"),updateDoctor.Value.Address);
        }

        [Test]
        public void should_Adjust_Consultation_Fee()
        {
            var doctorId = _doctors.First().Id;
            var result = _doctorService.AdjustConsultationFee(doctorId,2000.55,"KES").Result;
            Assert.True(result.IsSuccess);

            var updateDoctor = _doctorService.LoadDoctor(doctorId).Result;
            Assert.True(updateDoctor.IsSuccess);
            Assert.AreEqual(new Money(2000.55,"KES"),updateDoctor.Value.ConsultationFee );
        }
    }
}
