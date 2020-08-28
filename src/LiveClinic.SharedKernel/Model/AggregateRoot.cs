using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveClinic.SharedKernel.Model
{
    public abstract class AggregateRoot : Entity<string>
    {
        private List<DomainEvent> _domainEvents;
        [NotMapped] 
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public AggregateRoot()
        {
            Id = Guid.NewGuid().ToString().ToLower();
        }

        public void AddDomainEvent(DomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<DomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(DomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public IReadOnlyCollection<DomainEvent> GetDomainEvents()
        {
            var domainEvents = new List<DomainEvent>();

            foreach (var domainEvent in DomainEvents)
                domainEvents.Add(domainEvent);

            return domainEvents.AsReadOnly();
        }
    }
}
