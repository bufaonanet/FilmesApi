using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class addroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "608590cd-031a-4f33-97cc-66e0be84d765");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "503a5896-1344-43d3-980c-33b52c8cd6a5", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cee895d-647b-4271-8430-766f6b471992", "AQAAAAEAACcQAAAAEBLiEHK5iPCpRfFVCALLfscjSjN7CAUcQqZe/D47J8fx+jS7qKhH1N+R9Rnp2hq+rg==", "8ffa52ca-741d-487a-bdbc-fea9666f63c7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a3d6a459-cc74-4a66-a298-5995aec04b28");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29de74c2-330f-4335-bea3-b99aaf53a0f2", "AQAAAAEAACcQAAAAEIqTl0Ub+MgEcLi4CmjaFRkMINNwJqBaFuTsRytBYoSov85cyhtwAt0rh84Bry5ytA==", "483b0447-60a9-4567-8c0c-430ea42eb2aa" });
        }
    }
}
