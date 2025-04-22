using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class Rebuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "UserId1",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Equipment");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tools",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Fixtures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Equipment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62de977d-526f-4b5f-ae18-4279f209ca31", null, "User", "USER" },
                    { "c277950b-3d6b-4dbe-a453-e29d270ba646", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tools_UserId",
                table: "Tools",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_UserId",
                table: "Fixtures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_UserId",
                table: "Equipment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AspNetUsers_UserId",
                table: "Equipment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_AspNetUsers_UserId",
                table: "Fixtures",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_AspNetUsers_UserId",
                table: "Tools",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AspNetUsers_UserId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_AspNetUsers_UserId",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_AspNetUsers_UserId",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_Tools_UserId",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_UserId",
                table: "Fixtures");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_UserId",
                table: "Equipment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62de977d-526f-4b5f-ae18-4279f209ca31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c277950b-3d6b-4dbe-a453-e29d270ba646");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tools",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Tools",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Fixtures",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Fixtures",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Equipment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
