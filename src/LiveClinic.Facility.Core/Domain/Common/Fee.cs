using System;
using System.Collections.Generic;
using System.Text;
using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Domain.Common
{
    public class Fee : ValueObject<Fee>
    {
        public FeeType FeeType { get; }
        public Money Amount { get; }

        public Fee(FeeType feeType, decimal value, string currency)
        {
            FeeType = feeType;
            Amount = new Money(value, currency);
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FeeType;
            yield return Amount;
        }
    }

}
