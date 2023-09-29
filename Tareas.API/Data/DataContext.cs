using Microsoft.EntityFrameworkCore;
using Tareas.Shared.Models;

namespace Tareas.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<RubroEncargados> RubrosEncargados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rubro>().HasIndex(x => x.Nombre).IsUnique();
        }
    }
}
