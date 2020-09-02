using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Application.Events
{
    public class VisitCreated : DomainEvent
    {
        public string VisitId { get; }

        public VisitCreated(string visitId)
        {
            VisitId = visitId;
        }
    }
}
