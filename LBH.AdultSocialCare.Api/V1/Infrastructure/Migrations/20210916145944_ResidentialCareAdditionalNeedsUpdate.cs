using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class ResidentialCareAdditionalNeedsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareChargeElements_CareChargeStatuses_StatusId",
                table: "CareChargeElements");

            migrationBuilder.DropTable(
                name: "CareChargeStatuses");

            migrationBuilder.AddColumn<Guid>(
                name: "ResidentialCareAdditionalNeedsId",
                table: "ResidentialCareAdditionalNeedsCosts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CareChargeElementStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareChargeElementStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CareChargeElementStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Ended" },
                    { 3, "Cancelled" },
                    { 4, "Future" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_ResidentialCareAddition~",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "ResidentialCareAdditionalNeedsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CareChargeElements_CareChargeElementStatuses_StatusId",
                table: "CareChargeElements",
                column: "StatusId",
                principalTable: "CareChargeElementStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareAdditionalNeedsCosts_ResidentialCareAddition~",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "ResidentialCareAdditionalNeedsId",
                principalTable: "ResidentialCareAdditionalNeeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareChargeElements_CareChargeElementStatuses_StatusId",
                table: "CareChargeElements");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareAdditionalNeedsCosts_ResidentialCareAddition~",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.DropTable(
                name: "CareChargeElementStatuses");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_ResidentialCareAddition~",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.DropColumn(
                name: "ResidentialCareAdditionalNeedsId",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.CreateTable(
                name: "CareChargeStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareChargeStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CareChargeStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Ended" },
                    { 3, "Cancelled" },
                    { 4, "Future" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CareChargeElements_CareChargeStatuses_StatusId",
                table: "CareChargeElements",
                column: "StatusId",
                principalTable: "CareChargeStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
