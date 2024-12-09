

namespace Application.Common.DTOs.User
{
    public class LoginUserResponseDTOs
    {
        public int Id { get; set; }
        public string UserName { get; set; }    
        public string Email { get; set; }
        public string RefreshToken {  get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn {  get; set; }
    }
}
