using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Application.Events
{
    public class DoctorDeleted : DomainEvent
    {
        public string DoctorId { get; }

        public DoctorDeleted(string doctorId)
        {
            DoctorId = doctorId;
        }
    }
}