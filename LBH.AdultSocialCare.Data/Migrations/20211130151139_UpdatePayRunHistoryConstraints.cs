using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdatePayRunHistoryConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistories_Type",
                table: "PayrunHistories");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistories_Type",
                table: "PayrunHistories",
                sql: "\"Type\" IN (1, 2, 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistories_Type",
                table: "PayrunHistories");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistories_Type",
                table: "PayrunHistories",
                sql: "\"Type\" IN (0, 1, 2)");
        }
    }
}
