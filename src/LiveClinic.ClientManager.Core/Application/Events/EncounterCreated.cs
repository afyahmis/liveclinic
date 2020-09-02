using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Application.Events
{
    public class EncounterCreated : DomainEvent
    {
        public string EncounterId { get; }

        public EncounterCreated(string encounterId)
        {
            EncounterId = encounterId;
        }
    }
}
