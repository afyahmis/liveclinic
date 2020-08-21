using System;
using MediatR;

namespace LiveClinic.SharedKernel.Model
{
    public class DomainEvent : INotification
    {
        public DateTime TimeStamp { get; set; } = DateTime.Now;

    }
}