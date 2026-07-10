using Microsoft.EntityFrameworkCore;
using KlippStyleSalon.Api.Data;
using KlippStyleSalon.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapBookingEndpoints();

app.Run();
