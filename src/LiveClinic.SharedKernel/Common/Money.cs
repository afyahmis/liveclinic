using System.Collections.Generic;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Common
{
    public class Money : ValueObject<Money>
    {
        public decimal Value { get;  }
        public string Currency { get;  }

        public Money(decimal value, string currency)
        {
            Value = value;
            Currency = currency.ToUpper();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }

        public override string ToString()
        {
            return $"{Currency} {Value:C}";
        }
       
    }
}