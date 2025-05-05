using Microsoft.EntityFrameworkCore;
using EventViewProvider.Models;

namespace EventViewProvider.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Event> Events { get; set; } = null!;
}
