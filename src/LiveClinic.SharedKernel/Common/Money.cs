using System.Collections.Generic;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Common
{
    public class Money : ValueObject<Money>
    {
        public double Amount { get;  }
        public string Currency { get;  }

        public Money(double amount, string currency)
        {
            Amount = amount;
            Currency = currency.ToUpper();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

        public override string ToString()
        {
            return $"{Currency} {Amount:N2}";
        }

    }
}
