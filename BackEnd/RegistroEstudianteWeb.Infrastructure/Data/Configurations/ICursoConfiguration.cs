using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Infrastructure.Data.Configurations
{
    public class ICursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder
                .HasKey(x => x.CursoId);
            builder
                .Property(x => x.CursoId)
                .UseIdentityColumn();
            builder
                .Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(x => x.Creditos)
                .HasColumnName("Creditos")
                .IsRequired();  

            builder.ToTable("Curso");
        }
    }
}
