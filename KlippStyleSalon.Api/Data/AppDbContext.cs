using Microsoft.EntityFrameworkCore;
using KlippStyleSalon.Api.Models;

namespace KlippStyleSalon.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
    {
        
    }

    public DbSet<Booking> Bookings { get; set; }
}
