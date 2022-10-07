using DSSD_2022_TP3.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace DSSD_2022_TP3
{
    public class AcademicaContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AcademicaContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materia>(model =>
            {
                model.HasKey(m => m.IdMateria);
                model.HasOne(m => m.Carrera).WithMany().HasForeignKey(m => m.IdCarrera);
            });
            modelBuilder.Entity<Usuario>(model =>
            {
                model.HasKey(m => m.IdUsuario);
                model.HasOne(m => m.Carrera).WithMany().HasForeignKey(m => m.IdCarrera);
                model.HasOne(m => m.TipoUsuario).WithMany().HasForeignKey(m => m.IdTipoUsuario);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Turno> Turnos { get; set; }
    }
}
