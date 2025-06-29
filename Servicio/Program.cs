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

// Configurar autenticación JWT (JSON Web Token)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Validar el emisor del token
            ValidateAudience = true, // Validar el público del token
            ValidateLifetime = true, // Validar que el token no haya expirado
            ValidateIssuerSigningKey = true, // Validar la clave de firma del token

            ValidIssuer = builder.Configuration["JWT:Issuer"], // Emisor válido
            ValidAudience = builder.Configuration["JWT:Audience"], // Público válido
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:ClaveSecreta"])), // Clave secreta simétrica
            ClockSkew = TimeSpan.Zero // Sin tolerancia en la expiración del token
        };
    });

// Configurar CORS para permitir solo ciertos orígenes
builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", policy =>
    {
        policy.WithOrigins("https://localhost:7153", 
            "https://curso2025-001-site1.anytempurl.com", 
            "https://calm-cliff-06a2d340f.6.azurestaticapps.net") // ? Dominios permitidos
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});




// Registrar controladores de la API
builder.Services.AddControllers();

// Habilitar generación de documentación con Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


// Habilitar middleware de Swagger para generar y mostrar la documentación de la API
app.UseSwagger();
app.UseSwaggerUI();

// Habilitar CORS sin restricciones
app.UseCors("Cors");
//app.UseCors(config =>
//{
//    config.AllowAnyOrigin();
//    config.AllowAnyMethod();
//    config.AllowAnyHeader();
//    config.WithExposedHeaders("*");
//});

// Habilitar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Mapear las rutas de los controladores
app.MapControllers();

// Ejecutar la aplicación
app.Run();
