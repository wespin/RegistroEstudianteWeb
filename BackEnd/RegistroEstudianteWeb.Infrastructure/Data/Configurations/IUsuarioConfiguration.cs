using Microsoft.EntityFrameworkCore;
using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Infrastructure.Data.Configurations
{
    public class IUsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn();


            builder.Property(e => e.NombreUsuario)
                .HasColumnName("NombreUsuario")
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                .HasColumnName("PasswordHash")
                .IsRequired();

            builder.Property(e => e.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .IsRequired();

            builder.ToTable("Usuario");
        }

    }
}
