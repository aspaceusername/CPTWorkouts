using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTWorkouts.Migrations
{
    /// <inheritdoc />
    public partial class completouEquipasController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Equipas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Logotype",
                table: "Equipas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    EquipaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Nome);
                    table.ForeignKey(
                        name: "FK_Aulas_Equipas_EquipaId",
                        column: x => x.EquipaId,
                        principalTable: "Equipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idClientes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataDeNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    dadosPessoais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idClientes);
                });

            migrationBuilder.CreateTable(
                name: "Serviços",
                columns: table => new
                {
                    idServiço = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeServiço = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preço = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviços", x => x.idServiço);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataDeNascimento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Treinadores",
                columns: table => new
                {
                    idTreinadores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<int>(type: "int", nullable: false),
                    AulasNome = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinadores", x => x.idTreinadores);
                    table.ForeignKey(
                        name: "FK_Treinadores_Aulas_AulasNome",
                        column: x => x.AulasNome,
                        principalTable: "Aulas",
                        principalColumn: "Nome");
                });

            migrationBuilder.CreateTable(
                name: "Faturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    Serviços = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faturas_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "idClientes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscrevem_se",
                columns: table => new
                {
                    idClientesFK = table.Column<int>(type: "int", nullable: false),
                    idEquipasFK = table.Column<int>(type: "int", nullable: false),
                    nomeEquipas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteidClientes = table.Column<int>(type: "int", nullable: false),
                    EquipaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscrevem_se", x => new { x.idClientesFK, x.idEquipasFK });
                    table.ForeignKey(
                        name: "FK_Inscrevem_se_Clientes_ClienteidClientes",
                        column: x => x.ClienteidClientes,
                        principalTable: "Clientes",
                        principalColumn: "idClientes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscrevem_se_Equipas_EquipaId",
                        column: x => x.EquipaId,
                        principalTable: "Equipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compram",
                columns: table => new
                {
                    idClientesFK = table.Column<int>(type: "int", nullable: false),
                    idServiçosFK = table.Column<int>(type: "int", nullable: false),
                    nomeServiços = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteidClientes = table.Column<int>(type: "int", nullable: false),
                    servicoidServiço = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compram", x => new { x.idClientesFK, x.idServiçosFK });
                    table.ForeignKey(
                        name: "FK_Compram_Clientes_clienteidClientes",
                        column: x => x.clienteidClientes,
                        principalTable: "Clientes",
                        principalColumn: "idClientes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compram_Serviços_servicoidServiço",
                        column: x => x.servicoidServiço,
                        principalTable: "Serviços",
                        principalColumn: "idServiço",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pertencem",
                columns: table => new
                {
                    idTreinadoresFK = table.Column<int>(type: "int", nullable: false),
                    idEquipasFK = table.Column<int>(type: "int", nullable: false),
                    nomeEquipas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreinadoridTreinadores = table.Column<int>(type: "int", nullable: false),
                    EquipaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pertencem", x => new { x.idTreinadoresFK, x.idEquipasFK });
                    table.ForeignKey(
                        name: "FK_Pertencem_Equipas_EquipaId",
                        column: x => x.EquipaId,
                        principalTable: "Equipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pertencem_Treinadores_TreinadoridTreinadores",
                        column: x => x.TreinadoridTreinadores,
                        principalTable: "Treinadores",
                        principalColumn: "idTreinadores",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_EquipaId",
                table: "Aulas",
                column: "EquipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Compram_clienteidClientes",
                table: "Compram",
                column: "clienteidClientes");

            migrationBuilder.CreateIndex(
                name: "IX_Compram_servicoidServiço",
                table: "Compram",
                column: "servicoidServiço");

            migrationBuilder.CreateIndex(
                name: "IX_Faturas_idCliente",
                table: "Faturas",
                column: "idCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscrevem_se_ClienteidClientes",
                table: "Inscrevem_se",
                column: "ClienteidClientes");

            migrationBuilder.CreateIndex(
                name: "IX_Inscrevem_se_EquipaId",
                table: "Inscrevem_se",
                column: "EquipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pertencem_EquipaId",
                table: "Pertencem",
                column: "EquipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pertencem_TreinadoridTreinadores",
                table: "Pertencem",
                column: "TreinadoridTreinadores");

            migrationBuilder.CreateIndex(
                name: "IX_Treinadores_AulasNome",
                table: "Treinadores",
                column: "AulasNome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compram");

            migrationBuilder.DropTable(
                name: "Faturas");

            migrationBuilder.DropTable(
                name: "Inscrevem_se");

            migrationBuilder.DropTable(
                name: "Pertencem");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Serviços");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Treinadores");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Equipas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Logotype",
                table: "Equipas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
