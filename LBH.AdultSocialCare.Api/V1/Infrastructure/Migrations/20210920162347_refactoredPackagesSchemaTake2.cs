using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class refactoredPackagesSchemaTake2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarePackage_AspNetUsers_CreatorId",
                table: "CarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackage_PackageType_PackageTypeId",
                table: "CarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackage_Clients_ServiceUserId",
                table: "CarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackage_PackageStages_StageId",
                table: "CarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackage_PackageStatuses_StatusId",
                table: "CarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackage_Suppliers_SupplierId",
                table: "CarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackage_AspNetUsers_UpdaterId",
                table: "CarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageDetail_AspNetUsers_CreatorId",
                table: "CarePackageDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageDetail_AspNetUsers_UpdaterId",
                table: "CarePackageDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageDetail_CarePackage_CarePackageId_PackageTypeId",
                table: "CarePackageDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaim_PackageCostClaimers_ClaimCollectorId",
                table: "CarePackageReclaim");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaim_AspNetUsers_CreatorId",
                table: "CarePackageReclaim");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaim_ReclaimStatus_StatusId",
                table: "CarePackageReclaim");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaim_Suppliers_SupplierId",
                table: "CarePackageReclaim");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaim_AspNetUsers_UpdaterId",
                table: "CarePackageReclaim");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaim_CarePackage_CarePackageId_PackageTypeId",
                table: "CarePackageReclaim");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackageSettings_CarePackage_CarePackageId_Packag~",
                table: "NursingCarePackageSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackageSettings_CarePackage_CarePackageId_Pa~",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.DropTable(
                name: "CarePackageReclaimElement");

            migrationBuilder.DropTable(
                name: "PackageType");

            migrationBuilder.DropTable(
                name: "ReclaimStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentialCarePackageSettings",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCarePackageSettings_CarePackageId_PackageTypeId",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NursingCarePackageSettings",
                table: "NursingCarePackageSettings");

            migrationBuilder.DropIndex(
                name: "IX_NursingCarePackageSettings_CarePackageId_PackageTypeId",
                table: "NursingCarePackageSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarePackageReclaim",
                table: "CarePackageReclaim");

            migrationBuilder.DropIndex(
                name: "IX_CarePackageReclaim_ClaimCollectorId",
                table: "CarePackageReclaim");

            migrationBuilder.DropIndex(
                name: "IX_CarePackageReclaim_StatusId",
                table: "CarePackageReclaim");

            migrationBuilder.DropIndex(
                name: "IX_CarePackageReclaim_CarePackageId_PackageTypeId",
                table: "CarePackageReclaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarePackageDetail",
                table: "CarePackageDetail");

            migrationBuilder.DropIndex(
                name: "IX_CarePackageDetail_CarePackageId_PackageTypeId",
                table: "CarePackageDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarePackage",
                table: "CarePackage");

            migrationBuilder.DropIndex(
                name: "IX_CarePackage_PackageTypeId",
                table: "CarePackage");

            migrationBuilder.DropColumn(
                name: "PackageTypeId",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.DropColumn(
                name: "PackageTypeId",
                table: "NursingCarePackageSettings");

            migrationBuilder.DropColumn(
                name: "PackageTypeId",
                table: "CarePackageReclaim");

            migrationBuilder.DropColumn(
                name: "ClaimCollectorId",
                table: "CarePackageReclaim");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "CarePackageReclaim");

            migrationBuilder.DropColumn(
                name: "PackageTypeId",
                table: "CarePackageDetail");

            migrationBuilder.DropColumn(
                name: "PackageTypeId",
                table: "CarePackage");

            migrationBuilder.RenameTable(
                name: "CarePackageReclaim",
                newName: "CarePackageReclaims");

            migrationBuilder.RenameTable(
                name: "CarePackageDetail",
                newName: "CarePackageDetails");

            migrationBuilder.RenameTable(
                name: "CarePackage",
                newName: "CarePackages");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackageReclaim_UpdaterId",
                table: "CarePackageReclaims",
                newName: "IX_CarePackageReclaims_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackageReclaim_SupplierId",
                table: "CarePackageReclaims",
                newName: "IX_CarePackageReclaims_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackageReclaim_CreatorId",
                table: "CarePackageReclaims",
                newName: "IX_CarePackageReclaims_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackageDetail_UpdaterId",
                table: "CarePackageDetails",
                newName: "IX_CarePackageDetails_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackageDetail_CreatorId",
                table: "CarePackageDetails",
                newName: "IX_CarePackageDetails_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackage_UpdaterId",
                table: "CarePackages",
                newName: "IX_CarePackages_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackage_SupplierId",
                table: "CarePackages",
                newName: "IX_CarePackages_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackage_StatusId",
                table: "CarePackages",
                newName: "IX_CarePackages_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackage_StageId",
                table: "CarePackages",
                newName: "IX_CarePackages_StageId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackage_ServiceUserId",
                table: "CarePackages",
                newName: "IX_CarePackages_ServiceUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackage_CreatorId",
                table: "CarePackages",
                newName: "IX_CarePackages_CreatorId");

            migrationBuilder.AddColumn<int>(
                name: "ClaimCollector",
                table: "CarePackageReclaims",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClaimReason",
                table: "CarePackageReclaims",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CarePackageReclaims",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubType",
                table: "CarePackageReclaims",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "CarePackageReclaims",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropColumn(
                name: "Period",
                table: "CarePackageDetails"
            );

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "CarePackageDetails",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<int>(
                name: "PackageType",
                table: "CarePackages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentialCarePackageSettings",
                table: "ResidentialCarePackageSettings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NursingCarePackageSettings",
                table: "NursingCarePackageSettings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarePackageReclaims",
                table: "CarePackageReclaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarePackageDetails",
                table: "CarePackageDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarePackages",
                table: "CarePackages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageSettings_CarePackageId",
                table: "ResidentialCarePackageSettings",
                column: "CarePackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageSettings_CarePackageId",
                table: "NursingCarePackageSettings",
                column: "CarePackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaims_CarePackageId",
                table: "CarePackageReclaims",
                column: "CarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageDetails_CarePackageId",
                table: "CarePackageDetails",
                column: "CarePackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageDetails_CarePackages_CarePackageId",
                table: "CarePackageDetails",
                column: "CarePackageId",
                principalTable: "CarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageDetails_AspNetUsers_CreatorId",
                table: "CarePackageDetails",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageDetails_AspNetUsers_UpdaterId",
                table: "CarePackageDetails",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaims_CarePackages_CarePackageId",
                table: "CarePackageReclaims",
                column: "CarePackageId",
                principalTable: "CarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaims_AspNetUsers_CreatorId",
                table: "CarePackageReclaims",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaims_Suppliers_SupplierId",
                table: "CarePackageReclaims",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaims_AspNetUsers_UpdaterId",
                table: "CarePackageReclaims",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_AspNetUsers_CreatorId",
                table: "CarePackages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_Clients_ServiceUserId",
                table: "CarePackages",
                column: "ServiceUserId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_PackageStages_StageId",
                table: "CarePackages",
                column: "StageId",
                principalTable: "PackageStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_PackageStatuses_StatusId",
                table: "CarePackages",
                column: "StatusId",
                principalTable: "PackageStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_Suppliers_SupplierId",
                table: "CarePackages",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_AspNetUsers_UpdaterId",
                table: "CarePackages",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackageSettings_CarePackages_CarePackageId",
                table: "NursingCarePackageSettings",
                column: "CarePackageId",
                principalTable: "CarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackageSettings_CarePackages_CarePackageId",
                table: "ResidentialCarePackageSettings",
                column: "CarePackageId",
                principalTable: "CarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageDetails_CarePackages_CarePackageId",
                table: "CarePackageDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageDetails_AspNetUsers_CreatorId",
                table: "CarePackageDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageDetails_AspNetUsers_UpdaterId",
                table: "CarePackageDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaims_CarePackages_CarePackageId",
                table: "CarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaims_AspNetUsers_CreatorId",
                table: "CarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaims_Suppliers_SupplierId",
                table: "CarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackageReclaims_AspNetUsers_UpdaterId",
                table: "CarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_AspNetUsers_CreatorId",
                table: "CarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_Clients_ServiceUserId",
                table: "CarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_PackageStages_StageId",
                table: "CarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_PackageStatuses_StatusId",
                table: "CarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_Suppliers_SupplierId",
                table: "CarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_AspNetUsers_UpdaterId",
                table: "CarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackageSettings_CarePackages_CarePackageId",
                table: "NursingCarePackageSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackageSettings_CarePackages_CarePackageId",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentialCarePackageSettings",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCarePackageSettings_CarePackageId",
                table: "ResidentialCarePackageSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NursingCarePackageSettings",
                table: "NursingCarePackageSettings");

            migrationBuilder.DropIndex(
                name: "IX_NursingCarePackageSettings_CarePackageId",
                table: "NursingCarePackageSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarePackages",
                table: "CarePackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarePackageReclaims",
                table: "CarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_CarePackageReclaims_CarePackageId",
                table: "CarePackageReclaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarePackageDetails",
                table: "CarePackageDetails");

            migrationBuilder.DropIndex(
                name: "IX_CarePackageDetails_CarePackageId",
                table: "CarePackageDetails");

            migrationBuilder.DropColumn(
                name: "PackageType",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "ClaimCollector",
                table: "CarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "ClaimReason",
                table: "CarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "SubType",
                table: "CarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CarePackageReclaims");

            migrationBuilder.RenameTable(
                name: "CarePackages",
                newName: "CarePackage");

            migrationBuilder.RenameTable(
                name: "CarePackageReclaims",
                newName: "CarePackageReclaim");

            migrationBuilder.RenameTable(
                name: "CarePackageDetails",
                newName: "CarePackageDetail");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackages_UpdaterId",
                table: "CarePackage",
                newName: "IX_CarePackage_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackages_SupplierId",
                table: "CarePackage",
                newName: "IX_CarePackage_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackages_StatusId",
                table: "CarePackage",
                newName: "IX_CarePackage_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackages_StageId",
                table: "CarePackage",
                newName: "IX_CarePackage_StageId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackages_ServiceUserId",
                table: "CarePackage",
                newName: "IX_CarePackage_ServiceUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackages_CreatorId",
                table: "CarePackage",
                newName: "IX_CarePackage_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackageReclaims_UpdaterId",
                table: "CarePackageReclaim",
                newName: "IX_CarePackageReclaim_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackageReclaims_SupplierId",
                table: "CarePackageReclaim",
                newName: "IX_CarePackageReclaim_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackageReclaims_CreatorId",
                table: "CarePackageReclaim",
                newName: "IX_CarePackageReclaim_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackageDetails_UpdaterId",
                table: "CarePackageDetail",
                newName: "IX_CarePackageDetail_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_CarePackageDetails_CreatorId",
                table: "CarePackageDetail",
                newName: "IX_CarePackageDetail_CreatorId");

            migrationBuilder.AddColumn<int>(
                name: "PackageTypeId",
                table: "ResidentialCarePackageSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageTypeId",
                table: "NursingCarePackageSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageTypeId",
                table: "CarePackage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageTypeId",
                table: "CarePackageReclaim",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClaimCollectorId",
                table: "CarePackageReclaim",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "CarePackageReclaim",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropColumn(
                name: "Period",
                table: "CarePackageDetails"
            );

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "CarePackageDetails"
            );

            migrationBuilder.AlterColumn<string>(
                name: "Period",
                table: "CarePackageDetail",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PackageTypeId",
                table: "CarePackageDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentialCarePackageSettings",
                table: "ResidentialCarePackageSettings",
                columns: new[] { "Id", "CarePackageId", "PackageTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_NursingCarePackageSettings",
                table: "NursingCarePackageSettings",
                columns: new[] { "Id", "CarePackageId", "PackageTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarePackage",
                table: "CarePackage",
                columns: new[] { "Id", "PackageTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarePackageReclaim",
                table: "CarePackageReclaim",
                columns: new[] { "Id", "CarePackageId", "PackageTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarePackageDetail",
                table: "CarePackageDetail",
                columns: new[] { "Id", "CarePackageId", "PackageTypeId" });

            migrationBuilder.CreateTable(
                name: "CarePackageReclaimElement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarePackageReclaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    CarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    PackageTypeId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    ClaimCollectorId = table.Column<int>(type: "integer", nullable: false),
                    ClaimReason = table.Column<string>(type: "text", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "PackageType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReclaimStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageSettings_CarePackageId_PackageTypeId",
                table: "ResidentialCarePackageSettings",
                columns: new[] { "CarePackageId", "PackageTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageSettings_CarePackageId_PackageTypeId",
                table: "NursingCarePackageSettings",
                columns: new[] { "CarePackageId", "PackageTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarePackage_PackageTypeId",
                table: "CarePackage",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaim_ClaimCollectorId",
                table: "CarePackageReclaim",
                column: "ClaimCollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaim_StatusId",
                table: "CarePackageReclaim",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaim_CarePackageId_PackageTypeId",
                table: "CarePackageReclaim",
                columns: new[] { "CarePackageId", "PackageTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageDetail_CarePackageId_PackageTypeId",
                table: "CarePackageDetail",
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

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackage_AspNetUsers_CreatorId",
                table: "CarePackage",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackage_PackageType_PackageTypeId",
                table: "CarePackage",
                column: "PackageTypeId",
                principalTable: "PackageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackage_Clients_ServiceUserId",
                table: "CarePackage",
                column: "ServiceUserId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackage_PackageStages_StageId",
                table: "CarePackage",
                column: "StageId",
                principalTable: "PackageStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackage_PackageStatuses_StatusId",
                table: "CarePackage",
                column: "StatusId",
                principalTable: "PackageStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackage_Suppliers_SupplierId",
                table: "CarePackage",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackage_AspNetUsers_UpdaterId",
                table: "CarePackage",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageDetail_AspNetUsers_CreatorId",
                table: "CarePackageDetail",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageDetail_AspNetUsers_UpdaterId",
                table: "CarePackageDetail",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageDetail_CarePackage_CarePackageId_PackageTypeId",
                table: "CarePackageDetail",
                columns: new[] { "CarePackageId", "PackageTypeId" },
                principalTable: "CarePackage",
                principalColumns: new[] { "Id", "PackageTypeId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaim_PackageCostClaimers_ClaimCollectorId",
                table: "CarePackageReclaim",
                column: "ClaimCollectorId",
                principalTable: "PackageCostClaimers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaim_AspNetUsers_CreatorId",
                table: "CarePackageReclaim",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaim_ReclaimStatus_StatusId",
                table: "CarePackageReclaim",
                column: "StatusId",
                principalTable: "ReclaimStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaim_Suppliers_SupplierId",
                table: "CarePackageReclaim",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaim_AspNetUsers_UpdaterId",
                table: "CarePackageReclaim",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackageReclaim_CarePackage_CarePackageId_PackageTypeId",
                table: "CarePackageReclaim",
                columns: new[] { "CarePackageId", "PackageTypeId" },
                principalTable: "CarePackage",
                principalColumns: new[] { "Id", "PackageTypeId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackageSettings_CarePackage_CarePackageId_Packag~",
                table: "NursingCarePackageSettings",
                columns: new[] { "CarePackageId", "PackageTypeId" },
                principalTable: "CarePackage",
                principalColumns: new[] { "Id", "PackageTypeId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackageSettings_CarePackage_CarePackageId_Pa~",
                table: "ResidentialCarePackageSettings",
                columns: new[] { "CarePackageId", "PackageTypeId" },
                principalTable: "CarePackage",
                principalColumns: new[] { "Id", "PackageTypeId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
