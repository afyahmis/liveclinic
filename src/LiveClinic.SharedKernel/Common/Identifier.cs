using System.Collections.Generic;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Common
{
    public class Identifier:ValueObject<Identifier>
    {
        public IdentifierType Type { get;  }
        public string Value { get;  }

        public Identifier(IdentifierType type, string value)
        {
            Type = type;
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Value;
        }

        public override string ToString()
        {
            return $"{Type}:{Value}";
        }
    }
}
