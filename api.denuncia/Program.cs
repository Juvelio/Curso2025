using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using api.denuncia.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<apidenunciaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("apidenunciaContext") ?? throw new InvalidOperationException("Connection string 'apidenunciaContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Copnfigurar Swagger/OpenAPI para documentar la API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger(); // Habilitar Swagger
app.UseSwaggerUI(); // Habilitar la interfaz de usuario de Swagger

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
