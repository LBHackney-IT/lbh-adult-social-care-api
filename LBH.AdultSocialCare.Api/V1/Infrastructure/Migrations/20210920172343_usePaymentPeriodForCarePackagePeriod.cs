using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class usePaymentPeriodForCarePackagePeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "CarePackages"
            );

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "CarePackages",
                nullable: false
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "CarePackages"
            );

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "CarePackages"
            );
        }
    }
}
