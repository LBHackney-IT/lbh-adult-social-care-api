using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class nullableInvoiceItemClaimCollector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "IsReclaim",
                table: "InvoiceItems");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimCollector",
                table: "InvoiceItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems",
                sql: "\"ClaimCollector\" IN (0, 1, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimCollector",
                table: "InvoiceItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReclaim",
                table: "InvoiceItems",
                type: "boolean",
                nullable: false,
                defaultValueSql: "false");
        }
    }
}
