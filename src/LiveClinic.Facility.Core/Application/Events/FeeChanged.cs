using LiveClinic.ClinicManager.Core.Domain.Common;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.ClinicManager.Core.Application.Events
{
    public class FeeChanged : DomainEvent
    {
        public FeeType FeeType { get; }
        public string RefId { get; }

        public FeeChanged(FeeType feeType, string refId)
        {
            FeeType = feeType;
            RefId = refId;
        }
    }
}