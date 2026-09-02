using nettrip_api.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNpgsql<AppDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));


var app = builder.Build();


app.Run();


