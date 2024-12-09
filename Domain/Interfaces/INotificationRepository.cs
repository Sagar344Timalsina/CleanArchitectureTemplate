using Domain.Entities;

namespace Domain.Interfaces;

public interface INotificationRepository
{
    Task<Notification> GetByIdAsync(int Id);
    Task<IEnumerable<Notification>> GetNotificationForUserAsync(int UserId);
    Task AddAsync(Notification notification);
}