using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AddCareChargeManagerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE ""AspNetUserRoles"" DROP COLUMN IF EXISTS ""UserId1"";
ALTER TABLE ""AspNetUserRoles"" DROP COLUMN IF EXISTS ""RoleId1"";");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("7b955348-e506-4c93-abc4-64d27d559f41"), "6", "Care Charge Manager", "CARE CHARGE MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b955348-e506-4c93-abc4-64d27d559f41"));
        }
    }
}
