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
    public class PersonaFisicaConfiguracion : IEntityTypeConfiguration<TbPersonasFisica>
    {
        public void Configure(EntityTypeBuilder<TbPersonasFisica> builder)
        {
            builder.HasKey(e => e.IdPersonaFisica);

            builder.ToTable("Tb_PersonasFisicas");

            builder.Property(e => e.Activo).HasDefaultValueSql("((1))");

            builder.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FechaActualizacion).HasColumnType("datetime");

            builder.Property(e => e.FechaNacimiento).HasColumnType("date");

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RFC");
        }
    }
}
