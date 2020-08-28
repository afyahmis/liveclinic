using System;
using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Domain.Registry
{
    public class Patient : AggregateRoot
    {
        public Identifier Identifier { get; private set; }
        public PersonName Name { get; private set; }
        public string Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Voided { get; private set; }
    }
}
