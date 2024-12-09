namespace WebApi.Helpers.CurrentUser
{
    public interface ICurrentUserService
    {
        string? Name { get; }
        string? Email { get; }
        int? UserId { get; }
        string? Role { get; }
    }
}
