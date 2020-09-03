using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.EncounterManager.Core.Domain.Consultation;
using MediatR;
using Serilog;

namespace LiveClinic.EncounterManager.Core.Application.Consultation.Commands
{
    public class EndVisit:IRequest<Result>
    {
        public string VisitId { get; }

        public EndVisit(string visitId)
        {
            VisitId = visitId;
        }
    }

    public class EndVisitHandler : IRequestHandler<EndVisit, Result>
    {
        private readonly IVisitRepository _visitRepository;

        public EndVisitHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public async Task<Result> Handle(EndVisit request, CancellationToken cancellationToken)
        {
            Log.Debug("ending Visit ...");
            try
            {
                var visit =await _visitRepository.Read(request.VisitId);
                
                if(null==visit)
                    throw new Exception("visit Not found");

                visit.EndVisit();

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