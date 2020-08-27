using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Application.Events
{
    public class DoctorDetailsUpdated : DomainEvent
    {
        public string DoctorId { get; }

        public DoctorDetailsUpdated(string doctorId)
        {
            DoctorId = doctorId;
        }
    }
}