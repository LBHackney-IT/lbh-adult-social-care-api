using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdatePackageStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7)");

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "New", "New" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "In Progress", "InProgress" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusDisplayName",
                value: "Waiting for approval");

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Approved", "Approved" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Not Approved", "NotApproved" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Ended", "Ended" });

            migrationBuilder.InsertData(
                table: "PackageStatuses",
                columns: new[] { "Id", "StatusDisplayName", "StatusName" },
                values: new object[] { 7, "Cancelled", "Cancelled" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages");

            migrationBuilder.DeleteData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.CreateCheckConstraint(
                name: "CK_CarePackages_Status",
                table: "CarePackages",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6)");

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Draft", "Draft" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "New", "New" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusDisplayName",
                value: "Submitted for Approval");

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Reject Package", "Rejected" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Clarification Needed", "ClarificationNeeded" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Approved", "Approved" });
        }
    }
}
