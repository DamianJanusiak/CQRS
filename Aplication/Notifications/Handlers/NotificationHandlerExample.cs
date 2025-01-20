using MediatR;

namespace CQRS.Notifications.Handlers
{
    public class NotificationHandlerExample : INotificationHandler<Notification>
    {
        public Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notification 1 Example: {notification.Txt}");

            return Task.CompletedTask;
        }
    }
}
