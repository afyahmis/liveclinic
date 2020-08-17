using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.Facility.Core.Domain
{
    public class Clinic : AggregateRoot
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
