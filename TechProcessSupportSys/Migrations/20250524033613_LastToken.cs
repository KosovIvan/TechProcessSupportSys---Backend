using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class LastToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86827b46-5874-4b93-86de-d2962876b338");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa1c58e4-130b-409e-89c2-00826a4f436e");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "86827b46-5874-4b93-86de-d2962876b338", null, "User", "USER" },
                    { "fa1c58e4-130b-409e-89c2-00826a4f436e", null, "Admin", "ADMIN" }
                });
        }
    }
}
