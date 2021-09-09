using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class HasCareChargesBoolOnNursingCareBrokerage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasCareCharges",
                table: "NursingCareBrokerageInfos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasCareCharges",
                table: "NursingCareBrokerageInfos");
        }
    }
}
