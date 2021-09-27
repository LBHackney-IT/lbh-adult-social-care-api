using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class updatedDarePackageDetailsNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPer",
                table: "CarePackageDetails");

            migrationBuilder.DropColumn(
                name: "PackageDetailType",
                table: "CarePackageDetails");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "CarePackageDetails");

            migrationBuilder.AddColumn<int>(
                name: "CostPeriod",
                table: "CarePackageDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicePeriod",
                table: "CarePackageDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "CarePackageDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPeriod",
                table: "CarePackageDetails");

            migrationBuilder.DropColumn(
                name: "ServicePeriod",
                table: "CarePackageDetails");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CarePackageDetails");

            migrationBuilder.AddColumn<string>(
                name: "CostPer",
                table: "CarePackageDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackageDetailType",
                table: "CarePackageDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "CarePackageDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
