using System;
using FluentValidation;
using LiveClinic.ClinicManager.Core.Domain.Clients;

namespace LiveClinic.EncounterManager.Core.Domain.Consultation
{
    public class VisitValidator : AbstractValidator<Visit>
    {
        public VisitValidator()
        {
            RuleFor(x => x.ClinicId).NotEmpty();
            RuleFor(x => x.PatientId).NotEmpty();
        }
    }
}