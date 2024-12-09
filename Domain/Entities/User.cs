using Domain.Common;

namespace Domain.Entities;

public class User:BaseAuditableEntity
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string RefreshToken {  get; set; }
    public DateTime RefreshTokenExpiryDate { get; set; }
}