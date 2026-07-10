using Microsoft.EntityFrameworkCore;
using KlippStyleSalon.Api.Data;

namespace KlippStyleSalon.Api.Endpoints;

public static class BookingEndpoints
{
    public static void MapBookingEndpoints (this WebApplication app)
    {
        app.MapGet("/bookings", async (AppDbContext db) =>
            await db.Bookings.ToListAsync());
    }
}