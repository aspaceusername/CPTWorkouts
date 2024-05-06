using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTWorkouts.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoscomentarioseFKscorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Equipas_EquipaId",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Compram_Clientes_clienteidClientes",
                table: "Compram");

            migrationBuilder.DropForeignKey(
                name: "FK_Compram_Serviços_servicoidServiço",
                table: "Compram");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscrevem_se_Clientes_ClienteidClientes",
                table: "Inscrevem_se");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscrevem_se_Equipas_EquipaId",
                table: "Inscrevem_se");

            migrationBuilder.DropForeignKey(
                name: "FK_Pertencem_Equipas_EquipaId",
                table: "Pertencem");

            migrationBuilder.DropForeignKey(
                name: "FK_Pertencem_Treinadores_TreinadoridTreinadores",
                table: "Pertencem");

            migrationBuilder.DropIndex(
                name: "IX_Pertencem_EquipaId",
                table: "Pertencem");

            migrationBuilder.DropIndex(
                name: "IX_Pertencem_TreinadoridTreinadores",
                table: "Pertencem");

            migrationBuilder.DropIndex(
                name: "IX_Inscrevem_se_ClienteidClientes",
                table: "Inscrevem_se");

            migrationBuilder.DropIndex(
                name: "IX_Inscrevem_se_EquipaId",
                table: "Inscrevem_se");

            migrationBuilder.DropIndex(
                name: "IX_Compram_clienteidClientes",
                table: "Compram");

            migrationBuilder.DropIndex(
                name: "IX_Compram_servicoidServiço",
                table: "Compram");

            migrationBuilder.DropColumn(
                name: "EquipaId",
                table: "Pertencem");

            migrationBuilder.DropColumn(
                name: "TreinadoridTreinadores",
                table: "Pertencem");

            migrationBuilder.DropColumn(
                name: "ClienteidClientes",
                table: "Inscrevem_se");

            migrationBuilder.DropColumn(
                name: "EquipaId",
                table: "Inscrevem_se");

            migrationBuilder.DropColumn(
                name: "clienteidClientes",
                table: "Compram");

            migrationBuilder.DropColumn(
                name: "servicoidServiço",
                table: "Compram");

            migrationBuilder.RenameColumn(
                name: "Serviços",
                table: "Faturas",
                newName: "serviçosFK");

            migrationBuilder.RenameColumn(
                name: "EquipaId",
                table: "Aulas",
                newName: "equipaFK");

            migrationBuilder.RenameIndex(
                name: "IX_Aulas_EquipaId",
                table: "Aulas",
                newName: "IX_Aulas_equipaFK");

            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "Users",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "Clientes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Pertencem_idEquipasFK",
                table: "Pertencem",
                column: "idEquipasFK");

            migrationBuilder.CreateIndex(
                name: "IX_Inscrevem_se_idEquipasFK",
                table: "Inscrevem_se",
                column: "idEquipasFK");

            migrationBuilder.CreateIndex(
                name: "IX_Compram_idServiçosFK",
                table: "Compram",
                column: "idServiçosFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Equipas_equipaFK",
                table: "Aulas",
                column: "equipaFK",
                principalTable: "Equipas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compram_Clientes_idClientesFK",
                table: "Compram",
                column: "idClientesFK",
                principalTable: "Clientes",
                principalColumn: "idClientes",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compram_Serviços_idServiçosFK",
                table: "Compram",
                column: "idServiçosFK",
                principalTable: "Serviços",
                principalColumn: "idServiço",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscrevem_se_Clientes_idClientesFK",
                table: "Inscrevem_se",
                column: "idClientesFK",
                principalTable: "Clientes",
                principalColumn: "idClientes",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscrevem_se_Equipas_idEquipasFK",
                table: "Inscrevem_se",
                column: "idEquipasFK",
                principalTable: "Equipas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pertencem_Equipas_idEquipasFK",
                table: "Pertencem",
                column: "idEquipasFK",
                principalTable: "Equipas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pertencem_Treinadores_idTreinadoresFK",
                table: "Pertencem",
                column: "idTreinadoresFK",
                principalTable: "Treinadores",
                principalColumn: "idTreinadores",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Equipas_equipaFK",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Compram_Clientes_idClientesFK",
                table: "Compram");

            migrationBuilder.DropForeignKey(
                name: "FK_Compram_Serviços_idServiçosFK",
                table: "Compram");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscrevem_se_Clientes_idClientesFK",
                table: "Inscrevem_se");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscrevem_se_Equipas_idEquipasFK",
                table: "Inscrevem_se");

            migrationBuilder.DropForeignKey(
                name: "FK_Pertencem_Equipas_idEquipasFK",
                table: "Pertencem");

            migrationBuilder.DropForeignKey(
                name: "FK_Pertencem_Treinadores_idTreinadoresFK",
                table: "Pertencem");

            migrationBuilder.DropIndex(
                name: "IX_Pertencem_idEquipasFK",
                table: "Pertencem");

            migrationBuilder.DropIndex(
                name: "IX_Inscrevem_se_idEquipasFK",
                table: "Inscrevem_se");

            migrationBuilder.DropIndex(
                name: "IX_Compram_idServiçosFK",
                table: "Compram");

            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "serviçosFK",
                table: "Faturas",
                newName: "Serviços");

            migrationBuilder.RenameColumn(
                name: "equipaFK",
                table: "Aulas",
                newName: "EquipaId");

            migrationBuilder.RenameIndex(
                name: "IX_Aulas_equipaFK",
                table: "Aulas",
                newName: "IX_Aulas_EquipaId");

            migrationBuilder.AddColumn<int>(
                name: "EquipaId",
                table: "Pertencem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TreinadoridTreinadores",
                table: "Pertencem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteidClientes",
                table: "Inscrevem_se",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipaId",
                table: "Inscrevem_se",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "clienteidClientes",
                table: "Compram",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "servicoidServiço",
                table: "Compram",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pertencem_EquipaId",
                table: "Pertencem",
                column: "EquipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pertencem_TreinadoridTreinadores",
                table: "Pertencem",
                column: "TreinadoridTreinadores");

            migrationBuilder.CreateIndex(
                name: "IX_Inscrevem_se_ClienteidClientes",
                table: "Inscrevem_se",
                column: "ClienteidClientes");

            migrationBuilder.CreateIndex(
                name: "IX_Inscrevem_se_EquipaId",
                table: "Inscrevem_se",
                column: "EquipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Compram_clienteidClientes",
                table: "Compram",
                column: "clienteidClientes");

            migrationBuilder.CreateIndex(
                name: "IX_Compram_servicoidServiço",
                table: "Compram",
                column: "servicoidServiço");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Equipas_EquipaId",
                table: "Aulas",
                column: "EquipaId",
                principalTable: "Equipas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compram_Clientes_clienteidClientes",
                table: "Compram",
                column: "clienteidClientes",
                principalTable: "Clientes",
                principalColumn: "idClientes",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compram_Serviços_servicoidServiço",
                table: "Compram",
                column: "servicoidServiço",
                principalTable: "Serviços",
                principalColumn: "idServiço",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscrevem_se_Clientes_ClienteidClientes",
                table: "Inscrevem_se",
                column: "ClienteidClientes",
                principalTable: "Clientes",
                principalColumn: "idClientes",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscrevem_se_Equipas_EquipaId",
                table: "Inscrevem_se",
                column: "EquipaId",
                principalTable: "Equipas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pertencem_Equipas_EquipaId",
                table: "Pertencem",
                column: "EquipaId",
                principalTable: "Equipas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pertencem_Treinadores_TreinadoridTreinadores",
                table: "Pertencem",
                column: "TreinadoridTreinadores",
                principalTable: "Treinadores",
                principalColumn: "idTreinadores",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
