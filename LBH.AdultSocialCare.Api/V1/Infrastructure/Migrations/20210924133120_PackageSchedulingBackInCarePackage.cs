using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class PackageSchedulingBackInCarePackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimarySupportReason",
                table: "CarePackages");

            migrationBuilder.AddColumn<int>(
                name: "PackageScheduling",
                table: "CarePackages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrimarySupportReasonId",
                table: "CarePackages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"update ""CarePackages"" set ""PrimarySupportReasonId"" = 1;
update ""CarePackages"" set ""PackageScheduling"" = 2;");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_PrimarySupportReasonId",
                table: "CarePackages",
                column: "PrimarySupportReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_PrimarySupportReasons_PrimarySupportReasonId",
                table: "CarePackages",
                column: "PrimarySupportReasonId",
                principalTable: "PrimarySupportReasons",
                principalColumn: "PrimarySupportReasonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_PrimarySupportReasons_PrimarySupportReasonId",
                table: "CarePackages");

            migrationBuilder.DropIndex(
                name: "IX_CarePackages_PrimarySupportReasonId",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "PackageScheduling",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "PrimarySupportReasonId",
                table: "CarePackages");

            migrationBuilder.AddColumn<string>(
                name: "PrimarySupportReason",
                table: "CarePackages",
                type: "text",
                nullable: true);
        }
    }
}
