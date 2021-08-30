using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class defaultFncCollectorForSuppliers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FundedNursingCareCollectorId",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_FundedNursingCareCollectorId",
                table: "Suppliers",
                column: "FundedNursingCareCollectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_FundedNursingCareCollectors_FundedNursingCareColl~",
                table: "Suppliers",
                column: "FundedNursingCareCollectorId",
                principalTable: "FundedNursingCareCollectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_FundedNursingCareCollectors_FundedNursingCareColl~",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_FundedNursingCareCollectorId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "FundedNursingCareCollectorId",
                table: "Suppliers");
        }
    }
}
