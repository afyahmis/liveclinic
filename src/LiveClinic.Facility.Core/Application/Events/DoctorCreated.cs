using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Application.Events
{
    public class DoctorCreated : DomainEvent
    {
        public string DoctorId { get; }

        public DoctorCreated(string doctorId)
        {
            DoctorId = doctorId;
        }
    }
}