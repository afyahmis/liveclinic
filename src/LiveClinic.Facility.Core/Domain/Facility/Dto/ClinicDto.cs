using LiveClinic.SharedKernel.Common;

namespace LiveClinic.ClinicManager.Core.Domain.Facility.Dto
{
    public class ClinicDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }

        public Clinic Create()
        {
            return new Clinic(Name, Street, City, Amount, Currency);
        }
    }
}