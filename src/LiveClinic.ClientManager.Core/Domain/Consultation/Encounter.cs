using System;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Domain.Consultation
{
    public class Encounter : AggregateRoot
    {
        public string ProviderId { get;private set; }
        public string VisitId { get;private set; }
        public string PatientId { get; private set; }
        public string Observation { get; private set; }

        public DateTime Date { get;private set; } = DateTime.Now;

        private Encounter()
        {
        }

        public Encounter(string providerId, string visitId, string patientId)
        {
            ProviderId = providerId;
            VisitId = visitId;
            PatientId = patientId;
        }

        public void CreateObservation(string observation)
        {
            Observation = observation;
        }
    }
}
