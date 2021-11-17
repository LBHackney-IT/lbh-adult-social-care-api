using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdatePaymentModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_Status",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InvoiceItems");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices",
                sql: "\"InvoiceStatus\" IN (0, 1, 2, 3, 4, 5)");

            migrationBuilder.AddColumn<int>(
                name: "ClaimCollector",
                table: "InvoiceItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems",
                sql: "\"ClaimCollector\" IN (0, 1, 2)");

            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "Invoices",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InvoiceItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FromDate",
                table: "InvoiceItems",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InvoiceItems",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ToDate",
                table: "InvoiceItems",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PackageId",
                table: "Invoices",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ServiceUserId",
                table: "Invoices",
                column: "ServiceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SupplierId",
                table: "Invoices",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_CarePackages_PackageId",
                table: "Invoices",
                column: "PackageId",
                principalTable: "CarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ServiceUsers_ServiceUserId",
                table: "Invoices",
                column: "ServiceUserId",
                principalTable: "ServiceUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Suppliers_SupplierId",
                table: "Invoices",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_CarePackages_PackageId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ServiceUsers_ServiceUserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Suppliers_SupplierId",
                table: "Invoices");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PackageId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ServiceUserId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_SupplierId",
                table: "Invoices");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ClaimCollector",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "InvoiceItems");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices",
                sql: "\"InvoiceStatus\" IN (0, 1)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_Status",
                table: "InvoiceItems",
                sql: "\"Status\" IN (0, 1)");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "InvoiceItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "InvoiceItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
