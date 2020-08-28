using FluentValidation;

namespace LiveClinic.ClinicManager.Core.Domain.Staff
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.Name.FirstName).NotEmpty();
            RuleFor(x => x.Name.LastName).NotEmpty();
            RuleFor(x => x.Address.Street).NotEmpty();
            RuleFor(x => x.Address.City).NotEmpty();
            RuleFor(x => x.ConsultationFee.Amount).GreaterThan(0);
            RuleFor(x => x.ConsultationFee.Currency).NotEmpty();
        }
    }
}
