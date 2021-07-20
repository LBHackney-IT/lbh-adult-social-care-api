using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class DayCarePackageUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorRole",
                table: "ResidentialCareApprovalHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogSubText",
                table: "ResidentialCareApprovalHistories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ResidentialCareApprovalHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorRole",
                table: "NursingCareApprovalHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogSubText",
                table: "NursingCareApprovalHistories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "NursingCareApprovalHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorRole",
                table: "HomeCareApprovalHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogSubText",
                table: "HomeCareApprovalHistories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "HomeCareApprovalHistories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimarySupportReasonId",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EscortPackages",
                columns: table => new
                {
                    EscortPackageId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    DayCarePackageId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    EscortHoursPerWeek = table.Column<int>(nullable: true),
                    EscortCostPerHour = table.Column<decimal>(nullable: true),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    Destination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscortPackages", x => x.EscortPackageId);
                    table.ForeignKey(
                        name: "FK_EscortPackages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EscortPackages_DayCarePackages_DayCarePackageId",
                        column: x => x.DayCarePackageId,
                        principalTable: "DayCarePackages",
                        principalColumn: "DayCarePackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EscortPackages_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrimarySupportReasons",
                columns: table => new
                {
                    PrimarySupportReasonId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrimarySupportReasonName = table.Column<string>(nullable: true),
                    CederBudgetCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimarySupportReasons", x => x.PrimarySupportReasonId);
                });

            migrationBuilder.CreateTable(
                name: "TransportEscortPackages",
                columns: table => new
                {
                    TransportEscortPackageId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    DayCarePackageId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    TransportEscortHoursPerWeek = table.Column<int>(nullable: true),
                    TransportEscortCostPerWeek = table.Column<decimal>(nullable: true),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    Destination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportEscortPackages", x => x.TransportEscortPackageId);
                    table.ForeignKey(
                        name: "FK_TransportEscortPackages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportEscortPackages_DayCarePackages_DayCarePackageId",
                        column: x => x.DayCarePackageId,
                        principalTable: "DayCarePackages",
                        principalColumn: "DayCarePackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportEscortPackages_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportPackages",
                columns: table => new
                {
                    TransportPackageId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    DayCarePackageId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    TransportDaysPerWeek = table.Column<int>(nullable: true),
                    TransportCostPerDay = table.Column<decimal>(nullable: true),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    Destination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportPackages", x => x.TransportPackageId);
                    table.ForeignKey(
                        name: "FK_TransportPackages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportPackages_DayCarePackages_DayCarePackageId",
                        column: x => x.DayCarePackageId,
                        principalTable: "DayCarePackages",
                        principalColumn: "DayCarePackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportPackages_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PrimarySupportReasons",
                columns: new[] { "PrimarySupportReasonId", "CederBudgetCode", "PrimarySupportReasonName" },
                values: new object[,]
                {
                    { 1, "Ceder Budget Code 1", "Primary Support Reason 1" },
                    { 2, "Ceder Budget Code 2", "Primary Support Reason 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageReclaims_ResidentialCarePackageId",
                table: "ResidentialCarePackageReclaims",
                column: "ResidentialCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareApprovalHistories_ResidentialCarePackageId",
                table: "ResidentialCareApprovalHistories",
                column: "ResidentialCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareApprovalHistories_UserId",
                table: "ResidentialCareApprovalHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageReclaims_NursingCarePackageId",
                table: "NursingCarePackageReclaims",
                column: "NursingCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareApprovalHistories_NursingCarePackageId",
                table: "NursingCareApprovalHistories",
                column: "NursingCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareApprovalHistories_UserId",
                table: "NursingCareApprovalHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageReclaims_HomeCarePackageId",
                table: "HomeCarePackageReclaims",
                column: "HomeCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareApprovalHistories_HomeCarePackageId",
                table: "HomeCareApprovalHistories",
                column: "HomeCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareApprovalHistories_UserId",
                table: "HomeCareApprovalHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageReclaims_DayCarePackageId",
                table: "DayCarePackageReclaims",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PrimarySupportReasonId",
                table: "Clients",
                column: "PrimarySupportReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_EscortPackages_ClientId",
                table: "EscortPackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_EscortPackages_DayCarePackageId",
                table: "EscortPackages",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_EscortPackages_SupplierId",
                table: "EscortPackages",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEscortPackages_ClientId",
                table: "TransportEscortPackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEscortPackages_DayCarePackageId",
                table: "TransportEscortPackages",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEscortPackages_SupplierId",
                table: "TransportEscortPackages",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportPackages_ClientId",
                table: "TransportPackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportPackages_DayCarePackageId",
                table: "TransportPackages",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportPackages_SupplierId",
                table: "TransportPackages",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_PrimarySupportReasons_PrimarySupportReasonId",
                table: "Clients",
                column: "PrimarySupportReasonId",
                principalTable: "PrimarySupportReasons",
                principalColumn: "PrimarySupportReasonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackageReclaims_DayCarePackages_DayCarePackageId",
                table: "DayCarePackageReclaims",
                column: "DayCarePackageId",
                principalTable: "DayCarePackages",
                principalColumn: "DayCarePackageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCareApprovalHistories_HomeCarePackage_HomeCarePackageId",
                table: "HomeCareApprovalHistories",
                column: "HomeCarePackageId",
                principalTable: "HomeCarePackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCareApprovalHistories_Users_UserId",
                table: "HomeCareApprovalHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackageReclaims_HomeCarePackage_HomeCarePackageId",
                table: "HomeCarePackageReclaims",
                column: "HomeCarePackageId",
                principalTable: "HomeCarePackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareApprovalHistories_NursingCarePackages_NursingCar~",
                table: "NursingCareApprovalHistories",
                column: "NursingCarePackageId",
                principalTable: "NursingCarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareApprovalHistories_Users_UserId",
                table: "NursingCareApprovalHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackageReclaims_NursingCarePackages_NursingCareP~",
                table: "NursingCarePackageReclaims",
                column: "NursingCarePackageId",
                principalTable: "NursingCarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareApprovalHistories_ResidentialCarePackages_Re~",
                table: "ResidentialCareApprovalHistories",
                column: "ResidentialCarePackageId",
                principalTable: "ResidentialCarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareApprovalHistories_Users_UserId",
                table: "ResidentialCareApprovalHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackageReclaims_ResidentialCarePackages_Resi~",
                table: "ResidentialCarePackageReclaims",
                column: "ResidentialCarePackageId",
                principalTable: "ResidentialCarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_PrimarySupportReasons_PrimarySupportReasonId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackageReclaims_DayCarePackages_DayCarePackageId",
                table: "DayCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareApprovalHistories_HomeCarePackage_HomeCarePackageId",
                table: "HomeCareApprovalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareApprovalHistories_Users_UserId",
                table: "HomeCareApprovalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackageReclaims_HomeCarePackage_HomeCarePackageId",
                table: "HomeCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareApprovalHistories_NursingCarePackages_NursingCar~",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareApprovalHistories_Users_UserId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackageReclaims_NursingCarePackages_NursingCareP~",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareApprovalHistories_ResidentialCarePackages_Re~",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareApprovalHistories_Users_UserId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackageReclaims_ResidentialCarePackages_Resi~",
                table: "ResidentialCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "EscortPackages");

            migrationBuilder.DropTable(
                name: "PrimarySupportReasons");

            migrationBuilder.DropTable(
                name: "TransportEscortPackages");

            migrationBuilder.DropTable(
                name: "TransportPackages");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCarePackageReclaims_ResidentialCarePackageId",
                table: "ResidentialCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareApprovalHistories_ResidentialCarePackageId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareApprovalHistories_UserId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_NursingCarePackageReclaims_NursingCarePackageId",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareApprovalHistories_NursingCarePackageId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareApprovalHistories_UserId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackageReclaims_HomeCarePackageId",
                table: "HomeCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_HomeCareApprovalHistories_HomeCarePackageId",
                table: "HomeCareApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_HomeCareApprovalHistories_UserId",
                table: "HomeCareApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_DayCarePackageReclaims_DayCarePackageId",
                table: "DayCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_Clients_PrimarySupportReasonId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatorRole",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "LogSubText",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "CreatorRole",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "LogSubText",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "CreatorRole",
                table: "HomeCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "LogSubText",
                table: "HomeCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "HomeCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "PrimarySupportReasonId",
                table: "Clients");
        }
    }
}
