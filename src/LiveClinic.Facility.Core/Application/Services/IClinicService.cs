using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.ClinicManager.Core.Domain.Common;
using LiveClinic.ClinicManager.Core.Domain.Facility;

namespace LiveClinic.ClinicManager.Core.Application.Services
{
    public interface IClinicService
    {
        Task<Result<Clinic>> Load();
        Task<Result> SetupClinic(Clinic clinic);
        Task<Result> ChangeClinicDetails(string clinicId, string name, string street, string city);
        Task<Result> AdjustServiceFee(string clinicId, decimal value, string currency);
    }
}