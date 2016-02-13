using Microsoft.Data.Entity;

namespace NinjaLab.Azure.Domain
{
    public class FutbolModel : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Jugador> Jugadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:h7w8d7kftg.database.windows.net,1433;Database=FutbolDb;
User ID=AzureDevCampMde@h7w8d7kftg;Password=Azure123.;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jugador>().HasKey(c => c.IdJugador);
            modelBuilder.Entity<Jugador>().Property(c => c.Nombre).IsRequired();
            modelBuilder.Entity<Jugador>().Property(c => c.Nombre).HasMaxLength(200);
        }
    }
}
