using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Application.Events
{
    public class ObservationCreated : DomainEvent
    {
        public string PatientId { get; }

        public ObservationCreated(string patientId)
        {
            PatientId = patientId;
        }
    }
}