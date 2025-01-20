using MediatR;

namespace CQRS.Notifications.Handlers
{
    public class NotificationHandlerExample2 : INotificationHandler<Notification>
    {
        public Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notification 2 Example: {notification.Txt}");

            return Task.CompletedTask;
        }
    }
}
