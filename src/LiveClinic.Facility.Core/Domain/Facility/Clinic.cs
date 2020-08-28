﻿using FluentValidation;
using LiveClinic.ClinicManager.Core.Application.Events;
using LiveClinic.ClinicManager.Core.Domain.Common;
using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Domain.Facility
{
    public class Clinic : AggregateRoot
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public Fee ServiceFee { get; private set; }
        
        private readonly ClinicValidator _validator=new ClinicValidator();

        private Clinic()
        {
        }

        public Clinic(string name, string street, string city, decimal value, string currency="USD")
        {
            Name = name;
            Address = new Address(street, city);
            ServiceFee = new Fee(FeeType.Service, value, currency);
            
            _validator.ValidateAndThrow(this);
            
            AddDomainEvent(new ClinicCreated(Id));
        }

        public void ChangeDetails(string name, string street, string city)
        {
            Name = name;
            Address = new Address(street, city);
            
            _validator.ValidateAndThrow(this);
            
            AddDomainEvent(new ClinicDetailsUpdated(Id));
        }
        
        public void ChangeFee(decimal value, string currency="USD")
        {
            ServiceFee = new Fee(FeeType.Service, value, currency);
            
            _validator.ValidateAndThrow(this);

            AddDomainEvent(new FeeChanged(FeeType.Service, Id));
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
