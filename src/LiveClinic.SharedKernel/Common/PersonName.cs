using System.Collections.Generic;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Common
{
    public class PersonName : ValueObject<PersonName>
    {
        public string FirstName { get;  }
        public string MiddleName { get;  }
        public string LastName { get;  }

        public PersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public PersonName(string firstName, string middleName, string lastName) : this(firstName, lastName)
        {
            MiddleName = middleName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return MiddleName;
            yield return LastName;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
