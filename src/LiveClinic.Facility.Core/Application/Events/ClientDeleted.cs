using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Application.Events
{
    public class ClientDeleted : DomainEvent
    {
        public string PatientId { get; }

        public ClientDeleted(string patientId)
        {
            PatientId = patientId;
        }
    }
}