using System;
using FluentValidation;
using LiveClinic.ClinicManager.Core.Application.Events;
using LiveClinic.ClinicManager.Core.Domain.Common;
using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Domain.Staff
{
    public class Doctor : AggregateRoot
    {
        public PersonName Name { get; private set; }
        public Address Address { get; private set; }
        public Fee ConsultationFee { get; private set; }
        public bool Voided { get;private set; }
        
        private readonly DoctorValidator _validator=new DoctorValidator();

        private Doctor()
        {
        }

        public Doctor(string firstName, string middleName, string lastName, string street, string city, decimal value,
            string currency)
        {
            Name = new PersonName(firstName, middleName, lastName);
            Address = new Address(street, city);
            ConsultationFee = new Fee(FeeType.Consultation, value, currency);

            _validator.ValidateAndThrow(this);

            AddDomainEvent(new DoctorCreated(Id));
        }

        public void ChangeDetails(string firstName, string middleName, string lastName, string street, string city)
        {
            Name = new PersonName(firstName, middleName, lastName);
            Address = new Address(street, city);

            _validator.ValidateAndThrow(this);

            AddDomainEvent(new DoctorDetailsUpdated(Id));
        }

        public void ChangeConsultationFee(decimal value, string currency)
        {
            ConsultationFee = new Fee(FeeType.Consultation, value, currency);

            _validator.ValidateAndThrow(this);

            AddDomainEvent(new FeeChanged(FeeType.Service, Id));
        }

        public void Delete()
        {
            if (Voided)
                throw new Exception($"Doctor already deleted !");
            
            Voided = true;
            
            AddDomainEvent(new DoctorDeleted(Id));
        }


        public override string ToString()
        {
            return $"Dr. {Name}";
        }
    }
}