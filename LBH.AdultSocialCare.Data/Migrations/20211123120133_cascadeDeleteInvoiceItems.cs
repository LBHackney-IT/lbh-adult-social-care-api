using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class cascadeDeleteInvoiceItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_CarePackageDetails_CarePackageDetailId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_CarePackageReclaims_CarePackageReclaimId",
                table: "InvoiceItems");

            /*migrationBuilder.AddColumn<decimal>(
                name: "GrossTotal",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetTotal",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);*/

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_CarePackageDetails_CarePackageDetailId",
                table: "InvoiceItems",
                column: "CarePackageDetailId",
                principalTable: "CarePackageDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_CarePackageReclaims_CarePackageReclaimId",
                table: "InvoiceItems",
                column: "CarePackageReclaimId",
                principalTable: "CarePackageReclaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_CarePackageDetails_CarePackageDetailId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_CarePackageReclaims_CarePackageReclaimId",
                table: "InvoiceItems");

            /*migrationBuilder.DropColumn(
                name: "GrossTotal",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "NetTotal",
                table: "Invoices");*/

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_CarePackageDetails_CarePackageDetailId",
                table: "InvoiceItems",
                column: "CarePackageDetailId",
                principalTable: "CarePackageDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_CarePackageReclaims_CarePackageReclaimId",
                table: "InvoiceItems",
                column: "CarePackageReclaimId",
                principalTable: "CarePackageReclaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
