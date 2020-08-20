using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.Billing.Core.Domain
{
    public class Unit : AggregateRoot
    {
        public string Code { get; set; }
        public string Description{ get; set; }
        public Money Price { get; set; }
    }
}