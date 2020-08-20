using System;
using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.Billing.Core.Domain
{
    public class Payment : AggregateRoot
    {
        public DateTime Date { get; set; }
        public string BillId { get; set; }
        public Money Amount { get; set; }
    }
}