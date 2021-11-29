using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class DecimalPrecisionOnAmountAndQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Paid",
                table: "Payruns",
                type: "decimal(13, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Held",
                table: "Payruns",
                type: "decimal(13, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "Invoices",
                type: "decimal(13, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetTotal",
                table: "Invoices",
                type: "decimal(13, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "GrossTotal",
                table: "Invoices",
                type: "decimal(13, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "WeeklyCost",
                table: "InvoiceItems",
                type: "decimal(13, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "InvoiceItems",
                type: "decimal(13, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InvoiceItems",
                type: "decimal(7, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Paid",
                table: "Payruns",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Held",
                table: "Payruns",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "Invoices",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetTotal",
                table: "Invoices",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GrossTotal",
                table: "Invoices",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "WeeklyCost",
                table: "InvoiceItems",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "InvoiceItems",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InvoiceItems",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7, 2)");
        }
    }
}
