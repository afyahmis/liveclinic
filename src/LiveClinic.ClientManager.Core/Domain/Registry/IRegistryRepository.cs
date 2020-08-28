using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveClinic.EncounterManager.Core.Domain.Registry
{
    public interface IRegistryRepository
    {
        Task<Patient> LoadPatient(string patientId);
        Task<IEnumerable<Patient>> FindPatient(string search);
        Task SyncPatients(IEnumerable<Patient> patients);

        Task<Provider> LoadProvider(string providerId);
        Task<IEnumerable<Provider>> FindProvider(string search);
        Task SyncProviders(IEnumerable<Provider> providers);
    }
}
