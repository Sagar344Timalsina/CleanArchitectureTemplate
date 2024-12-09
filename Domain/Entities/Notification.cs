using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class Notification:BaseAuditableEntity
{
    [Key]
    public int Id { get; set; }
    public string Type { get; set; }
    public string Message { get; set; }
    public bool IsLive { get; set; }
    public bool IsSent { get; set; } = false;
    public bool IsRead { get; set; }=false;
    public int UserId { get; set; }
    public User User { get; set; }
}