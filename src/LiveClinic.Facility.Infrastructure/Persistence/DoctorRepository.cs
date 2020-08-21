using LiveClinic.ClinicManager.Core.Domain.Staff;
using LiveClinic.SharedKernel.Infrastructure.Persistence;
using LiveClinic.SharedKernel.Interfaces.Persistence;

namespace LiveClinic.ClinicManager.Infrastructure.Persistence
{
    public class DoctorRepository :DocumentRepository<Doctor>,  IDoctorRepository
    {
        public DoctorRepository(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}