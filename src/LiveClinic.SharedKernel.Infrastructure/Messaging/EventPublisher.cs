using System;
using System.Linq;
using System.Threading.Tasks;
using LiveClinic.SharedKernel.Interfaces.Messaging;
using LiveClinic.SharedKernel.Model;
using MediatR;

namespace LiveClinic.SharedKernel.Infrastructure.Messaging
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IMediator _mediator;

        public EventPublisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish<T>(T aggregateRoot) where T : AggregateRoot
        {
            foreach (var domainEvent in aggregateRoot.DomainEvents.ToList())
            {
                await _mediator.Publish(domainEvent);
                aggregateRoot.RemoveDomainEvent(domainEvent);
            }
        }
    }
}