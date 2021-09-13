using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class SeedInvoiceCreditNoteHelpers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InvoiceItemPriceEffects",
                columns: new[] { "Id", "EffectName" },
                values: new object[,]
                {
                    { 1, "None" },
                    { 2, "Add" },
                    { 3, "Subtract" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceNoteChargeTypes",
                columns: new[] { "Id", "ChargeTypeName" },
                values: new object[,]
                {
                    { 1, "OverCharge" },
                    { 2, "UnderCharge" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceItemPriceEffects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvoiceItemPriceEffects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InvoiceItemPriceEffects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InvoiceNoteChargeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvoiceNoteChargeTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
