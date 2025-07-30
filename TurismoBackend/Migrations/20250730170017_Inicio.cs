using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TurismoBackend.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Documento = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNac = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Provincia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pais = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    URL_image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categoria = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pais = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    URL_Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDestino = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_Destinos_IdDestino",
                        column: x => x.IdDestino,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Itinerarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDestino = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itinerarios_Destinos_IdDestino",
                        column: x => x.IdDestino,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    FechaReservacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MetodoPago = table.Column<int>(type: "int", nullable: false),
                    Transporte = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumPersona = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IdItinerario = table.Column<int>(type: "int", nullable: false),
                    IdActividad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Actividades_IdActividad",
                        column: x => x.IdActividad,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_Itinerarios_IdItinerario",
                        column: x => x.IdItinerario,
                        principalTable: "Itinerarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallesVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    IdDestino = table.Column<int>(type: "int", nullable: true),
                    IdActividad = table.Column<int>(type: "int", nullable: true),
                    IdItinerario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesVentas_Actividades_IdActividad",
                        column: x => x.IdActividad,
                        principalTable: "Actividades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetallesVentas_Destinos_IdDestino",
                        column: x => x.IdDestino,
                        principalTable: "Destinos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetallesVentas_Itinerarios_IdItinerario",
                        column: x => x.IdItinerario,
                        principalTable: "Itinerarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetallesVentas_Ventas_IdVenta",
                        column: x => x.IdVenta,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "Id", "Apellido", "Eliminado", "Email", "FechaRegistro", "Nombre", "Telefono" },
                values: new object[] { 1, "Uno", false, "ejemplo@admin.com", new DateTime(2025, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "EjemploAdministrador", "0000000000" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "Ciudad", "Direccion", "Documento", "Eliminado", "Email", "FechaNac", "Nombre", "Pais", "Provincia", "Telefono" },
                values: new object[,]
                {
                    { 1, "EjemploApellido1", "EjemploCiudad1", "EjemploDireccion1", "00000001", false, "ejemplo1@cliente.com", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EjemploCliente1", "EjemploPais1", "EjemploProvincia1", "0000000001" },
                    { 2, "EjemploApellido2", "EjemploCiudad2", "EjemploDireccion2", "00000002", false, "ejemplo2@cliente.com", new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "EjemploCliente2", "EjemploPais2", "EjemploProvincia2", "0000000002" }
                });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "Id", "Categoria", "Descripcion", "Eliminado", "Nombre", "Pais", "URL_image" },
                values: new object[,]
                {
                    { 1, "Ejemplo", "Descripción ejemplo destino 1", false, "EjemploDestino1", "EjemploPais", "https://ejemplo.com/destino1.jpg" },
                    { 2, "Ejemplo", "Descripción ejemplo destino 2", false, "EjemploDestino2", "EjemploPais", "https://ejemplo.com/destino2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Actividades",
                columns: new[] { "Id", "Costo", "Descripcion", "Duracion", "Eliminado", "IdDestino", "Nombre", "URL_Image" },
                values: new object[,]
                {
                    { 1, 75.00m, "Descripción actividad ejemplo 1", 180, false, 1, "EjemploActividad1", "https://ejemplo.com/actividad1.jpg" },
                    { 2, 50.00m, "Descripción actividad ejemplo 2", 120, false, 2, "EjemploActividad2", "https://ejemplo.com/actividad2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Itinerarios",
                columns: new[] { "Id", "Descripcion", "Eliminado", "FechaFin", "FechaInicio", "IdDestino", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ejemplo de itinerario 1", false, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "EjemploItinerario1" },
                    { 2, "Ejemplo de itinerario 2", false, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "EjemploItinerario2" }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "Eliminado", "FechaPago", "FechaReservacion", "IdActividad", "IdCliente", "IdItinerario", "MetodoPago", "NumPersona", "Total", "Transporte" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 7, 30, 14, 0, 16, 307, DateTimeKind.Local).AddTicks(881), new DateTime(2025, 7, 30, 14, 0, 16, 307, DateTimeKind.Local).AddTicks(867), 1, 1, 1, 0, 2, 1500m, 0 },
                    { 2, false, new DateTime(2025, 7, 30, 14, 0, 16, 307, DateTimeKind.Local).AddTicks(886), new DateTime(2025, 7, 30, 14, 0, 16, 307, DateTimeKind.Local).AddTicks(885), 2, 2, 2, 0, 2, 1500m, 0 }
                });

            migrationBuilder.InsertData(
                table: "DetallesVentas",
                columns: new[] { "Id", "IdActividad", "IdDestino", "IdItinerario", "IdVenta" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 2, 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdDestino",
                table: "Actividades",
                column: "IdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVentas_IdActividad",
                table: "DetallesVentas",
                column: "IdActividad");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVentas_IdDestino",
                table: "DetallesVentas",
                column: "IdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVentas_IdItinerario",
                table: "DetallesVentas",
                column: "IdItinerario");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVentas_IdVenta",
                table: "DetallesVentas",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Itinerarios_IdDestino",
                table: "Itinerarios",
                column: "IdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdActividad",
                table: "Ventas",
                column: "IdActividad");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdCliente",
                table: "Ventas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdItinerario",
                table: "Ventas",
                column: "IdItinerario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "DetallesVentas");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Itinerarios");

            migrationBuilder.DropTable(
                name: "Destinos");
        }
    }
}
