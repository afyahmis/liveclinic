using System;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.ClinicManager.Core.Domain.Facility;
using LiveClinic.SharedKernel.Interfaces.Messaging;
using Serilog;

namespace LiveClinic.ClinicManager.Core.Application.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IEventPublisher eventPublisher, IClinicRepository clinicRepository)
        {
            _eventPublisher = eventPublisher;
            _clinicRepository = clinicRepository;
        }

        public async Task<Result<Clinic>> Load()
        {
            Log.Debug("Loading...");
            try
            {
                var clinics = await _clinicRepository.Read();

                return Result.Success(clinics.FirstOrDefault());
            }
            catch (Exception e)
            {
                Log.Error("Load error", e);
                return Result.Failure<Clinic>(e.Message);
            }
        }

        public async Task<Result> SetupClinic(Clinic clinic)
        {
            Log.Debug($"Setting up [{clinic}] ...");
            try
            {
                var clinics = await _clinicRepository.Read();

                if (clinics.Any())
                    throw new Exception($"Clinic is already setup !");

                await _clinicRepository.Create(clinic);

                await _eventPublisher.Publish(clinic);

                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error("SetupClinic error", e);
                return Result.Failure(e.Message);
            }

        }

        public async Task<Result> ChangeClinicDetails(string clinicId, string name, string street, string city)
        {
            Log.Debug($"updating clinic [{clinicId}] ...");
            try
            {
                var existingClinic = await _clinicRepository.Read(clinicId);

                if (null == existingClinic)
                    throw new Exception($"Clinic does not Exist !");

                existingClinic.ChangeDetails(name, street, city);

                await _clinicRepository.Update(existingClinic);

                await _eventPublisher.Publish(existingClinic);

                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error("Update error", e);
                return Result.Failure(e.Message);
            }
        }

        public async Task<Result> AdjustServiceFee(string clinicId, double value, string currency = "USD")
        {
            Log.Debug($"updating clinic [{clinicId}] Fee ...");
            try
            {
                var existingClinic = await _clinicRepository.Read(clinicId);

                if (null == existingClinic)
                    throw new Exception($"Clinic does not Exist !");

                existingClinic.ChangeFee(value, currency);

                await _clinicRepository.Update(existingClinic);

                await _eventPublisher.Publish(existingClinic);

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
