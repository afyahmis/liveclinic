using System;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClientManager.Core.Domain
{
    public class Consultation : Entity<int>
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Notes { get; set; }
        public string VisitId { get; set; }
        public string DoctorId { get; set; }
    }
}
