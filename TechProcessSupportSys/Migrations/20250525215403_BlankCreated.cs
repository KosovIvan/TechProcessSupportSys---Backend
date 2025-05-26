using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class BlankCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25587778-d16d-4a99-b66c-7758e65b391f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "817d564c-c059-4fec-9ac8-02e3679aca5a");

            migrationBuilder.AddColumn<int>(
                name: "BlankId",
                table: "TechProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Blanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asortment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AsortmentGOST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialStateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialGOST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    Diameter = table.Column<double>(type: "float", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blanks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88b9f5a4-8379-45bc-8469-2c8d1a9dc755", null, "User", "USER" },
                    { "947c15dd-d8a9-49dc-9657-85d0c39adee2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechProcesses_BlankId",
                table: "TechProcesses",
                column: "BlankId");

            migrationBuilder.CreateIndex(
                name: "IX_Blanks_UserId",
                table: "Blanks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TechProcesses_Blanks_BlankId",
                table: "TechProcesses",
                column: "BlankId",
                principalTable: "Blanks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechProcesses_Blanks_BlankId",
                table: "TechProcesses");

            migrationBuilder.DropTable(
                name: "Blanks");

            migrationBuilder.DropIndex(
                name: "IX_TechProcesses_BlankId",
                table: "TechProcesses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88b9f5a4-8379-45bc-8469-2c8d1a9dc755");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "947c15dd-d8a9-49dc-9657-85d0c39adee2");

            migrationBuilder.DropColumn(
                name: "BlankId",
                table: "TechProcesses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25587778-d16d-4a99-b66c-7758e65b391f", null, "User", "USER" },
                    { "817d564c-c059-4fec-9ac8-02e3679aca5a", null, "Admin", "ADMIN" }
                });
        }
    }
}
