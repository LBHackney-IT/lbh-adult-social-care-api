using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdateUsersAndUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3c44e4e1-78b8-471f-9f08-5081a0a534e9"), 0, "4d24dcde-08b2-4e04-b4f5-c475fab1a22d", "burak@gmail.com", false, false, null, "Burak Ozkan", null, null, null, "9046464646", false, null, false, "burak@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "RoleId1", "UserId1" },
                values: new object[] { new Guid("3c44e4e1-78b8-471f-9f08-5081a0a534e9"), new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089"), null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("3c44e4e1-78b8-471f-9f08-5081a0a534e9"), new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c44e4e1-78b8-471f-9f08-5081a0a534e9"));
        }
    }
}
