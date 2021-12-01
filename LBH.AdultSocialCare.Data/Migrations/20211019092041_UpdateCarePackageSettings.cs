using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdateCarePackageSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("71687793-5abe-4b84-882b-b8584c31ec57"), new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089") });

            migrationBuilder.AddColumn<bool>(
                name: "IsS117ClientConfirmed",
                table: "CarePackageSettings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsS117ClientConfirmed",
                table: "CarePackageSettings");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "RoleId1", "UserId1" },
                values: new object[] { new Guid("71687793-5abe-4b84-882b-b8584c31ec57"), new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089"), null, null });
        }
    }
}
