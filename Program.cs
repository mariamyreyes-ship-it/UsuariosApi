using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Services;
using UsuariosApi.Services.Interfaces;
using UsuariosApi.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Registrar DbContext con SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Usuarios API V1");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();