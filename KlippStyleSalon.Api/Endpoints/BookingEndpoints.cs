using Microsoft.EntityFrameworkCore;
using KlippStyleSalon.Api.Data;
using KlippStyleSalon.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace KlippStyleSalon.Api.Endpoints;

public static class BookingEndpoints
{
    public static void MapBookingEndpoints (this WebApplication app)
    {
        app.MapGet("/bookings", async (AppDbContext db) =>
            await db.Bookings.ToListAsync());

        app.MapPost("/bookings", async (Booking booking, AppDbContext db) =>
        {
            var context = new ValidationContext(booking);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(booking, context, results, true);

            if (!isValid)
            {
                return Results.BadRequest(results);
            }

            db.Bookings.Add(booking);
            await db.SaveChangesAsync();
            return Results.Created($"/bookings/{booking.Id}", booking);
        });

        app.MapDelete("/bookings/{id}", async (int id, AppDbContext db) =>
        {
            var booking = await db.Bookings.FindAsync(id);
            if (booking is null)
            {
                return Results.NotFound();
            }

            db.Bookings.Remove(booking);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}