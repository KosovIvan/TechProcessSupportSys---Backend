using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class NaVsyakiy2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blanks_AspNetUsers_UserId",
                table: "Blanks");

            migrationBuilder.DropForeignKey(
                name: "FK_TechProcesses_Blanks_BlankId",
                table: "TechProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blanks",
                table: "Blanks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88b9f5a4-8379-45bc-8469-2c8d1a9dc755");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "947c15dd-d8a9-49dc-9657-85d0c39adee2");

            migrationBuilder.RenameTable(
                name: "Blanks",
                newName: "Blank");

            migrationBuilder.RenameIndex(
                name: "IX_Blanks_UserId",
                table: "Blank",
                newName: "IX_Blank_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blank",
                table: "Blank",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bbee3577-0bcb-4b1f-aa59-8888781ee77f", null, "User", "USER" },
                    { "ca49d1c1-2686-48da-a31a-b4d5bea53d85", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Blank_AspNetUsers_UserId",
                table: "Blank",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechProcesses_Blank_BlankId",
                table: "TechProcesses",
                column: "BlankId",
                principalTable: "Blank",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blank_AspNetUsers_UserId",
                table: "Blank");

            migrationBuilder.DropForeignKey(
                name: "FK_TechProcesses_Blank_BlankId",
                table: "TechProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blank",
                table: "Blank");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbee3577-0bcb-4b1f-aa59-8888781ee77f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca49d1c1-2686-48da-a31a-b4d5bea53d85");

            migrationBuilder.RenameTable(
                name: "Blank",
                newName: "Blanks");

            migrationBuilder.RenameIndex(
                name: "IX_Blank_UserId",
                table: "Blanks",
                newName: "IX_Blanks_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blanks",
                table: "Blanks",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88b9f5a4-8379-45bc-8469-2c8d1a9dc755", null, "User", "USER" },
                    { "947c15dd-d8a9-49dc-9657-85d0c39adee2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Blanks_AspNetUsers_UserId",
                table: "Blanks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechProcesses_Blanks_BlankId",
                table: "TechProcesses",
                column: "BlankId",
                principalTable: "Blanks",
                principalColumn: "Id");
        }
    }
}
