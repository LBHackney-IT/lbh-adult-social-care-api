using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class addedInvoiceGrossAndNetTotals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns",
                sql: "\"Type\" IN (0, 1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices",
                sql: "\"InvoiceStatus\" IN (0, 1, 2, 3, 4, 5, 6)");

            migrationBuilder.AddColumn<decimal>(
                name: "GrossTotal",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetTotal",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices");

            migrationBuilder.DropColumn(
                name: "GrossTotal",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "NetTotal",
                table: "Invoices");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns",
                sql: "\"Type\" IN (0, 1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices",
                sql: "\"InvoiceStatus\" IN (0, 1, 2, 3, 4, 5)");
        }
    }
}
