using ApiBook.Core.Domain.Settings;
using ApiBook.Core.Application.Interfaces;
using ApiBook.Core.Application.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Cargar configuración de appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Configurar opciones
builder.Services.Configure<ExternalApiSettings>(
    builder.Configuration.GetSection("ExternalApiSettings"));

// Configurar Newtonsoft.Json
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.TypeNameHandling = TypeNameHandling.All;
    });

// Habilitar soporte para restricciones de rutas como regex
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap["regex"] = typeof(Microsoft.AspNetCore.Routing.Constraints.RegexInlineRouteConstraint);
});

// Registrar HttpClient e inyectarlo en los servicios
builder.Services.AddHttpClient<IBookInterface, BookServices>();
builder.Services.AddHttpClient<IAutorInterface, AutorServices>();

// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();  // /swagger
}

app.UseHttpsRedirection();

// Mapear controladores
app.MapControllers();

app.Run();
