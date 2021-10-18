using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdateUserRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "RoleId1", "UserId1" },
                values: new object[] { new Guid("71687793-5abe-4b84-882b-b8584c31ec57"), new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089"), null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("71687793-5abe-4b84-882b-b8584c31ec57"), new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089") });
        }
    }
}
