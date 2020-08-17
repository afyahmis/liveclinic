using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClientManager.Core.Domain
{
    public class Client : AggregateRoot
    {
        public PersonName Name { get; set; }

    }
}
