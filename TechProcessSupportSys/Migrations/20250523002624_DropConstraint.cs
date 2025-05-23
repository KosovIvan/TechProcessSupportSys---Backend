using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class DropConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TechProcesses_Code",
                table: "TechProcesses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "588cbfb2-62e8-4087-b09f-d0d2c8209c70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "854f2d29-feea-4410-8396-8123466def7f");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TechProcesses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79aa9377-8c02-4762-8d6a-e57887a88379", null, "Admin", "ADMIN" },
                    { "d817fb35-2104-4df4-9e2c-8cfa23df1f3b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79aa9377-8c02-4762-8d6a-e57887a88379");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d817fb35-2104-4df4-9e2c-8cfa23df1f3b");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TechProcesses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TechProcesses_Code",
                table: "TechProcesses",
                column: "Code");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "588cbfb2-62e8-4087-b09f-d0d2c8209c70", null, "Admin", "ADMIN" },
                    { "854f2d29-feea-4410-8396-8123466def7f", null, "User", "USER" }
                });
        }
    }
}
