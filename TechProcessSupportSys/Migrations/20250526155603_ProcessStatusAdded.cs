using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class ProcessStatusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbee3577-0bcb-4b1f-aa59-8888781ee77f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca49d1c1-2686-48da-a31a-b4d5bea53d85");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TechProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "539c09a1-00ea-4268-85ac-0897fdf217ea", null, "User", "USER" },
                    { "62499320-f529-4d0b-9a26-8947ddc227eb", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "539c09a1-00ea-4268-85ac-0897fdf217ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62499320-f529-4d0b-9a26-8947ddc227eb");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TechProcesses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bbee3577-0bcb-4b1f-aa59-8888781ee77f", null, "User", "USER" },
                    { "ca49d1c1-2686-48da-a31a-b4d5bea53d85", null, "Admin", "ADMIN" }
                });
        }
    }
}
