using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TurismoServices.Models;
using TurismoServices.Enums;

namespace TurismoBackend.DataContext
{
    public partial class TurismoContext : DbContext
    {
        public TurismoContext() { }

        public TurismoContext(DbContextOptions<TurismoContext> options) : base(options) { }

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
            base.OnModelCreating(modelBuilder);

            // ---------------- RELACIONES ----------------
            // Cliente -> Venta (1:N)
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            // Venta -> Actividad (1:1)
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Actividad)
                .WithMany() // Asumiendo que no hay propiedad "Ventas" en Actividad
                .HasForeignKey(v => v.IdActividad)
                .OnDelete(DeleteBehavior.Restrict);

            // Venta -> Itinerario (1:1)
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Itinerario)
                .WithMany() // Asumiendo que no hay propiedad "Ventas" en Itinerario
                .HasForeignKey(v => v.IdItinerario)
                .OnDelete(DeleteBehavior.Restrict);

            // Venta -> RegistroVenta (1:N)
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(r => r.Venta)
                .WithMany(v => v.DetallesVenta)
                .HasForeignKey(r => r.IdVenta)
                .OnDelete(DeleteBehavior.Cascade);

            // RegistroVenta -> Destino (opcional)
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(r => r.Destino)
                .WithMany()
                .HasForeignKey(r => r.IdDestino);

            // RegistroVenta -> Actividad (opcional)
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(r => r.Actividad)
                .WithMany()
                .HasForeignKey(r => r.IdActividad);

            // RegistroVenta -> Itinerario (opcional)
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(r => r.Itinerario)
                .WithMany()
                .HasForeignKey(r => r.IdItinerario);

            // Itinerario -> Destino (1:N)
            modelBuilder.Entity<Itinerario>()
                .HasOne(i => i.Destino)
                .WithMany(d => d.Itinerario)
                .HasForeignKey(i => i.IdDestino)
                .OnDelete(DeleteBehavior.Restrict);

            // Actividad -> Destino (1:N)
            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Destino)
                .WithMany(d => d.Actividad)
                .HasForeignKey(a => a.IdDestino)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------------- DATOS SEMILLA ----------------

            // Administrador
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = 1,
                    Nombre = "EjemploAdministrador",
                    Apellido = "Uno",
                    Email = "ejemplo@admin.com",
                    Telefono = "0000000000",
                    FechaRegistro = new DateTime(2025, 07, 27)
                }
            );

            // Destinos
            modelBuilder.Entity<Destino>().HasData(
                new Destino
                {
                    Id = 1,
                    Nombre = "EjemploDestino1",
                    Descripcion = "Descripción ejemplo destino 1",
                    URL_image = "https://ejemplo.com/destino1.jpg",
                    Categoria = "Ejemplo",
                    Pais = "EjemploPais",
                    Eliminado = false
                },
                new Destino
                {
                    Id = 2,
                    Nombre = "EjemploDestino2",
                    Descripcion = "Descripción ejemplo destino 2",
                    URL_image = "https://ejemplo.com/destino2.jpg",
                    Categoria = "Ejemplo",
                    Pais = "EjemploPais",
                    Eliminado = false
                }
            );

            // Itinerarios
            modelBuilder.Entity<Itinerario>().HasData(
                new Itinerario
                {
                    Id = 1,
                    Nombre = "EjemploItinerario1",
                    FechaInicio = new DateTime(2025, 12, 1),
                    FechaFin = new DateTime(2025, 12, 5),
                    Descripcion = "Ejemplo de itinerario 1",
                    IdDestino = 1,
                    Eliminado = false
                },
                new Itinerario
                {
                    Id = 2,
                    Nombre = "EjemploItinerario2",
                    FechaInicio = new DateTime(2025, 12, 10),
                    FechaFin = new DateTime(2025, 12, 15),
                    Descripcion = "Ejemplo de itinerario 2",
                    IdDestino = 2,
                    Eliminado = false
                }
            );

            // Actividades
            modelBuilder.Entity<Actividad>().HasData(
                new Actividad
                {
                    Id = 1,
                    Nombre = "EjemploActividad1",
                    URL_Image = "https://ejemplo.com/actividad1.jpg",
                    Duracion = 180,
                    Costo = 75.00m,
                    Descripcion = "Descripción actividad ejemplo 1",
                    IdDestino = 1,
                    Eliminado = false
                },
                new Actividad
                {
                    Id = 2,
                    Nombre = "EjemploActividad2",
                    URL_Image = "https://ejemplo.com/actividad2.jpg",
                    Duracion = 120,
                    Costo = 50.00m,
                    Descripcion = "Descripción actividad ejemplo 2",
                    IdDestino = 2,
                    Eliminado = false
                }
            );

            // Clientes
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Nombre = "EjemploCliente1",
                    Apellido = "EjemploApellido1",
                    Documento = "00000001",
                    FechaNac = new DateTime(1990, 01, 01),
                    Email = "ejemplo1@cliente.com",
                    Telefono = "0000000001",
                    Direccion = "EjemploDireccion1",
                    Ciudad = "EjemploCiudad1",
                    Provincia = "EjemploProvincia1",
                    Pais = "EjemploPais1",
                    Eliminado = false
                },
                new Cliente
                {
                    Id = 2,
                    Nombre = "EjemploCliente2",
                    Apellido = "EjemploApellido2",
                    Documento = "00000002",
                    FechaNac = new DateTime(1995, 05, 05),
                    Email = "ejemplo2@cliente.com",
                    Telefono = "0000000002",
                    Direccion = "EjemploDireccion2",
                    Ciudad = "EjemploCiudad2",
                    Provincia = "EjemploProvincia2",
                    Pais = "EjemploPais2",
                    Eliminado = false
                }
            );

            // Ventas
            modelBuilder.Entity<Venta>().HasData(
                new Venta
                {
                    Id = 1,
                    IdCliente = 1,
                    FechaReservacion = DateTime.Now,
                    MetodoPago = MetodoPagoEnum.Efectivo,
                    Transporte = PreferenciaTransporteEnum.Automóvil,
                    FechaPago = DateTime.Now,
                    NumPersona = 2,
                    Total = 1500,
                    Eliminado = false,
                    IdItinerario = 1,
                    IdActividad = 1
                },
                new Venta
                {
                    Id = 2,
                    IdCliente = 2,
                    FechaReservacion = DateTime.Now,
                    MetodoPago = MetodoPagoEnum.Efectivo,
                    Transporte = PreferenciaTransporteEnum.Automóvil,
                    FechaPago = DateTime.Now,
                    NumPersona = 2,
                    Total = 1500,
                    Eliminado = false,
                    IdItinerario = 2,
                    IdActividad = 2
                }
            );

            // Registros de venta
            modelBuilder.Entity<DetalleVenta>().HasData(
                new DetalleVenta
                {
                    Id = 1,
                    IdVenta = 1,
                    IdDestino = 1,
                    IdActividad = 1,
                    IdItinerario = 1,
                },
                new DetalleVenta
                {
                    Id = 2,
                    IdVenta = 2,
                    IdDestino = 2,
                    IdActividad = 2,
                    IdItinerario = 2,
                }
            );
        }

        // ---------------- DBSETS ----------------
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVentas { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }
    }
}
