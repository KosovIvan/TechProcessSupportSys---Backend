using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class UniqueKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3670ec26-f536-4366-89a6-d9cae35d148e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cea903bc-c7d3-4331-8fa4-a6a520c3647c");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Transitions_StepOrder",
                table: "Transitions",
                column: "StepOrder");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Operations_StepOrder",
                table: "Operations",
                column: "StepOrder");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39771aad-2bb2-4a5b-89c7-052dab6baea6", null, "User", "USER" },
                    { "a4993abd-cf12-4de5-adb0-8fac67dc2912", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Transitions_StepOrder",
                table: "Transitions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Operations_StepOrder",
                table: "Operations");

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
                    { "3670ec26-f536-4366-89a6-d9cae35d148e", null, "User", "USER" },
                    { "cea903bc-c7d3-4331-8fa4-a6a520c3647c", null, "Admin", "ADMIN" }
                });
        }
    }
}
