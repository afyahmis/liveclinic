using System.Collections.Generic;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Common
{
    public class Money : ValueObject<Money>
    {
        public decimal Value { get;  }
        public string Currency { get;  }

        public Money(decimal value, string currency="USD")
        {
            Value = value;
            Currency = currency;
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