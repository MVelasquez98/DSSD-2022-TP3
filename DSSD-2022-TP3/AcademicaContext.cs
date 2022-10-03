using DSSD_2022_TP3.Model;
using Microsoft.EntityFrameworkCore;

namespace DSSD_2022_TP3
{
    public class AcademicaContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public AcademicaContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}
