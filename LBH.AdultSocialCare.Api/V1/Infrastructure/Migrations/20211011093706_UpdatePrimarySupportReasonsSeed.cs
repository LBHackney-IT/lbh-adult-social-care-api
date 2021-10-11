using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdatePrimarySupportReasonsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 1,
                columns: new[] { "CederBudgetCode", "PrimarySupportReasonName" },
                values: new object[] { "Ceder - Physical Support", "Physical Support" });

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 2,
                columns: new[] { "CederBudgetCode", "PrimarySupportReasonName" },
                values: new object[] { "Ceder Sensory Support", "Sensory Support" });

            migrationBuilder.InsertData(
                table: "PrimarySupportReasons",
                columns: new[] { "PrimarySupportReasonId", "CederBudgetCode", "PrimarySupportReasonName" },
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
                values: new object[,]
                {
                    { 3, "Ceder Support with memory and cognition", "Support with memory and cognition" },
                    { 4, "Ceder Learning Disability Support", "Learning Disability Support" },
                    { 5, "Ceder Mental Health Support (ASC)", "Mental Health Support (ASC)" },
                    { 6, "Ceder Social Support", "Social Support" },
                    { 7, "Ceder Mental Health Support (ELFT)", "Mental Health Support (ELFT)" }
                });
#pragma warning restore CA1814 // Prefer jagged arrays over multidimensional
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 1,
                columns: new[] { "CederBudgetCode", "PrimarySupportReasonName" },
                values: new object[] { "Ceder Budget Code 1", "Primary Support Reason 1" });

            migrationBuilder.UpdateData(
                table: "PrimarySupportReasons",
                keyColumn: "PrimarySupportReasonId",
                keyValue: 2,
                columns: new[] { "CederBudgetCode", "PrimarySupportReasonName" },
                values: new object[] { "Ceder Budget Code 2", "Primary Support Reason 2" });
        }
    }
}
