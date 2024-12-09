using WebApi.Helpers.CurrentUser;
using System.Security.Claims;

namespace WebApi.Helpers.CurrentUser
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Name = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            Email=_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            UserId = string.IsNullOrEmpty(_httpContextAccessor.HttpContext?.User?.FindFirstValue("UserId"))
                              ? null
                              : Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirstValue("UserId"));
            Role = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
        }
        public string? Name { get; }

        public string? Email { get; }

        public int? UserId { get; }

        public string? Role { get; }
    }
}
