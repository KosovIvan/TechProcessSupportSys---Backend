using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc6087c-ff94-477b-8bed-110be0d648c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9716c61-37d5-4769-a36f-443d5a05e970");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Transitions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Transitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Transitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Transitions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "TechProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TechProcesses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TechProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Fixtures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Fixtures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Fixtures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Fixtures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Equipment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Equipment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Equipment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Equipment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25587778-d16d-4a99-b66c-7758e65b391f", null, "User", "USER" },
                    { "817d564c-c059-4fec-9ac8-02e3679aca5a", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25587778-d16d-4a99-b66c-7758e65b391f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "817d564c-c059-4fec-9ac8-02e3679aca5a");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Transitions");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "TechProcesses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TechProcesses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TechProcesses");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Equipment");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cbc6087c-ff94-477b-8bed-110be0d648c8", null, "User", "USER" },
                    { "e9716c61-37d5-4769-a36f-443d5a05e970", null, "Admin", "ADMIN" }
                });
        }
    }
}
