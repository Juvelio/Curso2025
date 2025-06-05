using Microsoft.EntityFrameworkCore;
using Servicio.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

//agregamos servicios al contenedor
builder.Services.AddControllers();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//aConfigurar la canalizacion de solicitudes HTTP.
app.MapControllers();
app.Run();
