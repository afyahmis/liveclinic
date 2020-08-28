using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Domain.Registry
{
    public class Provider : AggregateRoot
    {
        public PersonName Name { get; private set; }
        public bool Voided { get; private set; }
    }
}
