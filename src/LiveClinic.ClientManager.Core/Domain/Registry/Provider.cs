using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Domain.Registry
{
    public class Provider : AggregateRoot
    {
        public PersonName Name { get;  set; }
        public bool Voided { get;  set; }
    }
}
