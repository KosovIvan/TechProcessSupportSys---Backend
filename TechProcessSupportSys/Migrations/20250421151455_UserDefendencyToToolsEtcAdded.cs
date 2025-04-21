using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class UserDefendencyToToolsEtcAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01b369c0-447f-41fe-b492-08900179ba0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cba4422-3f4c-448e-be8a-818c9b8e3133");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Tools",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Fixtures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Fixtures",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Equipment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d16ef4f-a169-4390-a46c-fed1f77a118d", null, "User", "USER" },
                    { "d3e04563-8c41-4d93-9e41-36805c8adf78", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tools_UserId1",
                table: "Tools",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_UserId1",
                table: "Fixtures",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_UserId1",
                table: "Equipment",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AspNetUsers_UserId1",
                table: "Equipment",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_AspNetUsers_UserId1",
                table: "Fixtures",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_AspNetUsers_UserId1",
                table: "Tools",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AspNetUsers_UserId1",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_AspNetUsers_UserId1",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_AspNetUsers_UserId1",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_Tools_UserId1",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_UserId1",
                table: "Fixtures");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_UserId1",
                table: "Equipment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d16ef4f-a169-4390-a46c-fed1f77a118d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3e04563-8c41-4d93-9e41-36805c8adf78");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Equipment");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01b369c0-447f-41fe-b492-08900179ba0f", null, "Admin", "ADMIN" },
                    { "5cba4422-3f4c-448e-be8a-818c9b8e3133", null, "User", "USER" }
                });
        }
    }
}
