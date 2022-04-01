using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSysF.Application.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaltantesDet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id Consecutivo")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValue: "F", comment: "Estatus del articulo del Faltante, F = Faltante, S = Surtido"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Fecha de Creacion"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Fecha de Creacion"),
                    ClienteId = table.Column<int>(type: "int", nullable: false, comment: "El id del Cliente"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false, comment: "El id del Empleado"),
                    Cantidad = table.Column<decimal>(type: "decimal(5,3)", precision: 5, scale: 3, nullable: false, comment: "Cantidad solicitada"),
                    ProdMaestroId = table.Column<int>(type: "int", nullable: false, comment: "Id del catalogo de ProdMaestro"),
                    MarcaId = table.Column<int>(type: "int", nullable: false, comment: "Id del Catalogo de Marcas"),
                    EsCadaUno = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Si el precio es por unidad y no por caja"),
                    Notas = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Notas para el que va a surtir el reglon del Pedido")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaltantesDet", x => x.Id);
                },
                comment: "Tabla de faltantes de las Sucursales");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteId",
                table: "FaltantesDet",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoId",
                table: "FaltantesDet",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_NoDup_FaltantesDet",
                table: "FaltantesDet",
                columns: new[] { "ClienteId", "EmpleadoId", "ProdMaestroId", "MarcaId", "Estatus" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdMaestroId",
                table: "FaltantesDet",
                column: "ProdMaestroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaltantesDet");
        }
    }
}
