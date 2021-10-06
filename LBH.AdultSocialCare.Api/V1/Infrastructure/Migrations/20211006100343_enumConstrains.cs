using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class enumConstrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageSchedulingOptions_Id",
                table: "CarePackageSchedulingOptions",
                sql: "\"Id\" IN (0, 1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_PackageScheduling",
                table: "CarePackages",
                sql: "\"PackageScheduling\" IN (0, 1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_PackageType",
                table: "CarePackages",
                sql: "\"PackageType\" IN (0, 1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_ClaimCollector",
                table: "CarePackageReclaims",
                sql: "\"ClaimCollector\" IN (0, 1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_Status",
                table: "CarePackageReclaims",
                sql: "\"Status\" IN (0, 1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims",
                sql: "\"SubType\" IN (0, 1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_Type",
                table: "CarePackageReclaims",
                sql: "\"Type\" IN (0, 1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageHistories_Status",
                table: "CarePackageHistories",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageDetails_CostPeriod",
                table: "CarePackageDetails",
                sql: "\"CostPeriod\" IN (0, 1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageDetails_ServicePeriod",
                table: "CarePackageDetails",
                sql: "\"ServicePeriod\" IN (0, 1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageDetails_Type",
                table: "CarePackageDetails",
                sql: "\"Type\" IN (0, 1, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageSchedulingOptions_Id",
                table: "CarePackageSchedulingOptions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_PackageScheduling",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_PackageType",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_ClaimCollector",
                table: "CarePackageReclaims");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_Status",
                table: "CarePackageReclaims");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_Type",
                table: "CarePackageReclaims");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageHistories_Status",
                table: "CarePackageHistories");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageDetails_CostPeriod",
                table: "CarePackageDetails");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageDetails_ServicePeriod",
                table: "CarePackageDetails");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageDetails_Type",
                table: "CarePackageDetails");
        }
    }
}
