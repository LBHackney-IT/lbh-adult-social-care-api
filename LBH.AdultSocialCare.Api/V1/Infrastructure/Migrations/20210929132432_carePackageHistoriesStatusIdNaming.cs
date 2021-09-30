using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class carePackageHistoriesStatusIdNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "CarePackageHistories");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CarePackageHistories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CarePackageHistories");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "CarePackageHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
