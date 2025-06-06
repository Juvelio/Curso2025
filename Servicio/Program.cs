using Microsoft.EntityFrameworkCore;
using Servicio.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

//agregamos servicios al contenedor
builder.Services.AddControllers();

// Copnfigurar Swagger/OpenAPI para documentar la API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");



app.UseSwagger(); // Habilitar Swagger
app.UseSwaggerUI(); // Habilitar la interfaz de usuario de Swagger

//aConfigurar la canalizacion de solicitudes HTTP.
app.MapControllers();
app.Run();
