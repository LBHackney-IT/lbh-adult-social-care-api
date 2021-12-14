using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class removedNullableEnumConstrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE ""CarePackageReclaims"" SET ""SubType"" = NULL WHERE ""SubType"" = 0;");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems",
                sql: "\"ClaimCollector\" IN (1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims",
                sql: "\"SubType\" IN (1, 2, 3)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDazWD57ElBqImqmsmQWOz2nSr6HJMoP4Zlugh04V5hRFU2mTNbrt+WZ6dTli/6vog==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems",
                sql: "\"ClaimCollector\" IN (NULL, 1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims",
                sql: "\"SubType\" IN (NULL, 1, 2, 3)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKYPIqwiDLYiR3uXhm/X4tDTTapNnoOouHxXDx5ATevmnXncR+pglbIgvvGx1TXLwg==");
        }
    }
}
