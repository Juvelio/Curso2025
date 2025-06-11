using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Servicio.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Registrar AutoMapper para mapeo de objetos entre capas
builder.Services.AddAutoMapper(typeof(Program));

// Configurar el contexto de base de datos con SQL Server usando Entity Framework Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

// Configurar autenticaci�n JWT (JSON Web Token)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Validar el emisor del token
            ValidateAudience = true, // Validar el p�blico del token
            ValidateLifetime = true, // Validar que el token no haya expirado
            ValidateIssuerSigningKey = true, // Validar la clave de firma del token

            ValidIssuer = builder.Configuration["JWT:Issuer"], // Emisor v�lido
            ValidAudience = builder.Configuration["JWT:Audience"], // P�blico v�lido
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:ClaveSecreta"])), // Clave secreta sim�trica
            ClockSkew = TimeSpan.Zero // Sin tolerancia en la expiraci�n del token
        };
    });

// Configurar CORS para permitir solo ciertos or�genes
builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", policy =>
    {
        policy.WithOrigins("https://miapp.com", "https://localhost:7057", "https://localhost:7027") // ? Dominios permitidos
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


// Registrar controladores de la API
builder.Services.AddControllers();

// Habilitar generaci�n de documentaci�n con Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


// Habilitar middleware de Swagger para generar y mostrar la documentaci�n de la API
app.UseSwagger(); 
app.UseSwaggerUI();

// Habilitar CORS sin restricciones
app.UseCors("Cors");

// Habilitar autenticaci�n y autorizaci�n
app.UseAuthentication();
app.UseAuthorization();

// Mapear las rutas de los controladores
app.MapControllers();

// Ejecutar la aplicaci�n
app.Run();
