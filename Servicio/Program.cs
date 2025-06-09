using Microsoft.EntityFrameworkCore;
using Servicio.Data;

var builder = WebApplication.CreateBuilder(args);

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(Program));
//// Configure AutoMapper
//builder.Services.AddAutoMapper(typeof(Program)); // Register AutoMapper

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

//agregamos servicios al contenedor
builder.Services.AddControllers();

// Configurar Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Configure la canalización de solicitudes HTTP. 
app.UseSwagger();
app.UseSwaggerUI();

//aConfigurar la canalizacion de solicitudes HTTP.
app.MapControllers();
app.Run();
