using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonaFisica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaFisica.Infrastructure.Data
{
    public class UsuarioSistemaConfiguracion : IEntityTypeConfiguration<UsuarioSistema>
    {
        public void Configure(EntityTypeBuilder<UsuarioSistema> builder)
        {
            builder.ToTable("UsuarioSistema");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.Activo).HasDefaultValueSql("((1))");

            builder.Property(e => e.ApellidoMaterno)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ApellidoPaterno)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PassWord)
                .IsRequired()
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.Usuario)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
