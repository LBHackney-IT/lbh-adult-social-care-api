using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class DecimalPrecisionOnResidentialAndNursingCareBrokerage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ResidentialCore",
                table: "ResidentialCareBrokerageInfos",
                type: "decimal(13, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<bool>(
                name: "HasCareCharges",
                table: "ResidentialCareBrokerageInfos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "AdditionalNeedsCost",
                table: "ResidentialCareAdditionalNeedsCosts",
                type: "decimal(13, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "NursingCore",
                table: "NursingCareBrokerageInfos",
                type: "decimal(13, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "AdditionalNeedsCost",
                table: "NursingCareAdditionalNeedsCosts",
                type: "decimal(13, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasCareCharges",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.AlterColumn<decimal>(
                name: "ResidentialCore",
                table: "ResidentialCareBrokerageInfos",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AdditionalNeedsCost",
                table: "ResidentialCareAdditionalNeedsCosts",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NursingCore",
                table: "NursingCareBrokerageInfos",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AdditionalNeedsCost",
                table: "NursingCareAdditionalNeedsCosts",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)");
        }
    }
}
