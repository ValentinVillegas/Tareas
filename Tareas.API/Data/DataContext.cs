using Microsoft.EntityFrameworkCore;
using Tareas.Shared.Models;

namespace Tareas.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<RubroEncargados> RubrosEncargados { get; set; }
        public DbSet<UnidadNegocio> UnidadesNegocio { get; set; }
        public DbSet<Equipo> Equipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Departamento>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<Rubro>().HasIndex(x => x.Nombre).IsUnique();
        }
    }
}