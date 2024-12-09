using Domain.Entities;
using Domain.Services;

namespace Domain.Events;

public class NotificationSentEvent
{
    public Notification Notification { get; }

    public NotificationSentEvent(Notification notification)
    {
        Notification = notification;
    }
}