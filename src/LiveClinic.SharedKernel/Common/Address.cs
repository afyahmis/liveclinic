using System.Collections.Generic;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Common
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; set; }
        public string City { get; set; }

        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
        }

        public override string ToString()
        {
            return $"{Street} {City}";
        }
    }
}