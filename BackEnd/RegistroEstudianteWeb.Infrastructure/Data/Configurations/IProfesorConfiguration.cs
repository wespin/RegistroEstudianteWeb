using Microsoft.EntityFrameworkCore;
using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Infrastructure.Data.Configurations
{
    public class IProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Profesor> builder)
        {
            builder.HasKey(e => e.ProfesorId);

            builder.Property(e => e.ProfesorId)
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

            builder.Property(e => e.FechaContratacion)
                .HasColumnName("FechaContratacion")
                .HasColumnType("date")
                .IsRequired();  


            builder.ToTable("Profesor");
        }
    }
}
