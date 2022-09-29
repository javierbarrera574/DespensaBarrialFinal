using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepensaBarrialFinal.BD.Migrations
{
    public partial class Total : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    IdAdministrador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.IdAdministrador);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategorias = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategorias);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdadEmpleado = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AdministadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Administrador_AdministadorId",
                        column: x => x.AdministadorId,
                        principalTable: "Administrador",
                        principalColumn: "IdAdministrador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id_delproveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdministadorId = table.Column<int>(type: "int", nullable: false),
                    NombreP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<int>(type: "int", nullable: false),
                    AdministradorIdAdministrador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id_delproveedor);
                    table.ForeignKey(
                        name: "FK_Proveedores_Administrador_AdministradorIdAdministrador",
                        column: x => x.AdministradorIdAdministrador,
                        principalTable: "Administrador",
                        principalColumn: "IdAdministrador");
                });

            migrationBuilder.CreateTable(
                name: "Deposito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadMinima = table.Column<int>(type: "int", nullable: false),
                    EmpleadoDepositoIdEmpleado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposito_Empleado_EmpleadoDepositoIdEmpleado",
                        column: x => x.EmpleadoDepositoIdEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProductos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaIdCategorias = table.Column<int>(type: "int", nullable: true),
                    TipoCategoriaEnProductos = table.Column<int>(type: "int", nullable: false),
                    NombreProducto = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DescripcionProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaVencimientoProducto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaBorrado = table.Column<bool>(type: "bit", nullable: false),
                    PrecioProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepositoCantidadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProductos);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaIdCategorias",
                        column: x => x.CategoriaIdCategorias,
                        principalTable: "Categorias",
                        principalColumn: "IdCategorias");
                    table.ForeignKey(
                        name: "FK_Productos_Deposito_DepositoCantidadId",
                        column: x => x.DepositoCantidadId,
                        principalTable: "Deposito",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProveedorProducto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ProveedoresId_delproveedor = table.Column<int>(type: "int", nullable: true),
                    ProductosIdProductos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorProducto", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProveedorProducto_Productos_ProductosIdProductos",
                        column: x => x.ProductosIdProductos,
                        principalTable: "Productos",
                        principalColumn: "IdProductos");
                    table.ForeignKey(
                        name: "FK_ProveedorProducto_Proveedores_ProveedoresId_delproveedor",
                        column: x => x.ProveedoresId_delproveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id_delproveedor");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deposito_EmpleadoDepositoIdEmpleado",
                table: "Deposito",
                column: "EmpleadoDepositoIdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_AdministadorId",
                table: "Empleado",
                column: "AdministadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaIdCategorias",
                table: "Productos",
                column: "CategoriaIdCategorias");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DepositoCantidadId",
                table: "Productos",
                column: "DepositoCantidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_NombreProducto",
                table: "Productos",
                column: "NombreProducto",
                unique: true,
                filter: "[NombreProducto] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_AdministradorIdAdministrador",
                table: "Proveedores",
                column: "AdministradorIdAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorProducto_ProductosIdProductos",
                table: "ProveedorProducto",
                column: "ProductosIdProductos");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorProducto_ProveedoresId_delproveedor",
                table: "ProveedorProducto",
                column: "ProveedoresId_delproveedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ProveedorProducto");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Deposito");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Administrador");
        }
    }
}
