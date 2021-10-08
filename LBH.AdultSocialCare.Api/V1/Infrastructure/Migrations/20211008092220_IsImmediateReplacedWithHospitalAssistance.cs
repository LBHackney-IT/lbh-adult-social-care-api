using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class IsImmediateReplacedWithHospitalAssistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsImmediate",
                table: "CarePackageSettings");

            migrationBuilder.AddColumn<bool>(
                name: "HospitalAvoidance",
                table: "CarePackageSettings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalAvoidance",
                table: "CarePackageSettings");

            migrationBuilder.AddColumn<bool>(
                name: "IsImmediate",
                table: "CarePackageSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
