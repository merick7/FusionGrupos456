using Microsoft.EntityFrameworkCore.Migrations;

namespace WebGanadera.App.Persistencia.Migrations
{
    public partial class MigraInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacunaApli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaAplicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedAplicante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumDosis = table.Column<int>(type: "int", nullable: false),
                    Periodicidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vacuna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaVen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Labo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacuna", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GanadoPId = table.Column<int>(type: "int", nullable: true),
                    veterinaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vacunaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_vacuna_vacunaId",
                        column: x => x.vacunaId,
                        principalTable: "vacuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ganado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    raza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumEjemplar = table.Column<int>(type: "int", nullable: true),
                    ModConsulta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vacunaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ganado_Personas_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ganado_vacuna_vacunaId",
                        column: x => x.vacunaId,
                        principalTable: "vacuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ganado_MedicoId",
                table: "Ganado",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ganado_vacunaId",
                table: "Ganado",
                column: "vacunaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_GanadoPId",
                table: "Personas",
                column: "GanadoPId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_vacunaId",
                table: "Personas",
                column: "vacunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ganado_GanadoPId",
                table: "Personas",
                column: "GanadoPId",
                principalTable: "Ganado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ganado_Personas_MedicoId",
                table: "Ganado");

            migrationBuilder.DropTable(
                name: "Historia");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Ganado");

            migrationBuilder.DropTable(
                name: "vacuna");
        }
    }
}
