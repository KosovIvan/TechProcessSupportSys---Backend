using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class CodesUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4843b329-d1b1-4385-81e2-213710d23c44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1367646-c48d-4f88-9d0a-b6bdbd0dc294");

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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Operations_Code",
                table: "Operations",
                column: "Code");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62a91af3-fd5c-40d7-a28d-78a6ce1d67aa", null, "Admin", "ADMIN" },
                    { "62c1cb89-21a6-4b37-94bf-876d39e83ac4", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TechProcesses_Code",
                table: "TechProcesses");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Operations_Code",
                table: "Operations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62a91af3-fd5c-40d7-a28d-78a6ce1d67aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62c1cb89-21a6-4b37-94bf-876d39e83ac4");

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
                    { "4843b329-d1b1-4385-81e2-213710d23c44", null, "Admin", "ADMIN" },
                    { "d1367646-c48d-4f88-9d0a-b6bdbd0dc294", null, "User", "USER" }
                });
        }
    }
}
