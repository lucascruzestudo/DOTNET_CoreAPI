using MediatR;

namespace Project.Domain.Notifications
{
    public class DomainSuccessNotificationHandler : INotificationHandler<DomainSuccessNotification>
    {
        private List<DomainSuccessNotification> _notifications;

        public DomainSuccessNotificationHandler()
        {
            _notifications = [];
        }

        public Task Handle(DomainSuccessNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public virtual List<DomainSuccessNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotification()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = [];
        }
    }
}