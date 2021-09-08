using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class movedCostClaimersToCareChargeElementLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareChargeElements_Clients_ClientId",
                table: "CareChargeElements");

            migrationBuilder.DropIndex(
                name: "IX_CareChargeElements_ClientId",
                table: "CareChargeElements");

            migrationBuilder.DropColumn(
                name: "ClaimCollectorId",
                table: "PackageCareCharges");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "CareChargeElements");

            migrationBuilder.AddColumn<int>(
                name: "ClaimCollectorId",
                table: "CareChargeElements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_ClaimCollectorId",
                table: "CareChargeElements",
                column: "ClaimCollectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareChargeElements_PackageCostClaimers_ClaimCollectorId",
                table: "CareChargeElements",
                column: "ClaimCollectorId",
                principalTable: "PackageCostClaimers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareChargeElements_PackageCostClaimers_ClaimCollectorId",
                table: "CareChargeElements");

            migrationBuilder.DropIndex(
                name: "IX_CareChargeElements_ClaimCollectorId",
                table: "CareChargeElements");

            migrationBuilder.DropColumn(
                name: "ClaimCollectorId",
                table: "CareChargeElements");

            migrationBuilder.AddColumn<int>(
                name: "ClaimCollectorId",
                table: "PackageCareCharges",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "CareChargeElements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_ClientId",
                table: "CareChargeElements",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareChargeElements_Clients_ClientId",
                table: "CareChargeElements",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
