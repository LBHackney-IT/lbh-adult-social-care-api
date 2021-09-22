using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class CarePackageRemovePaymentPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDischarge",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.DropColumn(
                name: "IsRespiteCare",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.DropColumn(
                name: "HasReclaim",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "CarePackages");

            migrationBuilder.AddColumn<bool>(
                name: "HasDischargePackage",
                table: "ResidentialCarePackageSettings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRespiteCare",
                table: "ResidentialCarePackageSettings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasDischargePackage",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.DropColumn(
                name: "HasRespiteCare",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.AddColumn<bool>(
                name: "IsDischarge",
                table: "ResidentialCarePackageSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRespiteCare",
                table: "ResidentialCarePackageSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasReclaim",
                table: "CarePackages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "CarePackages",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
