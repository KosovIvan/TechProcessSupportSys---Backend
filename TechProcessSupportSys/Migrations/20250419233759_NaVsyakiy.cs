using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class NaVsyakiy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39771aad-2bb2-4a5b-89c7-052dab6baea6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4993abd-cf12-4de5-adb0-8fac67dc2912");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4981766a-ee28-450a-a6e4-fcd240f1cc19", null, "User", "USER" },
                    { "840fab2b-ab4a-4f39-821e-c3da0f05babb", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4981766a-ee28-450a-a6e4-fcd240f1cc19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "840fab2b-ab4a-4f39-821e-c3da0f05babb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39771aad-2bb2-4a5b-89c7-052dab6baea6", null, "User", "USER" },
                    { "a4993abd-cf12-4de5-adb0-8fac67dc2912", null, "Admin", "ADMIN" }
                });
        }
    }
}
