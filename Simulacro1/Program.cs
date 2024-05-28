using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Simulacro1.Data;
using Simulacro1.Interfaces;
using Simulacro1.Services;

var builder = WebApplication.CreateBuilder(args);

// Método para configurar y agregar un contexto de base de datos
void AddCustomDbContext<TContext>(string connectionString) where TContext : DbContext
{
    builder.Services.AddDbContext<TContext>(options =>
        options.UseMySql(
            connectionString,
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
        )
    );
}

// Agrega los contextos de base de datos
AddCustomDbContext<BaseContext>(builder.Configuration.GetConnectionString("MySqlConnection"));


// Registro de servicios
    builder.Services.AddScoped<AuthorService>();
    builder.Services.AddScoped<IAuthorService, AuthorService>();
    builder.Services.AddScoped<BookService>();
    builder.Services.AddScoped<IBookService, BookService>();
    builder.Services.AddScoped<EditorialService>();
    builder.Services.AddScoped<IEditorialService, EditorialService>();






// Configuración de los controladores
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// Configuración de la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración para entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Libros API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
