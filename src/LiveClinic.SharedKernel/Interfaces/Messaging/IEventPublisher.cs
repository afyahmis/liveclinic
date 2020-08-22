using System.Threading.Tasks;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Interfaces.Messaging
{
    public interface IEventPublisher
    {
        Task Publish<T>(T aggregateRoot) where T : AggregateRoot;
    }
}