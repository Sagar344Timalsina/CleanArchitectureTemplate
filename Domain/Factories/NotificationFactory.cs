using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Factories;

public class NotificationFactory
{
    public Notification CreateNotification(string type, string message, int userId, NotificationType notificationTypetype)
    {
        return new Notification
        {
            Type = type,
            Message = message,
            UserId = userId
        };
    }
}