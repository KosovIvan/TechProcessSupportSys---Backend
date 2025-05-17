using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class CodeChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Transitions_StepOrder",
                table: "Transitions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Operations_Code",
                table: "Operations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Operations_StepOrder",
                table: "Operations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1362f878-4982-4138-beba-8e65b6358632");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f936aa54-bf64-42d1-bda1-ae93e2e4a240");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Operations");

            migrationBuilder.AlterColumn<string>(
                name: "StepOrder",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "588cbfb2-62e8-4087-b09f-d0d2c8209c70", null, "Admin", "ADMIN" },
                    { "854f2d29-feea-4410-8396-8123466def7f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "588cbfb2-62e8-4087-b09f-d0d2c8209c70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "854f2d29-feea-4410-8396-8123466def7f");

            migrationBuilder.AlterColumn<int>(
                name: "StepOrder",
                table: "Operations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Transitions_StepOrder",
                table: "Transitions",
                column: "StepOrder");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Operations_Code",
                table: "Operations",
                column: "Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Operations_StepOrder",
                table: "Operations",
                column: "StepOrder");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1362f878-4982-4138-beba-8e65b6358632", null, "Admin", "ADMIN" },
                    { "f936aa54-bf64-42d1-bda1-ae93e2e4a240", null, "User", "USER" }
                });
        }
    }
}
