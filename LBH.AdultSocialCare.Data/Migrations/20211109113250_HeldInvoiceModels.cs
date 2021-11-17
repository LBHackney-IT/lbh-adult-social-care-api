using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class HeldInvoiceModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PayrunInvoices",
                table: "PayrunInvoices");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PayrunInvoices",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayrunInvoices",
                table: "PayrunInvoices",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeldInvoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PayRunInvoiceId = table.Column<Guid>(nullable: false),
                    ActionRequiredFromId = table.Column<int>(nullable: false),
                    ReasonForHolding = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeldInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeldInvoices_Departments_ActionRequiredFromId",
                        column: x => x.ActionRequiredFromId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeldInvoices_PayrunInvoices_PayRunInvoiceId",
                        column: x => x.PayRunInvoiceId,
                        principalTable: "PayrunInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
                values: new object[,]
                {
                    { 1, "Brokerage" },
                    { 2, "Finance" }
                });
#pragma warning restore CA1814 // Prefer jagged arrays over multidimensional

            migrationBuilder.CreateIndex(
                name: "IX_PayrunInvoices_PayrunId_InvoiceId",
                table: "PayrunInvoices",
                columns: new[] { "PayrunId", "InvoiceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeldInvoices_ActionRequiredFromId",
                table: "HeldInvoices",
                column: "ActionRequiredFromId");

            migrationBuilder.CreateIndex(
                name: "IX_HeldInvoices_PayRunInvoiceId",
                table: "HeldInvoices",
                column: "PayRunInvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeldInvoices");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayrunInvoices",
                table: "PayrunInvoices");

            migrationBuilder.DropIndex(
                name: "IX_PayrunInvoices_PayrunId_InvoiceId",
                table: "PayrunInvoices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PayrunInvoices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayrunInvoices",
                table: "PayrunInvoices",
                columns: new[] { "PayrunId", "InvoiceId" });
        }
    }
}
