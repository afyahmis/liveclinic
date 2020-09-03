using System;
using System.ComponentModel.DataAnnotations;
using LiveClinic.EncounterManager.Core.Domain.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Domain.Consultation
{
    public class Visit : AggregateRoot
    {
        public string PatientId { get; private set; }
        public string ClinicId { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public Period Session { get; private set; }


        private Visit()
        {
        }

        public Visit(string patientId, string clinicId)
        {
            PatientId = patientId;
            ClinicId = clinicId;
        }

        public void StartVisit()
        {
            Session = new Period(DateTime.Now);
        }
        public void EndVisit()
        {
            Session = new Period(Session.StartDate, DateTime.Now);
        }
    }
}
