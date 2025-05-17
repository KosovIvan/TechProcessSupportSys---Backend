using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class IsPrivateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39d2ffe5-5838-4c61-8f31-aa8dfd61615f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae666854-2cc7-4731-98f6-0fcffe4e8918");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Transitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Tools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "TechProcesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Operations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Fixtures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Equipment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1362f878-4982-4138-beba-8e65b6358632", null, "Admin", "ADMIN" },
                    { "f936aa54-bf64-42d1-bda1-ae93e2e4a240", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1362f878-4982-4138-beba-8e65b6358632");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f936aa54-bf64-42d1-bda1-ae93e2e4a240");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "TechProcesses");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Equipment");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39d2ffe5-5838-4c61-8f31-aa8dfd61615f", null, "Admin", "ADMIN" },
                    { "ae666854-2cc7-4731-98f6-0fcffe4e8918", null, "User", "USER" }
                });
        }
    }
}
