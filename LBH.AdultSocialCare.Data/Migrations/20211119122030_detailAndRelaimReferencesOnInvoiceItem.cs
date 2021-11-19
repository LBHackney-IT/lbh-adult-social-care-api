using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class detailAndRelaimReferencesOnInvoiceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "InvoiceItems");

            migrationBuilder.AddColumn<Guid>(
                name: "CarePackageDetailId",
                table: "InvoiceItems",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CarePackageReclaimId",
                table: "InvoiceItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_CarePackageDetailId",
                table: "InvoiceItems",
                column: "CarePackageDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_CarePackageReclaimId",
                table: "InvoiceItems",
                column: "CarePackageReclaimId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_CarePackageDetails_CarePackageDetailId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_CarePackageReclaims_CarePackageReclaimId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_CarePackageDetailId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_CarePackageReclaimId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "CarePackageDetailId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "CarePackageReclaimId",
                table: "InvoiceItems");

            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "InvoiceItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
