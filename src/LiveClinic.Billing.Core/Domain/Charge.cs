using System;
using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.Billing.Core.Domain
{
    public class Charge : Entity<int>
    {
        public DateTime Date { get; set; }
        public string UnitId { get; set; }
        public Money Price { get; set; }
        public decimal Quantity { get; set; }
        public Money Amount { get; set; }
    }
}