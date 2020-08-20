using System.Collections.Generic;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Common
{
    public class Identifier:ValueObject<Identifier>
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public Identifier(string type, string value)
        {
            Type = type;
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}
