using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechProcessSupportSys.Migrations
{
    /// <inheritdoc />
    public partial class DefaultAdminAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "539c09a1-00ea-4268-85ac-0897fdf217ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62499320-f529-4d0b-9a26-8947ddc227eb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16a4d845-74e2-4b65-a0db-5e7f48fa4ed3", null, "User", "USER" },
                    { "1b815878-e658-430a-bd1a-c2ed0ac005ea", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RevokedBy", "RevokedOn", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dba1ea3f-4be2-4049-989b-3e49d4a8b38f", 0, "15508b55-2ed1-491c-8a88-4581c88d8113", new DateTime(2025, 5, 26, 19, 37, 36, 850, DateTimeKind.Local).AddTicks(8851), "admin@gmail.com", false, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEE53Tc2KS8Aj7WJKGFng4WQp4zfzqjwe3VrINvyBJC8oOilhcSvQi6mq8HmC8Gm3ig==", null, false, "", null, "f036ad56-cb93-4476-930a-33e5202bde39", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1b815878-e658-430a-bd1a-c2ed0ac005ea", "dba1ea3f-4be2-4049-989b-3e49d4a8b38f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16a4d845-74e2-4b65-a0db-5e7f48fa4ed3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1b815878-e658-430a-bd1a-c2ed0ac005ea", "dba1ea3f-4be2-4049-989b-3e49d4a8b38f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b815878-e658-430a-bd1a-c2ed0ac005ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dba1ea3f-4be2-4049-989b-3e49d4a8b38f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "539c09a1-00ea-4268-85ac-0897fdf217ea", null, "User", "USER" },
                    { "62499320-f529-4d0b-9a26-8947ddc227eb", null, "Admin", "ADMIN" }
                });
        }
    }
}
