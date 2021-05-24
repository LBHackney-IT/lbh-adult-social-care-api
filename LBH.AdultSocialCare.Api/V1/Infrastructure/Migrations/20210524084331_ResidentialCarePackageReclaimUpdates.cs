using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class ResidentialCarePackageReclaimUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "ResidentialCarePackages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "ResidentialCarePackages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "NursingCarePackages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "NursingCarePackages",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "NursingCarePackageReclaims",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "NursingCarePackageReclaims",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "ResidentialCarePackageReclaims",
                columns: table => new
                {
                    ResidentialCarePackageReclaimId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    ResidentialCarePackageId = table.Column<Guid>(nullable: false),
                    ReclaimFromId = table.Column<int>(nullable: false),
                    ReclaimCategoryId = table.Column<int>(nullable: false),
                    ReclaimAmountOptionId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCarePackageReclaims", x => x.ResidentialCarePackageReclaimId);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageReclaims_ReclaimAmountOptions_Reclaim~",
                        column: x => x.ReclaimAmountOptionId,
                        principalTable: "ReclaimAmountOptions",
                        principalColumn: "AmountOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageReclaims_ReclaimCategories_ReclaimCat~",
                        column: x => x.ReclaimCategoryId,
                        principalTable: "ReclaimCategories",
                        principalColumn: "ReclaimCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageReclaims_ReclaimFroms_ReclaimFromId",
                        column: x => x.ReclaimFromId,
                        principalTable: "ReclaimFroms",
                        principalColumn: "ReclaimFromId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackages_StageId",
                table: "ResidentialCarePackages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackages_SupplierId",
                table: "ResidentialCarePackages",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_StageId",
                table: "NursingCarePackages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_SupplierId",
                table: "NursingCarePackages",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageReclaims_ReclaimAmountOptionId",
                table: "ResidentialCarePackageReclaims",
                column: "ReclaimAmountOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageReclaims_ReclaimCategoryId",
                table: "ResidentialCarePackageReclaims",
                column: "ReclaimCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageReclaims_ReclaimFromId",
                table: "ResidentialCarePackageReclaims",
                column: "ReclaimFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_HomeCareStages_StageId",
                table: "NursingCarePackages",
                column: "StageId",
                principalTable: "HomeCareStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_Suppliers_SupplierId",
                table: "NursingCarePackages",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackages_HomeCareStages_StageId",
                table: "ResidentialCarePackages",
                column: "StageId",
                principalTable: "HomeCareStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackages_Suppliers_SupplierId",
                table: "ResidentialCarePackages",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_HomeCareStages_StageId",
                table: "NursingCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_Suppliers_SupplierId",
                table: "NursingCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackages_HomeCareStages_StageId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackages_Suppliers_SupplierId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropTable(
                name: "ResidentialCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCarePackages_StageId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCarePackages_SupplierId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropIndex(
                name: "IX_NursingCarePackages_StageId",
                table: "NursingCarePackages");

            migrationBuilder.DropIndex(
                name: "IX_NursingCarePackages_SupplierId",
                table: "NursingCarePackages");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "NursingCarePackages");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "NursingCarePackages");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "NursingCarePackageReclaims");
        }
    }
}
