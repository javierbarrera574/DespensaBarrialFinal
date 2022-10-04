using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepensaBarrialFinal.BD.Migrations
{
    public partial class Cambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NumeroTelefono = table.Column<int>(type: "int", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deposito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unidad_minima = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EdadEmpleado = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", maxLength: 12, nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    NumeroTelefono = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    DNI = table.Column<int>(type: "int", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DescripcionProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaVencimientoProducto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrecioProducto = table.Column<decimal>(type: "decimal(18,2)", maxLength: 3, nullable: false),
                    DepositoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Deposito_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "Deposito",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoCategoria = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NumeroTelefono = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    AdministadorId = table.Column<int>(type: "int", nullable: false),
                    AdministradorId = table.Column<int>(type: "int", nullable: true),
                    ProductosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedores_Administrador_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administrador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proveedores_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ProductosId",
                table: "Categorias",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "EmpleadoDNI_UQ",
                table: "Empleado",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DepositoId",
                table: "Productos",
                column: "DepositoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_NombreProducto",
                table: "Productos",
                column: "NombreProducto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_AdministradorId",
                table: "Proveedores",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_ProductosId",
                table: "Proveedores",
                column: "ProductosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Deposito");
        }
    }
}
