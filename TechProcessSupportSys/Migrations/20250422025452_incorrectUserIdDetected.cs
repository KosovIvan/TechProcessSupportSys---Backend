using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class incorrectUserIdDetected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechProcesses_AspNetUsers_UserId1",
                table: "TechProcesses");

            migrationBuilder.DropIndex(
                name: "IX_TechProcesses_UserId1",
                table: "TechProcesses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62de977d-526f-4b5f-ae18-4279f209ca31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c277950b-3d6b-4dbe-a453-e29d270ba646");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TechProcesses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TechProcesses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45359be7-9f15-4d93-925b-1f7dab06e9b9", null, "User", "USER" },
                    { "96b8f4af-e510-40e1-8fc6-605be2e0edbf", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechProcesses_UserId",
                table: "TechProcesses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TechProcesses_AspNetUsers_UserId",
                table: "TechProcesses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechProcesses_AspNetUsers_UserId",
                table: "TechProcesses");

            migrationBuilder.DropIndex(
                name: "IX_TechProcesses_UserId",
                table: "TechProcesses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45359be7-9f15-4d93-925b-1f7dab06e9b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96b8f4af-e510-40e1-8fc6-605be2e0edbf");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TechProcesses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TechProcesses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62de977d-526f-4b5f-ae18-4279f209ca31", null, "User", "USER" },
                    { "c277950b-3d6b-4dbe-a453-e29d270ba646", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechProcesses_UserId1",
                table: "TechProcesses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TechProcesses_AspNetUsers_UserId1",
                table: "TechProcesses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
