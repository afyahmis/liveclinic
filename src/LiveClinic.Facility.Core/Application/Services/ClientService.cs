using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.ClinicManager.Core.Domain.Clients;
using LiveClinic.SharedKernel.Interfaces.Messaging;
using Serilog;

namespace LiveClinic.ClinicManager.Core.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IClientRepository _clientRepository;

        public ClientService(IEventPublisher eventPublisher, IClientRepository clientRepository)
        {
            _eventPublisher = eventPublisher;
            _clientRepository = clientRepository;
        }

        public async Task<Result<Client>> LoadClient(string clientId)
        {
            Log.Debug("Loading...");
            try
            {
                var patient = await _clientRepository.Read(clientId);

                return Result.Success(patient);
            }
            catch (Exception e)
            {
                Log.Error("Load error", e);
                return Result.Failure<Client>(e.Message);
            }
        }

        public async Task<Result<IEnumerable<Client>>> LoadClients()
        {
            Log.Debug("Loading...");
            try
            {
                var patients = await _clientRepository.Read();

                return Result.Success(patients);
            }
            catch (Exception e)
            {
                Log.Error("Load error", e);
                return Result.Failure<IEnumerable<Client>>(e.Message);
            }
        }

        public async Task<Result> EnrollClient(Client client)
        {
            Log.Debug($"Creating [{client}] ...");
            try
            {
                await _clientRepository.Create(client);

                await _eventPublisher.Publish(client);

                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error("SetupClinic error", e);
                return Result.Failure(e.Message);
            }
        }

        public async Task<Result> RemoveClient(string clientId)
        {
            Log.Debug($"Deleting patient [{clientId}] ...");
            try
            {
                var existingDoctor = await _clientRepository.Read(clientId);

                if (null == existingDoctor)
                    throw new Exception($"Doctor does not Exist !");

                existingDoctor.MarkAsDeleted();

                await _clientRepository.Update(existingDoctor);

                await _eventPublisher.Publish(existingDoctor);

                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error("Update error", e);
                return Result.Failure(e.Message);
            }
        }

        public async Task<Result> ChangeClientDetails(string clientId,DateTime registrationDate, string firstName, string middleName,
            string lastName, string street, string city, DateTime birthDate, string gender)
        {
            Log.Debug($"Updating Client [{clientId}] ...");
            try
            {
                var existingDoctor = await _clientRepository.Read(clientId);

                if (null == existingDoctor)
                    throw new Exception($"Doctor does not Exist !");

                existingDoctor.ChangeDetails(registrationDate, firstName, middleName, lastName, street, city, birthDate,
                    gender);

                await _clientRepository.Update(existingDoctor);

                await _eventPublisher.Publish(existingDoctor);

                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error("Update error", e);
                return Result.Failure(e.Message);
            }
        }
    }
}
