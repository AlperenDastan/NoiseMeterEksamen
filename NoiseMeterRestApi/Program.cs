using Microsoft.EntityFrameworkCore;
using NoiseMeterLib.Contexts;
using NoiseMeterLib.Models;
using NoiseMeterRestApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<InMemoryDBContext>(o =>
{
    o.UseInMemoryDatabase("NoiseMeters");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Enable Swagger in non-development environments for testing purposes. 
// Remember to restrict this in production for security reasons.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
