using Microsoft.EntityFrameworkCore;
using nettrip_api.Data;
using nettrip_api.DTO;
using nettrip_api.Model;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNpgsql<AppDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));


var app = builder.Build();


app.MapGet("/api/bus", async (AppDbContext db) =>
{
    var buses = await db.buses.AsNoTracking().ToListAsync();
    return Results.Ok(buses);
});
app.MapGet("/api/buses/{id:guid}", async (AppDbContext db, Guid id) => {
    var bus = await db.buses.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
    if (bus == null) {
        return Results.NotFound();
    }
    return Results.Ok(bus);
});

app.MapPost("/api/buses", async (AppDbContext db, CreateBusRequest request) =>
{
    var bus = new Bus
    {
        Id = Guid.NewGuid(),
        Name = request.Name,
        RegistrationNumber = request.RegistrationNumber,
        TotalSeats = request.TotalSeats
    };
    db.buses.Add(bus);

    for (int i = 1; i <= request.TotalSeats; i++) {
        var row = (i - 1) / 4 + 1; // Assuming 4 seats per row
        var column = (i - 1) % 4;

        var seatNumber = $"{row}{(char)('A' + column)}"; 

        var seat = new Seat {
            Id = Guid.NewGuid(),
            BusId = bus.Id,
            SeatNumber = seatNumber,
            SeatType = "Regular"
        };
        db.seats.Add(seat);
    }

    await db.SaveChangesAsync();

    var response = new BusResponse {
        Id = bus.Id,
        Name = bus.Name,
        RegistrationNumber = bus.RegistrationNumber,
        TotalSeats = bus.TotalSeats,
        Status = bus.Status
    };

    return Results.Created($"/api/buses/{bus.Id}", response);
});
app.MapPut("/api/buses/{id:guid}", async (AppDbContext db, Guid id, UpdateBusRequest request) => {
    var bus = await db.buses.FirstOrDefaultAsync(b => b.Id == id);
    if (bus == null) {
        return Results.NotFound();
    }
    bus.Name = request.Name;
    bus.RegistrationNumber = request.RegistrationNumber;
    bus.TotalSeats = request.TotalSeats;
    await db.SaveChangesAsync();
    return Results.Ok(bus);
});
app.MapDelete("/api/buses/{id:guid}", async (AppDbContext db, Guid id) => {
    var bus = await db.buses.FirstOrDefaultAsync(b => b.Id == id);
    if (bus == null) {
        return Results.NotFound();
    }
    db.buses.Remove(bus);
    await db.SaveChangesAsync();
    return Results.NoContent();
});



app.Run();


