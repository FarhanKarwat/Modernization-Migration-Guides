using Microsoft.EntityFrameworkCore;
using ModernizedApi.Models;

namespace ModernizedApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<User> Users => Set<User>();
}
