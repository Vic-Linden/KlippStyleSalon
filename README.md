# Klipp & Style Salon - Booking API

A school exercise: a backend booking system for a hair salon, built with **ASP.NET Core Minimal API**. Supports creating bookings, listing all bookings and cancelling them. 

## Tech Stack

- **Backend:** ASP.NET Core Minimal API (.NET 10)
- **Database:** SQL Server, Entity Framework Core (Code-First)
- **Validation:** Data Annotations
- **API Testing:** Scalar

## Project structure

KlippStyleSalon.Api/
├── Models/          # Data models (Booking)
├── Data/            # EF Core DbContext
├── Endpoints/       # API endpoint definitions
├── Migrations/      # EF Core migrations
└── Program.cs       

## API Endpoints

The API have three endpoints for managing bookings.

| Method | Endpoint | Description |
|--------|----------|--------------|
| `GET` | `/bookings` | Get a list of all bookings |
| `POST` | `/bookings` | Create a new booking |
| `DELETE` | `/bookings/{id}` | Cancel a booking by its ID |

**Creating a booking** requires a JSON body with the following fields: `date`, `time`, `hairDresser`, `customerFirstName`, `customerLastName`, and `customerPhonenumber`. The `id` is generated automatically and should not be included.

**Cancelling a booking** requires the booking's `id` in the URL. If no booking with that ID exists, the API responds with `404 Not Found`.

## Validation

When creating a booking, the following fields are required:

- **Customer first name** – cannot be empty
- **Customer last name** – cannot be empty
- **Customer phone number** – must be a valid phone number format

If any of these rules are broken, the API responds with `400 Bad Request` and a description of what went wrong.