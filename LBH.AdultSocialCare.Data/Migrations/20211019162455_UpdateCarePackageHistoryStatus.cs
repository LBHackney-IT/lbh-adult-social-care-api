using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdateCarePackageHistoryStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageHistories_Status",
                table: "CarePackageHistories");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageHistories_Status",
                table: "CarePackageHistories",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)");

            migrationBuilder.InsertData(
                table: "PackageStatuses",
                columns: new[] { "Id", "StatusDisplayName", "StatusName" },
                values: new object[] { 8, "Rejected", "Rejected" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackageHistories_Status",
                table: "CarePackageHistories");

            migrationBuilder.DeleteData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackageHistories_Status",
                table: "CarePackageHistories",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)");
        }
    }
}
