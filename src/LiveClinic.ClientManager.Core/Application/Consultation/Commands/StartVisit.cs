using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.EncounterManager.Core.Domain.Consultation;
using MediatR;
using Serilog;

namespace LiveClinic.EncounterManager.Core.Application.Consultation.Commands
{
    public class StartVisit : IRequest<Result>
    {
        public string PatientId { get; }
        public string ClinicId { get; }

        public StartVisit(string patientId, string clinicId)
        {
            PatientId = patientId;
            ClinicId = clinicId;
        }
    }

    public class StartVisitHandler : IRequestHandler<StartVisit,Result>
    {
        private readonly IVisitRepository _visitRepository;

        public StartVisitHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public async Task<Result> Handle(StartVisit request, CancellationToken cancellationToken)
        {
            Log.Debug("starting Visit ...");
            try
            {
                var visit = new Visit(request.PatientId, request.ClinicId); 
                visit.StartVisit();

                await _visitRepository.Create(visit);

                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error(e, $"{nameof(StartVisit)} Error");
                return Result.Failure(e.Message);
            }
        }
    }
}