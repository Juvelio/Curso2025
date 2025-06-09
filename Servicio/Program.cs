using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Servicio.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Configurar automapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

//CONFIFIGURACION DE SERVICIO DE AUTENTICACION JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:ClaveSecreta"])),
            ClockSkew = TimeSpan.Zero
        };
    });

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
