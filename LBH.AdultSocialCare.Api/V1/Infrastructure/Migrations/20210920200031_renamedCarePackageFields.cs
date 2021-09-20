using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class renamedCarePackageFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_PackageStages_StageId",
                table: "CarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_PackageStatuses_StatusId",
                table: "CarePackages");

            migrationBuilder.DropIndex(
                name: "IX_CarePackages_StageId",
                table: "CarePackages");

            migrationBuilder.DropIndex(
                name: "IX_CarePackages_StatusId",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "CarePackages");

            migrationBuilder.AddColumn<int>(
                name: "Stage",
                table: "CarePackages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CarePackages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stage",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CarePackages");

            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "CarePackages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "CarePackages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_StageId",
                table: "CarePackages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_StatusId",
                table: "CarePackages",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_PackageStages_StageId",
                table: "CarePackages",
                column: "StageId",
                principalTable: "PackageStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_PackageStatuses_StatusId",
                table: "CarePackages",
                column: "StatusId",
                principalTable: "PackageStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
