using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class addcustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "284329d2-5fa8-4f64-b67f-00dcba2d90dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "5c666d55-59bb-4ae5-925f-fca7cb856b5c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c62c56d-11d0-4be9-86db-6e2f8a59f87b", "AQAAAAEAACcQAAAAEPuaBGQkvMxUjjMZX96j3UQFfmCQWOUDzX2/SaRRdTLZx8A8fAvLB6QjCQfjCsC5Lw==", "4c5d1b17-cc7f-4051-9a20-d6ea8ef0bb81" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "503a5896-1344-43d3-980c-33b52c8cd6a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "608590cd-031a-4f33-97cc-66e0be84d765");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cee895d-647b-4271-8430-766f6b471992", "AQAAAAEAACcQAAAAEBLiEHK5iPCpRfFVCALLfscjSjN7CAUcQqZe/D47J8fx+jS7qKhH1N+R9Rnp2hq+rg==", "8ffa52ca-741d-487a-bdbc-fea9666f63c7" });
        }
    }
}
