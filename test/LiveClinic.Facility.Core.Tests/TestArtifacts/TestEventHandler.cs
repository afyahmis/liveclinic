using System.Threading;
using System.Threading.Tasks;
using LiveClinic.ClinicManager.Core.Application.Events;
using MediatR;
using Serilog;

namespace LiveClinic.ClinicManager.Core.Tests.TestArtifacts
{
    public class TestEventHandler:INotificationHandler<ClientCreated>,
        INotificationHandler<ClientDeleted>,
        INotificationHandler<ClientDetailsUpdated>,
        INotificationHandler<ClinicCreated>,
        INotificationHandler<ClinicDetailsUpdated>,
        INotificationHandler<DoctorCreated>,
        INotificationHandler<DoctorDetailsUpdated>,
        INotificationHandler<DoctorDeleted>
        
    {
        public Task Handle(ClientCreated notification, CancellationToken cancellationToken)
        {
            Log.Debug($"{nameof(ClientCreated)} {notification.PatientId}");
            return Task.CompletedTask;
        }

        public Task Handle(ClientDeleted notification, CancellationToken cancellationToken)
        {
            Log.Debug($"{nameof(ClientCreated)} {notification.PatientId}");
            return Task.CompletedTask;
        }

        public Task Handle(ClientDetailsUpdated notification, CancellationToken cancellationToken)
        {
            Log.Debug($"{nameof(ClientCreated)} {notification.PatientId}");
            return Task.CompletedTask;
        }

        public Task Handle(ClinicCreated notification, CancellationToken cancellationToken)
        {
            Log.Debug($"{nameof(ClinicCreated)} {notification.ClinicId}");
            return Task.CompletedTask;
        }

        public Task Handle(ClinicDetailsUpdated notification, CancellationToken cancellationToken)
        {
            Log.Debug($"{nameof(ClinicDetailsUpdated)} {notification.ClinicId}");
            return Task.CompletedTask;
        }

        public Task Handle(DoctorCreated notification, CancellationToken cancellationToken)
        {
            Log.Debug($"{nameof(DoctorCreated)} {notification.DoctorId}");
            return Task.CompletedTask;
        }

        public Task Handle(DoctorDetailsUpdated notification, CancellationToken cancellationToken)
        {
            Log.Debug($"{nameof(DoctorDetailsUpdated)} {notification.DoctorId}");
            return Task.CompletedTask;
        }

        public Task Handle(DoctorDeleted notification, CancellationToken cancellationToken)
        {
            Log.Debug($"{nameof(DoctorDeleted)} {notification.DoctorId}");
            return Task.CompletedTask;
        }
    }
}