using Microsoft.EntityFrameworkCore;
using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Infrastructure.Data.Configurations
{
    public class IEstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Estudiante> builder)
        {
            builder.HasKey(e => e.EstudianteId);

            builder
                .Property(x => x.EstudianteId)
                .UseIdentityColumn();

            builder.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Apellido)
                .HasColumnName("Apellido")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.FechaRegistro)
                .HasColumnName("FechaRegistro")
                .HasColumnType("date")
                .IsRequired();




        }
    }
}
