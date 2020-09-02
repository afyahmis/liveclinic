using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Application.Events
{
    public class VisitEnded : DomainEvent
    {
        public string VisitId { get; }

        public VisitEnded(string visitId)
        {
            VisitId = visitId;
        }
    }
}
