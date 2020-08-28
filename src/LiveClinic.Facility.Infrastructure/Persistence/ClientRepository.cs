using LiveClinic.ClinicManager.Core.Domain.Clients;
using LiveClinic.SharedKernel.Infrastructure.Persistence;
using LiveClinic.SharedKernel.Interfaces.Persistence;

namespace LiveClinic.ClinicManager.Infrastructure.Persistence
{
    public class ClientRepository :DocumentRepository<Client>,  IClientRepository
    {
        public ClientRepository(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}