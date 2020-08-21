using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Application.Events
{
    public class ClinicDetailsUpdated:DomainEvent
    {
        public string ClinicId { get; }

        public ClinicDetailsUpdated(string clinicId)
        {
            ClinicId = clinicId;
        }
    }
}