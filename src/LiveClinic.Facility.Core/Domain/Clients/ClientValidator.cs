using System;
using FluentValidation;

namespace LiveClinic.ClinicManager.Core.Domain.Clients
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.BirthDate).Must(BeValidRegistrationDate);
            RuleFor(x => x.Identifier.Value).NotEmpty();
            RuleFor(x => x.Name.FirstName).NotEmpty();
            RuleFor(x => x.Name.LastName).NotEmpty();
            RuleFor(x => x.Gender).Must(BeValidGender);
            RuleFor(x => x.Address.Street).NotEmpty();
            RuleFor(x => x.Address.City).NotEmpty();
            RuleFor(x => x.BirthDate).Must(BeValidBirthDate);
        }
        
        private bool BeValidRegistrationDate(DateTime value)
        {
            return value.Date <= DateTime.Now.Date;
        }

        private bool BeValidGender(string value)
        {
            return value == "M" || value == "F";
        }

        private bool BeValidBirthDate(Client instance, DateTime value)
        {
            return value.Date <= instance.RegistrationDate &&
                   value.Date <= DateTime.Now.Date &&
                   value.Date > DateTime.Now.AddYears(-120).Date;
        }
    }
    
}