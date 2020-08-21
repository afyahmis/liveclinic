using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Domain.Staff
{
    public class Doctor : AggregateRoot
    {
        public PersonName Name { get; private set; }
        public Address Address { get; private set; }
        public Money ServiceFee { get; private set; }

        public Doctor(string firstName, string middleName, string lastName, string street, string city, decimal value,
            string currency)
        {
            Name = new PersonName(firstName, middleName, lastName);
            Address = new Address(street, city);
            ServiceFee = new Money(value, currency);
        }

        public void ChangeDetails(string firstName, string middleName, string lastName, string street, string city)
        {
            Name = new PersonName(firstName, middleName, lastName);
            Address = new Address(street, city);
        }

        public void ChangeServiceFee(decimal value, string currency)
        {
            ServiceFee = new Money(value, currency);
        }
    }
}