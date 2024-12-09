using Domain.Entities;

namespace Domain.Services;

public interface INotificationService
{
    Task SendNotificationAsync(Notification notification);
}