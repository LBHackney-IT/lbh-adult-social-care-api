using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class updatePackageTypeConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_PackageType",
                table: "CarePackages");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_PackageType",
                table: "CarePackages",
                sql: "\"PackageType\" IN (0, 2, 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_PackageType",
                table: "CarePackages");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_PackageType",
                table: "CarePackages",
                sql: "\"PackageType\" IN (0, 1, 2, 3, 4)");
        }
    }
}
