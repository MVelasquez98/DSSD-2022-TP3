using DSSD_2022_TP3.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace DSSD_2022_TP3.Repository
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
                model.Property(m => m.Nombre).IsRequired(false);
                model.Property(m => m.Apellido).IsRequired(false);
                model.Property(m => m.Dni).IsRequired(false);
                model.Property(m => m.Celular).IsRequired(false);
                model.Property(m => m.Correo).IsRequired(false);


            });
            modelBuilder.Entity<Inscripcion>(model =>
            {
                model.HasKey(m => m.IdInscripcion);
                model.HasOne(m => m.Instancia).WithMany().HasForeignKey(m => m.IdInstancia);
            });
            modelBuilder.Entity<Comision>(model =>
            {
                model.HasKey(m => m.IdComision);
                model.HasOne(m => m.Inscripcion).WithMany().HasForeignKey(m => m.IdInscripcion);
                model.HasOne(m => m.Turno).WithMany().HasForeignKey(m => m.IdTurno);
                model.HasOne(m => m.Materia).WithMany().HasForeignKey(m => m.IdMateria);
                model.HasOne(m => m.Usuario).WithMany().HasForeignKey(m => m.IdUsuario);
                model.HasOne(m => m.Dia).WithMany().HasForeignKey(m => m.IdDia);
                model.Property(m => m.Fecha).IsRequired(false);
            });

            modelBuilder.Entity<DetalleInscripcion>(model =>
            {
                model.HasKey(m => m.Id);
                model.HasOne(m => m.Inscripcion).WithMany().HasForeignKey(m => m.IdInscripcion);
                model.HasOne(m => m.Comision).WithMany().HasForeignKey(m => m.IdComision);
                model.HasOne(m => m.Usuario).WithMany().HasForeignKey(m => m.IdUsuario);
            });

            modelBuilder.Entity<NotaComision>(model =>
            {
                model.HasKey(m => m.Id);
                model.HasOne(m => m.Usuario).WithMany().HasForeignKey(m => m.IdUsuario);
                model.HasOne(m => m.TipoNota).WithMany().HasForeignKey(m => m.IdTipoNota);
                model.HasOne(m => m.Comision).WithMany().HasForeignKey(m => m.IdComision);

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
        public DbSet<Dia> Dias { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<DetalleInscripcion> DetalleInscripciones { get; set; }
        public DbSet<TipoNota> TipoNotas { get; set; }
        public DbSet<NotaComision> NotasComisiones { get; set; }
    }
}
