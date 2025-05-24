using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class LastTokenDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "098d477b-05e3-4c3a-b446-6fc44a4130a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70d021b3-dee0-4cbb-a4f1-660736fe346c");

            migrationBuilder.DropColumn(
                name: "LastTokenValidAfter",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cbc6087c-ff94-477b-8bed-110be0d648c8", null, "User", "USER" },
                    { "e9716c61-37d5-4769-a36f-443d5a05e970", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc6087c-ff94-477b-8bed-110be0d648c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9716c61-37d5-4769-a36f-443d5a05e970");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTokenValidAfter",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "098d477b-05e3-4c3a-b446-6fc44a4130a1", null, "User", "USER" },
                    { "70d021b3-dee0-4cbb-a4f1-660736fe346c", null, "Admin", "ADMIN" }
                });
        }
    }
}
