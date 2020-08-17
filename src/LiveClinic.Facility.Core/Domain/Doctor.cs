using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.Facility.Core.Domain
{
    public class Doctor : AggregateRoot
    {
        public PersonName Name { get; set; }
    }
}