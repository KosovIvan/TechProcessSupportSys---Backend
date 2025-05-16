using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class GOSTsNSomeShit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45359be7-9f15-4d93-925b-1f7dab06e9b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96b8f4af-e510-40e1-8fc6-605be2e0edbf");

            migrationBuilder.AddColumn<string>(
                name: "GOST",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TechProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "TechProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GOST",
                table: "Fixtures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GOST",
                table: "Equipment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4843b329-d1b1-4385-81e2-213710d23c44", null, "Admin", "ADMIN" },
                    { "d1367646-c48d-4f88-9d0a-b6bdbd0dc294", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4843b329-d1b1-4385-81e2-213710d23c44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1367646-c48d-4f88-9d0a-b6bdbd0dc294");

            migrationBuilder.DropColumn(
                name: "GOST",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "TechProcesses");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "TechProcesses");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "GOST",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "GOST",
                table: "Equipment");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45359be7-9f15-4d93-925b-1f7dab06e9b9", null, "User", "USER" },
                    { "96b8f4af-e510-40e1-8fc6-605be2e0edbf", null, "Admin", "ADMIN" }
                });
        }
    }
}
