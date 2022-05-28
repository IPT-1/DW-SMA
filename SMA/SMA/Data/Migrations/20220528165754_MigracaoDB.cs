using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMA.Migrations
{
    public partial class MigracaoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "d12ec53e-fe69-4117-b2f8-b9373cacdb00");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "6c6abc5f-64ed-429f-b9fc-e5f7a8c5e174");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "p",
                column: "ConcurrencyStamp",
                value: "d1c63823-3dbc-492e-93a1-90b57b410c04");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "42e0e762-d4e2-402b-b9b0-0acb66c81598");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "869d5e5c-f146-4fd9-9b5e-9eb0d0501efa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "p",
                column: "ConcurrencyStamp",
                value: "b29936c9-cf1e-4290-9506-82d264ad0293");
        }
    }
}
