using System.Collections.Generic;
using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Domain
{
    public class Clinic : AggregateRoot
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Money ClinicFee { get; set; }
    }
}
