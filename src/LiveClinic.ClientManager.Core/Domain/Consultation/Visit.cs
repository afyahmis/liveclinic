using System;
using LiveClinic.EncounterManager.Core.Domain.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Domain.Consultation
{
    public class Visit : AggregateRoot
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public Period Session { get; set; }
        public string PatientId { get; set; }
        public string ProviderId { get; set; }
    }
}
