﻿using System;
using FluentValidation;
using LiveClinic.ClinicManager.Core.Application.Events;
using LiveClinic.SharedKernel.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Domain.Clients
{
    public class Client : AggregateRoot
    {
        public DateTime RegistrationDate { get; private set; }
        public Identifier Identifier { get; private set; }
        public PersonName Name { get; private set; }
        public string Gender { get; private set; }
        public Address Address { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Voided { get; private set; }

        private readonly ClientValidator _validator = new ClientValidator();

        private Client()
        {
        }

        public Client(DateTime registrationDate, string identifier,
            string firstName, string middleName, string lastName,
            string street, string city,
            DateTime birthDate, string gender)
        {
            RegistrationDate = registrationDate;
            Identifier = new Identifier(IdentifierType.InsuranceNo, identifier);
            Name = new PersonName(firstName, middleName, lastName);
            Address = new Address(street, city);
            BirthDate = birthDate.Date;
            Gender = gender.ToUpper();

            _validator.ValidateAndThrow(this);

            AddDomainEvent(new ClientCreated(Id));
        }

        public void ChangeDetails(DateTime registrationDate,
            string firstName, string middleName, string lastName,
            string street, string city,
            DateTime birthDate, string gender)
        {
            if (Voided)
                throw new Exception($"Client already voided and no changes allowed !");

            RegistrationDate = registrationDate;
            Name = new PersonName(firstName, middleName, lastName);
            Address = new Address(street, city);
            BirthDate = birthDate.Date;
            Gender = gender.ToUpper();

            _validator.ValidateAndThrow(this);

            AddDomainEvent(new ClientDetailsUpdated(Id));
        }

        public void MarkAsDeleted()
        {
            if (Voided)
                throw new Exception($"Client already voided !");

            Voided = true;

            AddDomainEvent(new ClientDeleted(Id));
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
