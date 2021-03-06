using FluentValidation;

namespace LiveClinic.ClinicManager.Core.Domain.Facility
{
    public class ClinicValidator : AbstractValidator<Clinic>
    {
        public ClinicValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address.Street).NotEmpty();
            RuleFor(x => x.Address.City).NotEmpty();
            RuleFor(x => x.ServiceFee.Amount).GreaterThan(0);
            RuleFor(x => x.ServiceFee.Currency).NotEmpty();
        }
    }
}
