using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Servicio.Data;

var builder = WebApplication.CreateBuilder(args);

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(Program));
//// Configure AutoMapper
//builder.Services.AddAutoMapper(typeof(Program)); // Register AutoMapper

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

//CONFIGURACION DE SERVICIO DE ATENTICACION JWT
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
