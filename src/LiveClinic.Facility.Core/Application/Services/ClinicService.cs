using System;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.ClinicManager.Core.Domain.Facility;
using Serilog;

namespace LiveClinic.ClinicManager.Core.Application.Services
{
    public class ClinicService:IClinicService
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public async Task<Result<Clinic>> Load()
        {
            try
            {
                var clinics =await _clinicRepository.Read();
                return Result.Success(clinics.FirstOrDefault());
            }
            catch (Exception e)
            {
                Log.Error("Load error", e);
                return Result.Failure<Clinic>(e.Message);
            }
            
        }

        public async Task<Result> Setup(Clinic clinic)
        {
            try
            {
                var clinics =  await _clinicRepository.Read();

                if (clinics.Any())
                    throw new Exception($"Clinic is already setup !");
                
                await _clinicRepository.Create(clinic);

                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error("Setup error", e);
                return Result.Failure(e.Message);
            }
            
        }

        public async Task<Result> UpdateDetails(string clinicId, string name, string street, string city)
        {
            try
            {
                var existingClinic = await _clinicRepository.Read(clinicId);

                if (null == existingClinic)
                    throw new Exception($"Clinic does not Exist !");

                existingClinic.ChangeDetails(name, street, city);

                await _clinicRepository.Update(existingClinic);
                
                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error("Update error", e);
                return Result.Failure(e.Message);
            }
        }

        public async Task<Result> UpdateFee(string clinicId, decimal value, string currency)
        {
            try
            {
                var existingClinic = await _clinicRepository.Read(clinicId);

                if (null == existingClinic)
                    throw new Exception($"Clinic does not Exist !");

                existingClinic.ChangeFee(value, currency);

                await _clinicRepository.Update(existingClinic);
                
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