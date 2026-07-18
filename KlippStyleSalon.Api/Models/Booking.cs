using System.ComponentModel.DataAnnotations;

namespace KlippStyleSalon.Api.Models;

public class Booking
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string HairDresser { get; set; } = string.Empty;

    [Required(ErrorMessage = "Firstname is required.")]
    public string CustomerFirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Lastname is required.")]
    public string CustomerLastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string CustomerPhonenumber { get; set; } = string.Empty;
}