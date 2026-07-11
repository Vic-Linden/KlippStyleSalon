using Microsoft.EntityFrameworkCore;
using KlippStyleSalon.Api.Data;
using KlippStyleSalon.Api.Models;

namespace KlippStyleSalon.Api.Endpoints;

public static class BookingEndpoints
{
    public static void MapBookingEndpoints (this WebApplication app)
    {
        app.MapGet("/bookings", async (AppDbContext db) =>
            await db.Bookings.ToListAsync());

        app.MapPost("/bookings", async (Booking booking, AppDbContext db) =>
        {
            db.Bookings.Add(booking);
            await db.SaveChangesAsync();
            return Results.Created($"/bookings/{booking.Id}", booking);
        });
    }
}