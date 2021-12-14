using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class CarePackageDetailRemoveServicePeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageDetails_ServicePeriod",
                table: "CarePackageDetails");

            migrationBuilder.DropColumn(
                name: "ServicePeriod",
                table: "CarePackageDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageDetails_ServicePeriod",
                table: "CarePackageDetails",
                sql: "\"ServicePeriod\" IN (1, 2, 3, 4)");

            migrationBuilder.AddColumn<int>(
                name: "ServicePeriod",
                table: "CarePackageDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
