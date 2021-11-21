using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class nullableEnumConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems",
                sql: "\"ClaimCollector\" IN (1, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItems_ClaimCollector",
                table: "InvoiceItems");
        }
    }
}
