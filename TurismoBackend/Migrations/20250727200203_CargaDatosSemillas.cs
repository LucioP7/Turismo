using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TurismoBackend.Migrations
{
    /// <inheritdoc />
    public partial class CargaDatosSemillas : Migration
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
                    Transporte = table.Column<int>(type: "int", nullable: false),
                    IdDestino = table.Column<int>(type: "int", nullable: true),
                    DestinoId = table.Column<int>(type: "int", nullable: true),
                    IdActividad = table.Column<int>(type: "int", nullable: true),
                    ActividadId = table.Column<int>(type: "int", nullable: true),
                    NumPersona = table.Column<int>(type: "int", nullable: false),
                    FechaReservacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EstadoReservacion = table.Column<int>(type: "int", nullable: false),
                    IdItinerario = table.Column<int>(type: "int", nullable: true),
                    ItinerarioId = table.Column<int>(type: "int", nullable: true),
                    MetodoPago = table.Column<int>(type: "int", nullable: false),
                    ConfirmacionPago = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clientes_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clientes_Itinerarios_ItinerarioId",
                        column: x => x.ItinerarioId,
                        principalTable: "Itinerarios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "Id", "Apellido", "Eliminado", "Email", "FechaRegistro", "Nombre", "Telefono" },
                values: new object[] { 1, "Pianetti", false, "lp@lp.com", new DateTime(2025, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucio", "44064814" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "ActividadId", "Apellido", "Ciudad", "ConfirmacionPago", "DestinoId", "Direccion", "Documento", "Eliminado", "Email", "EstadoReservacion", "FechaNac", "FechaPago", "FechaReservacion", "IdActividad", "IdDestino", "IdItinerario", "ItinerarioId", "MetodoPago", "Nombre", "NumPersona", "Pais", "Provincia", "Telefono", "Total", "Transporte" },
                values: new object[,]
                {
                    { 1, null, "Pianetti", "San Justo", 1, null, "San Roque 2440", "44064814", false, "lp7@lp7.com", 0, new DateTime(2002, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 27, 17, 2, 2, 498, DateTimeKind.Local).AddTicks(1735), new DateTime(2025, 7, 27, 17, 2, 2, 498, DateTimeKind.Local).AddTicks(1718), 1, 1, 1, null, 0, "Lucio", 1, "Argentina", "Santa Fe", "3498518884", 150000.00m, 0 },
                    { 2, null, "Perez", "Ciudad Falsa", 0, null, "Calle Falsa 123", "12345678", false, "ej@ej.com", 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 27, 17, 2, 2, 498, DateTimeKind.Local).AddTicks(1741), new DateTime(2025, 7, 27, 17, 2, 2, 498, DateTimeKind.Local).AddTicks(1740), 2, 2, 2, null, 1, "Juan", 2, "Argentina", "Provincia Falsa", "1234567890", 200000.00m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "Id", "Categoria", "Descripcion", "Eliminado", "Nombre", "Pais", "URL_image" },
                values: new object[,]
                {
                    { 1, "Natural", "Maravilla natural en la provincia de Misiones.", false, "Cataratas del Iguazú", "Argentina", "https://www.iguazujungle.com/esp/web2/images/Web%20192016.jpg" },
                    { 2, "Cultural", "Capital cosmopolita de Argentina con rica vida cultural.", false, "Buenos Aires", "Argentina", "https://s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2019/07/03201757/Ciudades-mas-caras-de-America-Latina-Buenos-Aires.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Actividades",
                columns: new[] { "Id", "Costo", "Descripcion", "Duracion", "Eliminado", "IdDestino", "Nombre", "URL_Image" },
                values: new object[,]
                {
                    { 1, 75.00m, "Exploración a pie por los senderos de las Cataratas del Iguazú.", 180, false, 1, "Caminata por las Cataratas del Iguazú", "https://media.tacdn.com/media/attractions-splice-spp-360x240/0a/dd/10/25.jpg" },
                    { 2, 50.00m, "Visita a la Casa Rosada de Buenos Aires.", 120, false, 2, "Visita a la Casa Rosada", "https://media.tacdn.com/media/attractions-splice-spp-674x446/06/70/5f/c2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Itinerarios",
                columns: new[] { "Id", "Descripcion", "Eliminado", "FechaFin", "FechaInicio", "IdDestino", "Nombre" },
                values: new object[,]
                {
                    { 1, "Viaje a las Cataratas del Iguazú con actividades de aventura.", false, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aventura en las Cataratas" },
                    { 2, "Viaje a Buenos Aires con actividades culturales.", false, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cultura en Buenos Aires" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdDestino",
                table: "Actividades",
                column: "IdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ActividadId",
                table: "Clientes",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DestinoId",
                table: "Clientes",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ItinerarioId",
                table: "Clientes",
                column: "ItinerarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Itinerarios_IdDestino",
                table: "Itinerarios",
                column: "IdDestino");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Itinerarios");

            migrationBuilder.DropTable(
                name: "Destinos");
        }
    }
}
