using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Application.Events
{
    public class ClientDetailsUpdated : DomainEvent
    {
        public string PatientId { get; }

        public ClientDetailsUpdated(string patientId)
        {
            PatientId = patientId;
        }
    }
}