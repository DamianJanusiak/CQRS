using MediatR;

namespace CQRS.Notifications
{
    public class Notification : INotification
    {
        public string Txt { get; set; }
    }
}
