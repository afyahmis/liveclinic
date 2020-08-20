using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClientManager.Core.Domain
{
    public class Observation:Entity<long>
    {
        public string Notes { get; set; }
        public string DoctorId { get; set; }
        public string EncounterId { get; set; }
    }
}
