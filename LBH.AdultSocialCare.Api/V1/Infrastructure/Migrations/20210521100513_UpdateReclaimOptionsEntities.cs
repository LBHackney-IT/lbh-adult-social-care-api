using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdateReclaimOptionsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReclaimAmountOptions",
                columns: table => new
                {
                    AmountOptionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AmountOptionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimAmountOptions", x => x.AmountOptionId);
                });

            migrationBuilder.CreateTable(
                name: "ReclaimCategories",
                columns: table => new
                {
                    ReclaimCategoryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReclaimCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimCategories", x => x.ReclaimCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ReclaimFroms",
                columns: table => new
                {
                    ReclaimFromId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReclaimFromName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimFroms", x => x.ReclaimFromId);
                });

            migrationBuilder.CreateTable(
                name: "DayCarePackageReclaims",
                columns: table => new
                {
                    DayCarePackageReclaimId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    DayCarePackageId = table.Column<Guid>(nullable: false),
                    ReclaimFromId = table.Column<int>(nullable: false),
                    ReclaimCategoryId = table.Column<int>(nullable: false),
                    ReclaimAmountOptionId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCarePackageReclaims", x => x.DayCarePackageReclaimId);
                    table.ForeignKey(
                        name: "FK_DayCarePackageReclaims_ReclaimAmountOptions_ReclaimAmountOp~",
                        column: x => x.ReclaimAmountOptionId,
                        principalTable: "ReclaimAmountOptions",
                        principalColumn: "AmountOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackageReclaims_ReclaimCategories_ReclaimCategoryId",
                        column: x => x.ReclaimCategoryId,
                        principalTable: "ReclaimCategories",
                        principalColumn: "ReclaimCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackageReclaims_ReclaimFroms_ReclaimFromId",
                        column: x => x.ReclaimFromId,
                        principalTable: "ReclaimFroms",
                        principalColumn: "ReclaimFromId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackageReclaims",
                columns: table => new
                {
                    HomeCarePackageReclaimId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    HomeCarePackageId = table.Column<Guid>(nullable: false),
                    ReclaimFromId = table.Column<int>(nullable: false),
                    ReclaimCategoryId = table.Column<int>(nullable: false),
                    ReclaimAmountOptionId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarePackageReclaims", x => x.HomeCarePackageReclaimId);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageReclaims_ReclaimAmountOptions_ReclaimAmountO~",
                        column: x => x.ReclaimAmountOptionId,
                        principalTable: "ReclaimAmountOptions",
                        principalColumn: "AmountOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageReclaims_ReclaimCategories_ReclaimCategoryId",
                        column: x => x.ReclaimCategoryId,
                        principalTable: "ReclaimCategories",
                        principalColumn: "ReclaimCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageReclaims_ReclaimFroms_ReclaimFromId",
                        column: x => x.ReclaimFromId,
                        principalTable: "ReclaimFroms",
                        principalColumn: "ReclaimFromId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NursingCarePackageReclaims",
                columns: table => new
                {
                    NursingCarePackageReclaimId = table.Column<Guid>(nullable: false),
                    NursingCarePackageId = table.Column<Guid>(nullable: false),
                    ReclaimFromId = table.Column<int>(nullable: false),
                    ReclaimCategoryId = table.Column<int>(nullable: false),
                    ReclaimAmountOptionId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCarePackageReclaims", x => x.NursingCarePackageReclaimId);
                    table.ForeignKey(
                        name: "FK_NursingCarePackageReclaims_ReclaimAmountOptions_ReclaimAmou~",
                        column: x => x.ReclaimAmountOptionId,
                        principalTable: "ReclaimAmountOptions",
                        principalColumn: "AmountOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackageReclaims_ReclaimCategories_ReclaimCategor~",
                        column: x => x.ReclaimCategoryId,
                        principalTable: "ReclaimCategories",
                        principalColumn: "ReclaimCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackageReclaims_ReclaimFroms_ReclaimFromId",
                        column: x => x.ReclaimFromId,
                        principalTable: "ReclaimFroms",
                        principalColumn: "ReclaimFromId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ReclaimAmountOptions",
                columns: new[] { "AmountOptionId", "AmountOptionName" },
                values: new object[,]
                {
                    { 1, "Percentage" },
                    { 2, "Fixed amount - one off" },
                    { 3, "Fixed amount - weekly" }
                });

            migrationBuilder.InsertData(
                table: "ReclaimCategories",
                columns: new[] { "ReclaimCategoryId", "ReclaimCategoryName" },
                values: new object[,]
                {
                    { 1, "Option 1" },
                    { 2, "Option 2" }
                });

            migrationBuilder.InsertData(
                table: "ReclaimFroms",
                columns: new[] { "ReclaimFromId", "ReclaimFromName" },
                values: new object[,]
                {
                    { 1, "NHS" },
                    { 2, "CCG" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageReclaims_ReclaimAmountOptionId",
                table: "DayCarePackageReclaims",
                column: "ReclaimAmountOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageReclaims_ReclaimCategoryId",
                table: "DayCarePackageReclaims",
                column: "ReclaimCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageReclaims_ReclaimFromId",
                table: "DayCarePackageReclaims",
                column: "ReclaimFromId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageReclaims_ReclaimAmountOptionId",
                table: "HomeCarePackageReclaims",
                column: "ReclaimAmountOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageReclaims_ReclaimCategoryId",
                table: "HomeCarePackageReclaims",
                column: "ReclaimCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageReclaims_ReclaimFromId",
                table: "HomeCarePackageReclaims",
                column: "ReclaimFromId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageReclaims_ReclaimAmountOptionId",
                table: "NursingCarePackageReclaims",
                column: "ReclaimAmountOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageReclaims_ReclaimCategoryId",
                table: "NursingCarePackageReclaims",
                column: "ReclaimCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageReclaims_ReclaimFromId",
                table: "NursingCarePackageReclaims",
                column: "ReclaimFromId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "HomeCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "NursingCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "ReclaimAmountOptions");

            migrationBuilder.DropTable(
                name: "ReclaimCategories");

            migrationBuilder.DropTable(
                name: "ReclaimFroms");
        }
    }
}
