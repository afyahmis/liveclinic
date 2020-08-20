using System;
using System.Collections.Generic;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.Billing.Core.Domain
{
    public class Bill : AggregateRoot
    {
        public DateTime Date { get; set; }
        public string CustomerId { get; set; }
        public List<Charge> Charges { get; } = new List<Charge>();
    }
}