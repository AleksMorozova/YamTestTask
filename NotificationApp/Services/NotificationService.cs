using NotificationApp.Models;

namespace NotificationApp.Services;

public interface INotificationService
{
    public void ReceiveNotification(NotificationRequest request);
}
public class NotificationService : INotificationService
{
    public void ReceiveNotification(NotificationRequest request)
    {
        // add logic for consuming notification
    }
}
