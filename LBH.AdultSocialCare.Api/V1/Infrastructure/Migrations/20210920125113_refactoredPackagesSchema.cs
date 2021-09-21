using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class refactoredPackagesSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CareChargeId",
                table: "NursingCarePackages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PackageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReclaimStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarePackage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PackageTypeId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    ServiceUserId = table.Column<Guid>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    PrimarySupportReason = table.Column<string>(nullable: true),
                    PackagingScheduling = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    StageId = table.Column<int>(nullable: false),
                    HasReclaim = table.Column<bool>(nullable: false),
                    Period = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackage", x => new { x.Id, x.PackageTypeId });
                    table.ForeignKey(
                        name: "FK_CarePackage_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackage_PackageType_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "PackageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackage_Clients_ServiceUserId",
                        column: x => x.ServiceUserId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackage_PackageStages_StageId",
                        column: x => x.StageId,
                        principalTable: "PackageStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackage_PackageStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PackageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackage_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarePackage_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarePackageDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarePackageId = table.Column<Guid>(nullable: false),
                    PackageTypeId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    PackageDetailType = table.Column<string>(nullable: true),
                    ServiceUserNeeds = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    CostPer = table.Column<string>(nullable: true),
                    UnitOfMeasure = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackageDetail", x => new { x.Id, x.CarePackageId, x.PackageTypeId });
                    table.ForeignKey(
                        name: "FK_CarePackageDetail_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageDetail_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarePackageDetail_CarePackage_CarePackageId_PackageTypeId",
                        columns: x => new { x.CarePackageId, x.PackageTypeId },
                        principalTable: "CarePackage",
                        principalColumns: new[] { "Id", "PackageTypeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarePackageReclaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarePackageId = table.Column<Guid>(nullable: false),
                    PackageTypeId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    ClaimCollectorId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AssessmentFileUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackageReclaim", x => new { x.Id, x.CarePackageId, x.PackageTypeId });
                    table.ForeignKey(
                        name: "FK_CarePackageReclaim_PackageCostClaimers_ClaimCollectorId",
                        column: x => x.ClaimCollectorId,
                        principalTable: "PackageCostClaimers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaim_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaim_ReclaimStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ReclaimStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaim_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaim_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaim_CarePackage_CarePackageId_PackageTypeId",
                        columns: x => new { x.CarePackageId, x.PackageTypeId },
                        principalTable: "CarePackage",
                        principalColumns: new[] { "Id", "PackageTypeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NursingCarePackageSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarePackageId = table.Column<Guid>(nullable: false),
                    PackageTypeId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    IsRespiteCare = table.Column<bool>(nullable: false),
                    IsDischarge = table.Column<bool>(nullable: false),
                    IsImmediate = table.Column<bool>(nullable: false),
                    IsReEnablement = table.Column<bool>(nullable: false),
                    IsS117Client = table.Column<bool>(nullable: false),
                    HasFnc = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCarePackageSettings", x => new { x.Id, x.CarePackageId, x.PackageTypeId });
                    table.ForeignKey(
                        name: "FK_NursingCarePackageSettings_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackageSettings_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCarePackageSettings_CarePackage_CarePackageId_Packag~",
                        columns: x => new { x.CarePackageId, x.PackageTypeId },
                        principalTable: "CarePackage",
                        principalColumns: new[] { "Id", "PackageTypeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCarePackageSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarePackageId = table.Column<Guid>(nullable: false),
                    PackageTypeId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    IsRespiteCare = table.Column<bool>(nullable: false),
                    IsDischarge = table.Column<bool>(nullable: false),
                    IsImmediate = table.Column<bool>(nullable: false),
                    IsReEnablement = table.Column<bool>(nullable: false),
                    IsS117Client = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCarePackageSettings", x => new { x.Id, x.CarePackageId, x.PackageTypeId });
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageSettings_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageSettings_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageSettings_CarePackage_CarePackageId_Pa~",
                        columns: x => new { x.CarePackageId, x.PackageTypeId },
                        principalTable: "CarePackage",
                        principalColumns: new[] { "Id", "PackageTypeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarePackageReclaimElement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarePackageReclaimId = table.Column<Guid>(nullable: false),
                    CarePackageId = table.Column<Guid>(nullable: false),
                    PackageTypeId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    ClaimCollectorId = table.Column<int>(nullable: false),
                    ClaimReason = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackageReclaimElement", x => new { x.Id, x.CarePackageReclaimId, x.CarePackageId, x.PackageTypeId });
                    table.ForeignKey(
                        name: "FK_CarePackageReclaimElement_PackageCostClaimers_ClaimCollecto~",
                        column: x => x.ClaimCollectorId,
                        principalTable: "PackageCostClaimers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaimElement_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaimElement_CareChargeStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "CareChargeStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaimElement_CareChargeTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CareChargeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaimElement_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaimElement_CarePackageReclaim_CarePackageRec~",
                        columns: x => new { x.CarePackageReclaimId, x.CarePackageId, x.PackageTypeId },
                        principalTable: "CarePackageReclaim",
                        principalColumns: new[] { "Id", "CarePackageId", "PackageTypeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_CareChargeId",
                table: "NursingCarePackages",
                column: "CareChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackage_CreatorId",
                table: "CarePackage",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackage_PackageTypeId",
                table: "CarePackage",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackage_ServiceUserId",
                table: "CarePackage",
                column: "ServiceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackage_StageId",
                table: "CarePackage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackage_StatusId",
                table: "CarePackage",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackage_SupplierId",
                table: "CarePackage",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackage_UpdaterId",
                table: "CarePackage",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageDetail_CreatorId",
                table: "CarePackageDetail",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageDetail_UpdaterId",
                table: "CarePackageDetail",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageDetail_CarePackageId_PackageTypeId",
                table: "CarePackageDetail",
                columns: new[] { "CarePackageId", "PackageTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaim_ClaimCollectorId",
                table: "CarePackageReclaim",
                column: "ClaimCollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaim_CreatorId",
                table: "CarePackageReclaim",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaim_StatusId",
                table: "CarePackageReclaim",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaim_SupplierId",
                table: "CarePackageReclaim",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaim_UpdaterId",
                table: "CarePackageReclaim",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaim_CarePackageId_PackageTypeId",
                table: "CarePackageReclaim",
                columns: new[] { "CarePackageId", "PackageTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaimElement_ClaimCollectorId",
                table: "CarePackageReclaimElement",
                column: "ClaimCollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaimElement_CreatorId",
                table: "CarePackageReclaimElement",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaimElement_StatusId",
                table: "CarePackageReclaimElement",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaimElement_TypeId",
                table: "CarePackageReclaimElement",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaimElement_UpdaterId",
                table: "CarePackageReclaimElement",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaimElement_CarePackageReclaimId_CarePackageI~",
                table: "CarePackageReclaimElement",
                columns: new[] { "CarePackageReclaimId", "CarePackageId", "PackageTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageSettings_CreatorId",
                table: "NursingCarePackageSettings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageSettings_UpdaterId",
                table: "NursingCarePackageSettings",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageSettings_CarePackageId_PackageTypeId",
                table: "NursingCarePackageSettings",
                columns: new[] { "CarePackageId", "PackageTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageSettings_CreatorId",
                table: "ResidentialCarePackageSettings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageSettings_UpdaterId",
                table: "ResidentialCarePackageSettings",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageSettings_CarePackageId_PackageTypeId",
                table: "ResidentialCarePackageSettings",
                columns: new[] { "CarePackageId", "PackageTypeId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_PackageCareCharges_CareChargeId",
                table: "NursingCarePackages",
                column: "CareChargeId",
                principalTable: "PackageCareCharges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_PackageCareCharges_CareChargeId",
                table: "NursingCarePackages");

            migrationBuilder.DropTable(
                name: "CarePackageDetail");

            migrationBuilder.DropTable(
                name: "CarePackageReclaimElement");

            migrationBuilder.DropTable(
                name: "NursingCarePackageSettings");

            migrationBuilder.DropTable(
                name: "ResidentialCarePackageSettings");

            migrationBuilder.DropTable(
                name: "CarePackageReclaim");

            migrationBuilder.DropTable(
                name: "ReclaimStatus");

            migrationBuilder.DropTable(
                name: "CarePackage");

            migrationBuilder.DropTable(
                name: "PackageType");

            migrationBuilder.DropIndex(
                name: "IX_NursingCarePackages_CareChargeId",
                table: "NursingCarePackages");

            migrationBuilder.DropColumn(
                name: "CareChargeId",
                table: "NursingCarePackages");
        }
    }
}
