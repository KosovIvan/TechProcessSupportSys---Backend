using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class AnnotationsTrouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69878783-ce85-4046-b6da-54aff2456166");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d9ff81c-5aed-4598-9568-d264064a3d4e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39d2ffe5-5838-4c61-8f31-aa8dfd61615f", null, "Admin", "ADMIN" },
                    { "ae666854-2cc7-4731-98f6-0fcffe4e8918", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39d2ffe5-5838-4c61-8f31-aa8dfd61615f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae666854-2cc7-4731-98f6-0fcffe4e8918");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "69878783-ce85-4046-b6da-54aff2456166", null, "User", "USER" },
                    { "9d9ff81c-5aed-4598-9568-d264064a3d4e", null, "Admin", "ADMIN" }
                });
        }
    }
}
