using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Application.Events
{
    public class VisitStarted : DomainEvent
    {
        public string VisitId { get; }

        public VisitStarted(string visitId)
        {
            VisitId = visitId;
        }
    }
}
