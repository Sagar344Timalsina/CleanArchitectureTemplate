using Domain.Entities;


namespace Domain.Interfaces
{
    public interface IUserRepositories
    {
        Task<(IEnumerable<User> Users, int TotalRecords)> GetUsersPagedAsync(
        int pageNumber,
        int pageSize,
        string? sortColumn = null,
        string? sortDirection = null,
        IDictionary<string, string>? filters = null);
        Task<User> GetUserById( int Id);
        Task<User> addUser(User user);
        Task<User> getUserByEmail(string email);
        Task<bool> updateAsync(User user);
    }
}
