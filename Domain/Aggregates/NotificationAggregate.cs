using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class NotificationAggregate
{
    public Notification Notification { get; set; }
    public User User { get; set; }
    public NotificationType Type { get; set; }

    public void sendNotification()
    {
        
    }
}