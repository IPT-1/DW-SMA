using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMA.Migrations
{
    public partial class MigReceitas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utentes_Utentes_UtenteId",
                table: "Utentes");

            migrationBuilder.DropTable(
                name: "ReceitaUtente");

            migrationBuilder.DropIndex(
                name: "IX_Utentes_UtenteId",
                table: "Utentes");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Utentes");

            migrationBuilder.DropColumn(
                name: "UtenteId",
                table: "Utentes");

            migrationBuilder.AlterColumn<string>(
                name: "Telemovel",
                table: "Utentes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Utentes",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroUtenteSaude",
                table: "Utentes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Utentes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Funcao",
                table: "Utentes",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prescricao",
                table: "Receitas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "MedicoFK",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacienteFK",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Medicamentos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Laboratorio",
                table: "Medicamentos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dosagem",
                table: "Medicamentos",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegisto",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a", "42e0e762-d4e2-402b-b9b0-0acb66c81598", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "m", "869d5e5c-f146-4fd9-9b5e-9eb0d0501efa", "Medico", "MEDICO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "p", "b29936c9-cf1e-4290-9506-82d264ad0293", "Paciente", "PACIENTE" });

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_MedicoFK",
                table: "Receitas",
                column: "MedicoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_PacienteFK",
                table: "Receitas",
                column: "PacienteFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Utentes_MedicoFK",
                table: "Receitas",
                column: "MedicoFK",
                principalTable: "Utentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Utentes_PacienteFK",
                table: "Receitas",
                column: "PacienteFK",
                principalTable: "Utentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Utentes_MedicoFK",
                table: "Receitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Utentes_PacienteFK",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Receitas_MedicoFK",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Receitas_PacienteFK",
                table: "Receitas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "p");

            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "Utentes");

            migrationBuilder.DropColumn(
                name: "MedicoFK",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "PacienteFK",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "DataRegisto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Telemovel",
                table: "Utentes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Utentes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroUtenteSaude",
                table: "Utentes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Utentes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Utentes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtenteId",
                table: "Utentes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Prescricao",
                table: "Receitas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Laboratorio",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Dosagem",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.CreateTable(
                name: "ReceitaUtente",
                columns: table => new
                {
                    ReceitasId = table.Column<int>(type: "int", nullable: false),
                    UtentesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaUtente", x => new { x.ReceitasId, x.UtentesId });
                    table.ForeignKey(
                        name: "FK_ReceitaUtente_Receitas_ReceitasId",
                        column: x => x.ReceitasId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitaUtente_Utentes_UtentesId",
                        column: x => x.UtentesId,
                        principalTable: "Utentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utentes_UtenteId",
                table: "Utentes",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaUtente_UtentesId",
                table: "ReceitaUtente",
                column: "UtentesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utentes_Utentes_UtenteId",
                table: "Utentes",
                column: "UtenteId",
                principalTable: "Utentes",
                principalColumn: "Id");
        }
    }
}
