using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class nullablePrimarySupportReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_PrimarySupportReasons_PrimarySupportReasonId",
                table: "CarePackages");

            migrationBuilder.AlterColumn<int>(
                name: "PrimarySupportReasonId",
                table: "CarePackages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_PrimarySupportReasons_PrimarySupportReasonId",
                table: "CarePackages",
                column: "PrimarySupportReasonId",
                principalTable: "PrimarySupportReasons",
                principalColumn: "PrimarySupportReasonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_PrimarySupportReasons_PrimarySupportReasonId",
                table: "CarePackages");

            migrationBuilder.AlterColumn<int>(
                name: "PrimarySupportReasonId",
                table: "CarePackages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_PrimarySupportReasons_PrimarySupportReasonId",
                table: "CarePackages",
                column: "PrimarySupportReasonId",
                principalTable: "PrimarySupportReasons",
                principalColumn: "PrimarySupportReasonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
