using Microsoft.EntityFrameworkCore;
using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Registro> Registro { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Curso>()
                .HasMany(x => x.Profesores).WithMany(x => x.Cursos)
                .UsingEntity<Dictionary<string, object>>(
                    "CursoProfesor",
                    x => x.HasOne<Profesor>().WithMany().HasForeignKey("ProfesorId"),
                    x => x.HasOne<Curso>().WithMany().HasForeignKey("CursoId"),
                    x =>
                    {
                        x.HasKey("CursoId", "ProfesorId");
                        x.ToTable("CursoProfesor");
                    }
                );
        }
    }
}
