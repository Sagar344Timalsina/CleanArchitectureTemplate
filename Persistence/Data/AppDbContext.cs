using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
{
  public DbSet<Notification> Notifications { get; set; }
  public DbSet<User> Users { get; set; }
}