using System;
using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClientManager.Core.Domain
{
    public class Client : AggregateRoot
    {
        public Identifier Identifier { get; set; }
        public PersonName Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
