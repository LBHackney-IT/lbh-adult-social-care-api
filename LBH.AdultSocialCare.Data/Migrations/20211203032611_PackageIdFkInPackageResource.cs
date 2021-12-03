using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class PackageIdFkInPackageResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "CarePackageResources",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageResources_PackageId",
                table: "CarePackageResources",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageResources_CarePackages_PackageId",
                table: "CarePackageResources",
                column: "PackageId",
                principalTable: "CarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageResources_CarePackages_PackageId",
                table: "CarePackageResources");

            migrationBuilder.DropIndex(
                name: "IX_CarePackageResources_PackageId",
                table: "CarePackageResources");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "CarePackageResources");
        }
    }
}
