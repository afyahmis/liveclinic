using System.Linq;
using LiveClinic.ClinicManager.Core.Application.Services;
using LiveClinic.ClinicManager.Core.Domain.Facility;
using LiveClinic.ClinicManager.Core.Tests.TestArtifacts;
using LiveClinic.SharedKernel.Common;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LiveClinic.ClinicManager.Core.Tests.Application.Services
{
    [TestFixture]
    public class ClinicServiceTests
    {
        private IClinicService _clinicService;
        private Clinic _clinic;

        [OneTimeSetUp]
        public void Init()
        {
            _clinic = TestData.GetTestClinics().First();
            TestInitializer.ClearDb();
            TestInitializer.SeedData(new []{_clinic});
        }

        [SetUp]
        public void SetUp()
        {
            _clinicService = TestInitializer.ServiceProvider.GetService<IClinicService>();
        }

        [Test]
        public void should_Load()
        {
            var result = _clinicService.Load().Result;
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Log.Debug(result.Value.ToString());
        }
        [Test]
        public void should_Setup_Clinic()
        {
            TestInitializer.ClearDb();
            var result = _clinicService.SetupClinic(_clinic).Result;
            Assert.True(result.IsSuccess);
        }

        [Test]
        public void should_Change_Clinic_Details()
        {
            var result = _clinicService.ChangeClinicDetails(_clinic.Id, "New","Strr","N").Result;
            Assert.True(result.IsSuccess);

            var updateClinic = _clinicService.Load().Result;
            Assert.True(updateClinic.IsSuccess);
            Assert.AreEqual("New",updateClinic.Value.Name);
            Assert.AreEqual(new Address("Strr","N"),updateClinic.Value.Address);
        }

        [Test]
        public void should_Adjust_Service_Fee()
        {
            var result = _clinicService.AdjustServiceFee(_clinic.Id,10000.55,"KES").Result;
            Assert.True(result.IsSuccess);

            var updateClinic = _clinicService.Load().Result;
            Assert.True(updateClinic.IsSuccess);
            Assert.AreEqual(new Money(10000.55,"KES"),updateClinic.Value.ServiceFee );
        }
    }
}
