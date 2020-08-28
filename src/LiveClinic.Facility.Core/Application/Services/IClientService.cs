using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.ClinicManager.Core.Domain.Clients;

namespace LiveClinic.ClinicManager.Core.Application.Services
{
    public interface IClientService
    {
        Task<Result<Client>> LoadClient(string clientId);
        Task<Result<IEnumerable<Client>>> LoadClients();
        Task<Result<IEnumerable<Client>>> SearchClients(string search);
        Task<Result> EnrollClient(Client client);
        Task<Result> RemoveClient(string clientId);
        Task<Result> ChangeClientDetails(string clientId,DateTime registrationDate, string firstName, string middleName,
            string lastName, string street, string city, DateTime birthDate, string gender);
    }
}
