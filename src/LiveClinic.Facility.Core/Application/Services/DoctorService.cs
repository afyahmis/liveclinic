using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.ClinicManager.Core.Domain.Staff;
using LiveClinic.SharedKernel.Interfaces.Messaging;
using Serilog;

namespace LiveClinic.ClinicManager.Core.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IEventPublisher eventPublisher, IDoctorRepository doctorRepository)
        {
            _eventPublisher = eventPublisher;
            _doctorRepository = doctorRepository;
        }

        public async Task<Result<Doctor>> LoadDoctor(string doctorId)
        {
            try
            {
                var doctor = await _doctorRepository.Read(doctorId);

                return Result.Success(doctor);
            }
            catch (Exception e)
            {
                Log.Error("Load error", e);
                return Result.Failure<Doctor>(e.Message);
            }
        }

        public async Task<Result<IEnumerable<Doctor>>> LoadDoctors()
        {
            Log.Debug("Loading...");

            try
            {
                var doctors = await _doctorRepository.Read();

                return Result.Success(doctors);
            }
            catch (Exception e)
            {
                Log.Error("Load error", e);
                return Result.Failure<IEnumerable<Doctor>>(e.Message);
            }
        }

        public async Task<Result> HireDoctor(Doctor doctor)
        {
            Log.Debug($"Creating [{doctor}] ...");

            try
            {
                await _doctorRepository.Create(doctor);

                await _eventPublisher.Publish(doctor);

                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error("SetupClinic error", e);
                return Result.Failure(e.Message);
            }
        }

        public async Task<Result> RemoveDoctor(string doctorId)
        {
            Log.Debug($"deleting doctor [{doctorId}] ...");

            try
            {
                var existingDoctor = await _doctorRepository.Read(doctorId);

                if (null == existingDoctor)
                    throw new Exception($"Doctor does not Exist !");

                await _doctorRepository.Delete(existingDoctor);

                await _eventPublisher.Publish(existingDoctor);

                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error("Update error", e);
                return Result.Failure(e.Message);
            }
        }

        public async Task<Result> ChangeDoctorDetails(string doctorId, string firstName, string middleName, string lastName, string street, string city)
        {
            Log.Debug($"updating doctor [{doctorId}] ...");

            try
            {
                var existingDoctor = await _doctorRepository.Read(doctorId);

                if (null == existingDoctor)
                    throw new Exception($"Doctor does not Exist !");

                existingDoctor.ChangeDetails(firstName,middleName,lastName, street, city);

                await _doctorRepository.Update(existingDoctor);

                await _eventPublisher.Publish(existingDoctor);

                return Result.Success();
            }
            catch (Exception e)
            {
                Log.Error("Update error", e);
                return Result.Failure(e.Message);
            }
        }

        public async Task<Result> AdjustConsultationFee(string doctorId, decimal value, string currency)
        {
            Log.Debug($"updating doctor [{doctorId}] ...");

            try
            {
                var existingDoctor = await _doctorRepository.Read(doctorId);

                if (null == existingDoctor)
                    throw new Exception($"Doctor does not Exist !");

                existingDoctor.ChangeConsultationFee(value,currency);

                await _doctorRepository.Update(existingDoctor);

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