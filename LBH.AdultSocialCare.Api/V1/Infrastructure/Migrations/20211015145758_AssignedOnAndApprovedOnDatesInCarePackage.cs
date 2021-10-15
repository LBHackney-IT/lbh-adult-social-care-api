using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AssignedOnAndApprovedOnDatesInCarePackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateApproved",
                table: "CarePackages",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateAssigned",
                table: "CarePackages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateApproved",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "DateAssigned",
                table: "CarePackages");
        }
    }
}
