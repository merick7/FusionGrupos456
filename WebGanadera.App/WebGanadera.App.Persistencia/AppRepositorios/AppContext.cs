using Microsoft.EntityFrameworkCore;
using WebGanadera.App.Dominio;

namespace WebGanadera.App.Persistencia{
    public class AppContext: DbContext{
        public DbSet <Persona> Personas { get; set; }
        public DbSet <Ganadero> Ganaderos { get; set; }
        public DbSet <Ganado> Ganado { get; set; }
        public DbSet <GanadoCitaMedica> GanadoControl { get; set; }
        public DbSet <HistoriaClinica> Historia { get; set; }
        public DbSet <Veterinario> veterinario { get; set; }
        public DbSet <Vacuna> vacuna { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //Se usa para configurarlo inicialmente, conexión a la DB
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Data source = (localdb)\\MSSQLLocalDB; Initial Catalog = InfoWebGanadera");
            }
        }
    }
}