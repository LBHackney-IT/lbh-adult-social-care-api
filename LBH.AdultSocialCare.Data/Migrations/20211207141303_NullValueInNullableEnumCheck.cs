using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class NullValueInNullableEnumCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims");

            migrationBuilder.Sql(@"UPDATE ""CarePackageReclaims"" SET ""SubType"" = NULL WHERE ""SubType"" = 0;");
            migrationBuilder.Sql(
                @"UPDATE ""InvoiceItems"" SET ""ClaimCollector"" = NULL WHERE ""ClaimCollector"" = 0;");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems",
                sql: "\"ClaimCollector\" IN (NULL, 1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims",
                sql: "\"SubType\" IN (NULL, 1, 2, 3)");
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
                sql: "\"ClaimCollector\" IN (0, 1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_SubType",
                table: "CarePackageReclaims",
                sql: "\"SubType\" IN (0, 1, 2, 3)");
        }
    }
}
