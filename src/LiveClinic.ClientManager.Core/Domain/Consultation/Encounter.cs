using System;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Domain.Consultation
{
    public class Encounter : AggregateRoot
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ClientId { get; set; }
        public string ClinicId { get; set; }
        // public List<Consultation> Consultations { get; set; }=new List<Consultation>();
    }
}
