using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AddInvoiceCreditNoteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceItemPriceEffects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EffectName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItemPriceEffects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceNoteChargeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChargeTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceNoteChargeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceCreditNotes",
                columns: table => new
                {
                    InvoiceCreditNoteId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false),
                    ServiceUserId = table.Column<Guid>(nullable: false),
                    SentOrInvoiced = table.Column<bool>(nullable: false),
                    HasBeenAddedToUserInvoice = table.Column<bool>(nullable: false),
                    PackageTypeId = table.Column<int>(nullable: false),
                    PackageId = table.Column<int>(nullable: false),
                    ChargeTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    PriceEffectId = table.Column<int>(nullable: false),
                    CareChargeElementId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceCreditNotes", x => x.InvoiceCreditNoteId);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_CareChargeElements_CareChargeElementId",
                        column: x => x.CareChargeElementId,
                        principalTable: "CareChargeElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_InvoiceNoteChargeTypes_ChargeTypeId",
                        column: x => x.ChargeTypeId,
                        principalTable: "InvoiceNoteChargeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_Packages_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_InvoiceItemPriceEffects_PriceEffectId",
                        column: x => x.PriceEffectId,
                        principalTable: "InvoiceItemPriceEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_Clients_ServiceUserId",
                        column: x => x.ServiceUserId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_CareChargeElementId",
                table: "InvoiceCreditNotes",
                column: "CareChargeElementId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_ChargeTypeId",
                table: "InvoiceCreditNotes",
                column: "ChargeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_CreatorId",
                table: "InvoiceCreditNotes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_PackageTypeId",
                table: "InvoiceCreditNotes",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_PriceEffectId",
                table: "InvoiceCreditNotes",
                column: "PriceEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_ServiceUserId",
                table: "InvoiceCreditNotes",
                column: "ServiceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_SupplierId",
                table: "InvoiceCreditNotes",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_UpdaterId",
                table: "InvoiceCreditNotes",
                column: "UpdaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceCreditNotes");

            migrationBuilder.DropTable(
                name: "InvoiceNoteChargeTypes");

            migrationBuilder.DropTable(
                name: "InvoiceItemPriceEffects");
        }
    }
}
