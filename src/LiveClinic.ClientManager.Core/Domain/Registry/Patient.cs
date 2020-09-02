using System;
using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Domain.Registry
{
    public class Patient : AggregateRoot
    {
        public Identifier Identifier { get; set; }
        public PersonName Name { get;  set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get;  set; }
        public bool Voided { get;  set; }
    }
}
