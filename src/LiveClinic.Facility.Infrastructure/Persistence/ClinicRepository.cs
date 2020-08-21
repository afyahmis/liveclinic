using LiveClinic.ClinicManager.Core.Domain.Facility;
using LiveClinic.SharedKernel.Infrastructure.Persistence;
using LiveClinic.SharedKernel.Interfaces.Persistence;

namespace LiveClinic.ClinicManager.Infrastructure.Persistence
{
    public class ClinicRepository :DocumentRepository<Clinic>,  IClinicRepository
    {
        public ClinicRepository(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}