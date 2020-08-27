using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.ClinicManager.Core.Domain.Staff;

namespace LiveClinic.ClinicManager.Core.Application.Services
{
    public interface IDoctorService
    {
        Task<Result<Doctor>> LoadDoctor(string doctorId);
        Task<Result<IEnumerable<Doctor>>> LoadDoctors();
        Task<Result> HireDoctor(Doctor doctor);
        Task<Result> RemoveDoctor(string doctorId);
        Task<Result> ChangeDoctorDetails(string doctorId, string firstName, string middleName, string lastName, string street, string city);
        Task<Result> AdjustConsultationFee(string doctorId, decimal value, string currency);
    }
}