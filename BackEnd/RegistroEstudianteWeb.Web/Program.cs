using RegistroEstudianteWeb.Core.Interfaces.Repositories;
using RegistroEstudianteWeb.Core.Interfaces;
using RegistroEstudianteWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using RegistroEstudianteWeb.Infrastructure.Repositories;
using RegistroEstudianteWeb.Core.Interfaces.Services;
using RegistroEstudianteWeb.Services;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RegistroEstudianteWebConnection"),
                                               b => b.MigrationsAssembly("RegistroEstudianteWeb.Infrastructure")
    );
});

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped(typeof(IProfesorRepository), typeof(ProfesorRepository));
builder.Services.AddScoped(typeof(IProfesorService), typeof(ProfesorService));

builder.Services.AddScoped(typeof(IEstudianteRepository), typeof(EstudianteRepository));
builder.Services.AddScoped(typeof(IEstudianteService), typeof(EstudianteService));

builder.Services.AddScoped(typeof(ICursoRepository), typeof(CursoRepository));
builder.Services.AddScoped(typeof(ICursoService), typeof(CursoService));

builder.Services.AddScoped(typeof(IRegistroRepository), typeof(RegistroRepository));
builder.Services.AddScoped(typeof(IRegistroService), typeof(RegistroService));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast =  Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.Run();

//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
