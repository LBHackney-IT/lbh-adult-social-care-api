using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class EnumConstraintUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Status",
                table: "Payruns");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistories_Status",
                table: "PayrunHistories");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistories_Type",
                table: "PayrunHistories");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_PriceEffect",
                table: "InvoiceItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageSchedulingOptions_Id",
                table: "CarePackageSchedulingOptions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_PackageScheduling",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_PackageType",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageResources_Type",
                table: "CarePackageResources");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_ClaimCollector",
                table: "CarePackageReclaims");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_Status",
                table: "CarePackageReclaims");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_Type",
                table: "CarePackageReclaims");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageHistories_Status",
                table: "CarePackageHistories");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageDetails_CostPeriod",
                table: "CarePackageDetails");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageDetails_ServicePeriod",
                table: "CarePackageDetails");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageDetails_Type",
                table: "CarePackageDetails");

            migrationBuilder.Sql(@"UPDATE ""CarePackageReclaims"" SET ""Status"" = 1 WHERE ""Status"" = 0;");
            migrationBuilder.Sql(@"UPDATE ""CarePackageHistories"" SET ""Status"" = 13 WHERE ""Status"" = 0;");
            migrationBuilder.Sql(
                @"UPDATE ""CarePackageDetails"" SET ""ServicePeriod"" = ""CostPeriod"" WHERE ""ServicePeriod"" = 0;");
            migrationBuilder.Sql(@"UPDATE ""CarePackageReclaims"" SET ""Type"" = 2 WHERE ""Type"" = 0;");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Status",
                table: "Payruns",
                sql: "\"Status\" IN (1, 2, 3, 4, 5, 6, 7, 8)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns",
                sql: "\"Type\" IN (1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices",
                sql: "\"InvoiceStatus\" IN (1, 2, 3, 4, 5, 6)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistories_Status",
                table: "PayrunHistories",
                sql: "\"Status\" IN (1, 2, 3, 4, 5, 6, 7, 8)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistories_Type",
                table: "PayrunHistories",
                sql: "\"Type\" IN (1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems",
                sql: "\"ClaimCollector\" IN (0, 1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_PriceEffect",
                table: "InvoiceItems",
                sql: "\"PriceEffect\" IN (1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageSchedulingOptions_Id",
                table: "CarePackageSchedulingOptions",
                sql: "\"Id\" IN (1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_PackageScheduling",
                table: "CarePackages",
                sql: "\"PackageScheduling\" IN (1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_PackageType",
                table: "CarePackages",
                sql: "\"PackageType\" IN (2, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages",
                sql: "\"Status\" IN (1, 2, 3, 4, 5, 6, 7, 8)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageResources_Type",
                table: "CarePackageResources",
                sql: "\"Type\" IN (1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_ClaimCollector",
                table: "CarePackageReclaims",
                sql: "\"ClaimCollector\" IN (1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_Status",
                table: "CarePackageReclaims",
                sql: "\"Status\" IN (1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_Type",
                table: "CarePackageReclaims",
                sql: "\"Type\" IN (1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageHistories_Status",
                table: "CarePackageHistories",
                sql: "\"Status\" IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageDetails_CostPeriod",
                table: "CarePackageDetails",
                sql: "\"CostPeriod\" IN (1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageDetails_ServicePeriod",
                table: "CarePackageDetails",
                sql: "\"ServicePeriod\" IN (1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageDetails_Type",
                table: "CarePackageDetails",
                sql: "\"Type\" IN (1, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "SubType",
                table: "CarePackageReclaims",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Status",
                table: "Payruns");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistories_Status",
                table: "PayrunHistories");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistories_Type",
                table: "PayrunHistories");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_PriceEffect",
                table: "InvoiceItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageSchedulingOptions_Id",
                table: "CarePackageSchedulingOptions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_PackageScheduling",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_PackageType",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageResources_Type",
                table: "CarePackageResources");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_ClaimCollector",
                table: "CarePackageReclaims");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_Status",
                table: "CarePackageReclaims");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageReclaims_Type",
                table: "CarePackageReclaims");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageHistories_Status",
                table: "CarePackageHistories");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageDetails_CostPeriod",
                table: "CarePackageDetails");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageDetails_ServicePeriod",
                table: "CarePackageDetails");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageDetails_Type",
                table: "CarePackageDetails");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Status",
                table: "Payruns",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns",
                sql: "\"Type\" IN (0, 1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunInvoices_InvoiceStatus",
                table: "PayrunInvoices",
                sql: "\"InvoiceStatus\" IN (0, 1, 2, 3, 4, 5, 6)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistories_Status",
                table: "PayrunHistories",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistories_Type",
                table: "PayrunHistories",
                sql: "\"Type\" IN (0, 1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems",
                sql: "\"ClaimCollector\" IN (1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_PriceEffect",
                table: "InvoiceItems",
                sql: "\"PriceEffect\" IN (0, 1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageSchedulingOptions_Id",
                table: "CarePackageSchedulingOptions",
                sql: "\"Id\" IN (0, 1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_PackageScheduling",
                table: "CarePackages",
                sql: "\"PackageScheduling\" IN (0, 1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_PackageType",
                table: "CarePackages",
                sql: "\"PackageType\" IN (0, 2, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageResources_Type",
                table: "CarePackageResources",
                sql: "\"Type\" IN (0, 1, 2, 3)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_ClaimCollector",
                table: "CarePackageReclaims",
                sql: "\"ClaimCollector\" IN (0, 1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_Status",
                table: "CarePackageReclaims",
                sql: "\"Status\" IN (0, 1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageReclaims_Type",
                table: "CarePackageReclaims",
                sql: "\"Type\" IN (0, 1, 2)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageHistories_Status",
                table: "CarePackageHistories",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageDetails_CostPeriod",
                table: "CarePackageDetails",
                sql: "\"CostPeriod\" IN (0, 1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageDetails_ServicePeriod",
                table: "CarePackageDetails",
                sql: "\"ServicePeriod\" IN (0, 1, 2, 3, 4)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageDetails_Type",
                table: "CarePackageDetails",
                sql: "\"Type\" IN (0, 1, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "SubType",
                table: "CarePackageReclaims",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
