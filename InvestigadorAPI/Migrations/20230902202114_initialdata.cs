using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestigadorAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Proyectos",
                table: "Proyectos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investigadores",
                table: "Investigadores");

            migrationBuilder.RenameTable(
                name: "Proyectos",
                newName: "Proyecto");

            migrationBuilder.RenameTable(
                name: "Investigadores",
                newName: "Investigador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proyecto",
                table: "Proyecto",
                column: "proyectoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investigador",
                table: "Investigador",
                column: "InvestigadorID");

            migrationBuilder.InsertData(
                table: "Investigador",
                columns: new[] { "InvestigadorID", "Afiliacion", "Apellido", "Nombre", "Rol" },
                values: new object[] { new Guid("82ea4c24-53f8-4648-a0e4-76c3faf03d90"), "Tiempo completo", "Raulez", "Raul", "Lider" });

            migrationBuilder.InsertData(
                table: "Proyecto",
                columns: new[] { "proyectoID", "area", "descripción", "fechaFin", "fechaInicio", "lider", "nombre" },
                values: new object[] { new Guid("82ea4c24-53f8-4648-a0e4-76c3faf03d91"), "Ingenieria", "Son latas", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raul", "Las latas" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Proyecto",
                table: "Proyecto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investigador",
                table: "Investigador");

            migrationBuilder.DeleteData(
                table: "Investigador",
                keyColumn: "InvestigadorID",
                keyValue: new Guid("82ea4c24-53f8-4648-a0e4-76c3faf03d90"));

            migrationBuilder.DeleteData(
                table: "Proyecto",
                keyColumn: "proyectoID",
                keyValue: new Guid("82ea4c24-53f8-4648-a0e4-76c3faf03d91"));

            migrationBuilder.RenameTable(
                name: "Proyecto",
                newName: "Proyectos");

            migrationBuilder.RenameTable(
                name: "Investigador",
                newName: "Investigadores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proyectos",
                table: "Proyectos",
                column: "proyectoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investigadores",
                table: "Investigadores",
                column: "InvestigadorID");
        }
    }
}
