using Microsoft.EntityFrameworkCore;
using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Infrastructure.Data.Configurations
{
    public class IRegistroConfiguration : IEntityTypeConfiguration<Registro>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Registro> builder)
        {
            builder.HasKey(e => e.RegistroId);

            builder.Property(e => e.RegistroId)
                .UseIdentityColumn();


            builder.Property(e => e.CursoId)
                .HasColumnName("CursoId")
                .IsRequired();

            builder.Property(e => e.EstudianteId)
                .HasColumnName("CursoId")
                .IsRequired();

            builder.Property(e => e.Nota)
                .HasColumnName("Nota")
                .IsRequired();

            builder.ToTable("Registro");
        }
    }
}
