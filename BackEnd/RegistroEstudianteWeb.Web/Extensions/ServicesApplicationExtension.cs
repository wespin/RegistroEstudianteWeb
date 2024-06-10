using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RegistroEstudianteWeb.Core.Interfaces.Repositories;
using RegistroEstudianteWeb.Core.Interfaces.Services;
using RegistroEstudianteWeb.Core.Interfaces;
using RegistroEstudianteWeb.Infrastructure.Data;
using RegistroEstudianteWeb.Infrastructure.Repositories;
using RegistroEstudianteWeb.Services;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using RegistroEstudianteWeb.Api.Errors;

namespace RegistroEstudianteWeb.Api.Extensions
{
    public static class ServicesApplicationExtension
    {
        public static IServiceCollection AddServicesApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Ingresar Bearer [espacio] token \r\n\r\n " +
                                  "Ejemplo: Bearer + 1 espacio + TokenKey",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("RegistroEstudianteWebConnection"),
                                                           b => b.MigrationsAssembly("RegistroEstudianteWeb.Infrastructure")
                );
            });


            services.AddCors();


            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped(typeof(IProfesorRepository), typeof(ProfesorRepository));
            services.AddScoped(typeof(IProfesorService), typeof(ProfesorService));

            services.AddScoped(typeof(IEstudianteRepository), typeof(EstudianteRepository));
            services.AddScoped(typeof(IEstudianteService), typeof(EstudianteService));

            services.AddScoped(typeof(ICursoRepository), typeof(CursoRepository));
            services.AddScoped(typeof(ICursoService), typeof(CursoService));

            services.AddScoped(typeof(IRegistroRepository), typeof(RegistroRepository));
            services.AddScoped(typeof(IRegistroService), typeof(RegistroService));

            services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));

            services.AddScoped(typeof(ITokenService), typeof(TokenService));


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                    .Where(e => e.Value.Errors.Count > 0)
                                    .SelectMany(x => x.Value.Errors)
                                    .Select(y => y.ErrorMessage)
                                    .ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {                        
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
