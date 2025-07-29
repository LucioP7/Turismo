using Microsoft.EntityFrameworkCore;
using TurismoServices.Models;
using TurismoServices.Enums;


namespace TurismoBackend.DataContext
{
    public partial class TurismoContext : DbContext
    {
        public TurismoContext()
        {
        }
        public TurismoContext(DbContextOptions<TurismoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
                string? cadenaConexion = configuration.GetConnectionString("mysqlRemoto");

                optionsBuilder.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuracion de modelos

            //Configurar la relación uno a muchos entre Destino y pfItinerary
            modelBuilder.Entity<Itinerario>()
                .HasOne(i => i.Destino)
                .WithMany(d => d.Itinerario)
                .HasForeignKey(i => i.IdDestino)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Configurar la relación uno a muchos entre Destino y Actividad
            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Destino)
                .WithMany(d => d.Actividad)
                .HasForeignKey(a => a.IdDestino)
                .OnDelete(DeleteBehavior.Restrict);

            // Datos semilla para Administrador
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = 1,
                    Nombre = "Lucio",
                    Apellido = "Pianetti",
                    Email = "lp@lp.com",
                    Telefono = "44064814",
                    FechaRegistro = new DateTime(2025, 07, 27)
                }
            );


            // Datos semilla para Destino
            modelBuilder.Entity<Destino>().HasData(
                new Destino
                {
                    Id = 1,
                    Nombre = "Cataratas del Iguazú",
                    Descripcion = "Maravilla natural en la provincia de Misiones.",
                    URL_image = "https://www.iguazujungle.com/esp/web2/images/Web%20192016.jpg",
                    Categoria = "Natural",
                    Pais = "Argentina",
                    Eliminado = false
                },
                new Destino
                {
                    Id = 2,
                    Nombre = "Buenos Aires",
                    Descripcion = "Capital cosmopolita de Argentina con rica vida cultural.",
                    URL_image = "https://s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2019/07/03201757/Ciudades-mas-caras-de-America-Latina-Buenos-Aires.jpg",
                    Categoria = "Cultural",
                    Pais = "Argentina",
                    Eliminado = false
                }
            );

            // Datos semilla para pfItinerary
            modelBuilder.Entity<Itinerario>().HasData(
                new Itinerario
                {
                    Id = 1,
                    Nombre = "Aventura en las Cataratas",
                    FechaInicio = new DateTime(2025, 12, 1),
                    FechaFin = new DateTime(2025, 12, 5),
                    Descripcion = "Viaje a las Cataratas del Iguazú con actividades de aventura.",
                    IdDestino = 1,
                    Eliminado = false
                },

                new Itinerario
                {
                    Id = 2,
                    Nombre = "Cultura en Buenos Aires",
                    FechaInicio = new DateTime(2025, 12, 10),
                    FechaFin = new DateTime(2025, 12, 15),
                    Descripcion = "Viaje a Buenos Aires con actividades culturales.",
                    IdDestino = 2,
                    Eliminado = false
                }
            );


            // Datos semilla para Actividad
            modelBuilder.Entity<Actividad>().HasData(
                new Actividad
                {
                    Id = 1,
                    Nombre = "Caminata por las Cataratas del Iguazú",
                    URL_Image = "https://media.tacdn.com/media/attractions-splice-spp-360x240/0a/dd/10/25.jpg",
                    Duracion = 180,
                    Costo = 75.00m,
                    Descripcion = "Exploración a pie por los senderos de las Cataratas del Iguazú.",
                    IdDestino = 1,
                    Eliminado = false
                },

                new Actividad
                {
                    Id = 2,
                    Nombre = "Visita a la Casa Rosada",
                    URL_Image = "https://media.tacdn.com/media/attractions-splice-spp-674x446/06/70/5f/c2.jpg",
                    Duracion = 120,
                    Costo = 50.00m,
                    Descripcion = "Visita a la Casa Rosada de Buenos Aires.",
                    IdDestino = 2,
                    Eliminado = false
                }
            );


            // Datos semilla para pfClient
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Nombre = "Lucio",
                    Apellido = "Pianetti",
                    Documento = "44064814",
                    FechaNac = new DateTime(2002, 05, 07),
                    Email = "lp7@lp7.com",
                    Telefono = "3498518884",
                    Direccion = "San Roque 2440",
                    Ciudad = "San Justo",
                    Provincia = "Santa Fe",
                    Pais = "Argentina",
                    IdDestino = 1,
                    IdActividad = 1,
                    NumPersona = 1,
                    FechaReservacion = DateTime.Now,
                    EstadoReservacion = EstadoReservacionEnum.Confirmado,
                    IdItinerario = 1,
                    MetodoPago = MetodoPagoEnum.Efectivo,
                    ConfirmacionPago = ConfirmacionPagoEnum.Confirmado,
                    FechaPago = DateTime.Now,
                    Total = 150000.00m,
                    Eliminado = false
                },
                new Cliente
                {
                    Id = 2,
                    Nombre = "Juan",
                    Apellido = "Perez",
                    Documento = "12345678",
                    FechaNac = new DateTime(1990, 01, 01),
                    Email = "ej@ej.com",
                    Telefono = "1234567890",
                    Direccion = "Calle Falsa 123",
                    Ciudad = "Ciudad Falsa",
                    Provincia = "Provincia Falsa",
                    Pais = "Argentina",
                    IdDestino = 2,
                    IdActividad = 2,
                    NumPersona = 2,
                    FechaReservacion = DateTime.Now,
                    EstadoReservacion = EstadoReservacionEnum.Pendiente,
                    IdItinerario = 2,
                    MetodoPago = MetodoPagoEnum.TarjetaCredito,
                    ConfirmacionPago = ConfirmacionPagoEnum.Pendiente,
                    FechaPago = DateTime.Now,
                    Total = 200000.00m,
                    Eliminado = false
                }
            );
        }
        // DbSets for your models in the specified order
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }
    }
}
