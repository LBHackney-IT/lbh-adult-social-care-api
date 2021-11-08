using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class SupplierEntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageTypeId",
                table: "Suppliers");

            migrationBuilder.AddColumn<int>(
                name: "CedarId",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CedarName",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CedarReferenceNumber",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Suppliers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CedarId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CedarName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CedarReferenceNumber",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Suppliers");

            migrationBuilder.AddColumn<int>(
                name: "PackageTypeId",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PackageTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PackageTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PackageTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4,
                column: "PackageTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 5,
                column: "PackageTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 6,
                column: "PackageTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 7,
                column: "PackageTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 8,
                column: "PackageTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 9,
                column: "PackageTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 10,
                column: "PackageTypeId",
                value: 1);
        }
    }
}
