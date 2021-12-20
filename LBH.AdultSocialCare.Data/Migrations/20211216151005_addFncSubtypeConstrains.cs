using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class addFncSubtypeConstrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims",
                sql: "\"SubType\" IN (1, 2, 3, 4, 5)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                column: "PasswordHash",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims",
                sql: "\"SubType\" IN (1, 2, 3)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEE7oLV5MdDSgaXX8VXuAivUBbj2I7qD7JyNqDl3btiUUl2x5Bqik1YAD71wMeljKVw==");
        }
    }
}
