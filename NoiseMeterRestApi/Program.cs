using Microsoft.EntityFrameworkCore;
using NoiseMeterLib.Contexts;
using NoiseMeterLib.Models;
using NoiseMeterRestApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SqlServerDbContext>(o =>
{
    o.UseSqlServer(@"Server=tcp:mssql-server-100k-free.database.windows.net,1433;Initial Catalog=NoiseMeterDb;Persist Security Info=False;User ID=msssql;Password=Qgn45wtc!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOriginPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AnyOriginPolicy");

// Configure the HTTP request pipeline.

// Enable Swagger in non-development environments for testing purposes. 
// Remember to restrict this in production for security reasons.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
