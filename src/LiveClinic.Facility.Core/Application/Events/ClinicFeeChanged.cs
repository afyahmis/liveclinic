using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Application.Events
{
    public class ClinicFeeChanged : DomainEvent
    {
        public string ClinicId { get; }

        public ClinicFeeChanged(string clinicId)
        {
            ClinicId = clinicId;
        }

    }
}