using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonaFisica.Core.Entities;

#nullable disable

namespace PersonaFisica.Infrastructure.Data
{
    public partial class ExamenContext : DbContext
    {
        public ExamenContext()
        {
        }

        public ExamenContext(DbContextOptions<ExamenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbPersonasFisica> TbPersonasFisicas { get; set; }
        public virtual DbSet<UsuarioSistema> UsuarioSistemas { get; set; }
        public virtual DbSet<sp_Response> sp_EliminarPersonaFisica { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonaFisicaConfiguracion());
            modelBuilder.ApplyConfiguration(new UsuarioSistemaConfiguracion());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
