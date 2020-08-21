using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.ClinicManager.Core.Domain.Facility;

namespace LiveClinic.ClinicManager.Core.Application.Services
{
    public interface IClinicService
    {
        Task<Result<Clinic>> Load();
        Task<Result> Setup(Clinic clinic);
        Task<Result> UpdateDetails(string clinicId, string name, string street, string city);
        Task<Result> UpdateFee(string clinicId, decimal value, string currency);
    }
}