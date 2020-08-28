using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.ClinicManager.Core.Domain.Clients;

namespace LiveClinic.ClinicManager.Core.Application.Services
{
    public interface IClientService
    {
        Task<Result<Client>> LoadPatient(string patientId);
        Task<Result<IEnumerable<Client>>> LoadPatients();
        Task<Result> EnrollPatient(Client client);
        Task<Result> RemovePatient(string patientId);

        Task<Result> ChangePatientDetails(string patientId,DateTime registrationDate, string firstName, string middleName,
            string lastName, string street, string city, DateTime birthDate, string gender);
    }
}