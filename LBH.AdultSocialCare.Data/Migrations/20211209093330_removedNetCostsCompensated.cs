using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class removedNetCostsCompensated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetCostsCompensated",
                table: "InvoiceItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                columns: new[] { "LockoutEnd", "PasswordHash" },
                values: new object[] { new DateTimeOffset(new DateTime(2521, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEKYPIqwiDLYiR3uXhm/X4tDTTapNnoOouHxXDx5ATevmnXncR+pglbIgvvGx1TXLwg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NetCostsCompensated",
                table: "InvoiceItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                columns: new[] { "LockoutEnd", "PasswordHash" },
                values: new object[] { new DateTimeOffset(new DateTime(2521, 12, 8, 17, 25, 40, 935, DateTimeKind.Unspecified).AddTicks(7737), new TimeSpan(0, 3, 0, 0, 0)), "AQAAAAEAACcQAAAAEFZSuEqut3biK0yaWcDBpQR2draz7roFwzCnbTVF4yl38cMg1ULpUS3gVplbtitcmQ==" });
        }
    }
}
