using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AddSupplierToPackageCareCharges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM ""CareChargeElements"";
DELETE FROM ""PackageCareCharges"";
update ""NursingCareBrokerageInfos"" set ""HasCareCharges"" = false;
update ""ResidentialCareBrokerageInfos"" set ""HasCareCharges"" = false;");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceUserId",
                table: "PackageCareCharges",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "PackageCareCharges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropColumn("PackageId", "InvoiceCreditNotes");
            migrationBuilder.AddColumn<Guid>(name: "PackageId", table: "InvoiceCreditNotes", nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "ClaimCollectorId",
                table: "InvoiceCreditNotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PackageCareCharges_ServiceUserId",
                table: "PackageCareCharges",
                column: "ServiceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageCareCharges_SupplierId",
                table: "PackageCareCharges",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_ClaimCollectorId",
                table: "InvoiceCreditNotes",
                column: "ClaimCollectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceCreditNotes_PackageCostClaimers_ClaimCollectorId",
                table: "InvoiceCreditNotes",
                column: "ClaimCollectorId",
                principalTable: "PackageCostClaimers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageCareCharges_Clients_ServiceUserId",
                table: "PackageCareCharges",
                column: "ServiceUserId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageCareCharges_Suppliers_SupplierId",
                table: "PackageCareCharges",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceCreditNotes_PackageCostClaimers_ClaimCollectorId",
                table: "InvoiceCreditNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageCareCharges_Clients_ServiceUserId",
                table: "PackageCareCharges");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageCareCharges_Suppliers_SupplierId",
                table: "PackageCareCharges");

            migrationBuilder.DropIndex(
                name: "IX_PackageCareCharges_ServiceUserId",
                table: "PackageCareCharges");

            migrationBuilder.DropIndex(
                name: "IX_PackageCareCharges_SupplierId",
                table: "PackageCareCharges");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceCreditNotes_ClaimCollectorId",
                table: "InvoiceCreditNotes");

            migrationBuilder.DropColumn(
                name: "ServiceUserId",
                table: "PackageCareCharges");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "PackageCareCharges");

            migrationBuilder.DropColumn(
                name: "ClaimCollectorId",
                table: "InvoiceCreditNotes");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "InvoiceCreditNotes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid));
        }
    }
}
