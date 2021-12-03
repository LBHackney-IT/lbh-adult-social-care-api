using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AddPayRunHistoryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PayrunHistory",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistory_Type",
                table: "PayrunHistory",
                sql: "\"Type\" IN (1, 2)");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 1,
                column: "CederBudgetCode",
                value: "D0822");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 2,
                column: "CederBudgetCode",
                value: "D0823");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 3,
                column: "CederBudgetCode",
                value: "D0824");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 4,
                column: "CederBudgetCode",
                value: "D0825");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 5,
                column: "CederBudgetCode",
                value: "D0826");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 6,
                column: "CederBudgetCode",
                value: "D0828");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 7,
                column: "CederBudgetCode",
                value: "D0829");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistory_Type",
                table: "PayrunHistory");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PayrunHistory");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 1,
                column: "CederBudgetCode",
                value: "Ceder - Physical Support");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 2,
                column: "CederBudgetCode",
                value: "Ceder Sensory Support");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 3,
                column: "CederBudgetCode",
                value: "Ceder Support with memory and cognition");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 4,
                column: "CederBudgetCode",
                value: "Ceder Learning Disability Support");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 5,
                column: "CederBudgetCode",
                value: "Ceder Mental Health Support (ASC)");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 6,
                column: "CederBudgetCode",
                value: "Ceder Social Support");

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 7,
                column: "CederBudgetCode",
                value: "Ceder Mental Health Support (ELFT)");
        }
    }
}
