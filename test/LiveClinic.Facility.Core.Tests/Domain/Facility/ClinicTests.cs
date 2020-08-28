using System.Linq;
using FluentValidation;
using LiveClinic.ClinicManager.Core.Domain.Facility;
using NUnit.Framework;
using Serilog;

namespace LiveClinic.ClinicManager.Core.Tests.Domain.Facility
{
    [TestFixture]
    public class ClinicTests
    {

        [Test]
        public void should_Validate_Creation()
        {
            var result = Assert.Throws<ValidationException>(() =>
            {
                var clinic = new Clinic(" ", "10th Street,Lenana", "Nairobi", 0);
            });
            result.Errors.ToList().ForEach(e=>Log.Debug(e.ErrorMessage));
        }

        [Test]
        public void should_Validate_Change()
        {
            var clinic = new Clinic("Demo", "10th Street,Lenana", "Nairobi", 10);

            var result = Assert.Throws<ValidationException>(() =>
            {
                clinic.ChangeDetails("","","Lagos");
            });
            result.Errors.ToList().ForEach(e=>Log.Debug(e.ErrorMessage));
        }

        [Test]
        public void should_Validate_Fee()
        {
            var clinic = new Clinic("Demo", "10th Street,Lenana", "Nairobi", 10);

            var result = Assert.Throws<ValidationException>(() =>
            {
                clinic.ChangeFee(-1,"USD");
            });
            result.Errors.ToList().ForEach(e=>Log.Debug(e.ErrorMessage));
        }
    }
}
