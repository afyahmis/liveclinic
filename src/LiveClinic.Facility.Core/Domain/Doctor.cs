using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Domain
{
    public class Doctor : AggregateRoot
    {
        public PersonName Name { get; set; }
        public Address Address { get; set; }
        public Money ConsultationFee { get; set; }
    }
}