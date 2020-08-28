using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Application.Events
{
    public class ClientCreated : DomainEvent
    {
        public string PatientId { get; }

        public ClientCreated(string patientId)
        {
            PatientId = patientId;
        }
    }
}