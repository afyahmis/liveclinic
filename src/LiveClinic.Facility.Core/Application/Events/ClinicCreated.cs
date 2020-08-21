using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Application.Events
{
    public class ClinicCreated:DomainEvent
    {
        public string ClinicId { get; }

        public ClinicCreated(string clinicId)
        {
            ClinicId = clinicId;
        }
    }
}