using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class removedReclaimSupplierId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaims_Suppliers_SupplierId",
                table: "CarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_CarePackageReclaims_SupplierId",
                table: "CarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "CarePackageReclaims");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "CarePackageReclaims",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaims_SupplierId",
                table: "CarePackageReclaims",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaims_Suppliers_SupplierId",
                table: "CarePackageReclaims",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
