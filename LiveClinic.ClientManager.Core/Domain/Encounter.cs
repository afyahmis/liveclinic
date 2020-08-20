using System;
using System.Collections.Generic;
using System.Text;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClientManager.Core.Domain
{
    public class Encounter : AggregateRoot
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string ClientId { get; set; }
        public string ClinicId { get; set; }
        public List<Observation> Observations { get; set; }
    }
}
