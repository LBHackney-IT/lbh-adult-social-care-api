using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class RemoveIsSupplierInternalFromSuppliersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasSupplierFrameworkContractedRates",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsSupplierInternal",
                table: "Suppliers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasSupplierFrameworkContractedRates",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSupplierInternal",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HasSupplierFrameworkContractedRates", "IsSupplierInternal" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HasSupplierFrameworkContractedRates", "IsSupplierInternal" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HasSupplierFrameworkContractedRates", "IsSupplierInternal" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HasSupplierFrameworkContractedRates", "IsSupplierInternal" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HasSupplierFrameworkContractedRates", "IsSupplierInternal" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HasSupplierFrameworkContractedRates", "IsSupplierInternal" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HasSupplierFrameworkContractedRates", "IsSupplierInternal" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HasSupplierFrameworkContractedRates", "IsSupplierInternal" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HasSupplierFrameworkContractedRates", "IsSupplierInternal" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HasSupplierFrameworkContractedRates", "IsSupplierInternal" },
                values: new object[] { true, true });
        }
    }
}
