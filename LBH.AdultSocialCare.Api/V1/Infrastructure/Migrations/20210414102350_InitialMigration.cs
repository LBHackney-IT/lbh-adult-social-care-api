using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    HackneyId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "example_table",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_example_table", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    PackageName = table.Column<string>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    StatusName = table.Column<string>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermTimeConsiderationOptions",
                columns: table => new
                {
                    OptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermTimeConsiderationOptions", x => x.OptionId);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlotShifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    TimeSlotShiftName = table.Column<string>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlotShifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlotType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    TimeSlotTypeName = table.Column<string>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlotType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    PackageId = table.Column<Guid>(nullable: false),
                    ServiceName = table.Column<string>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageServices_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    HackneyId = table.Column<int>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    IsFixedPeriod = table.Column<bool>(nullable: false),
                    IsOngoingPeriod = table.Column<bool>(nullable: false),
                    IsThisAnImmediateService = table.Column<bool>(nullable: false),
                    IsThisuserUnderS117 = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarePackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCarePackage_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCarePackage_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NursingCarePackage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    IsInterim = table.Column<bool>(nullable: false),
                    IsUnder8Weeks = table.Column<bool>(nullable: false),
                    IsUnder52Weeks = table.Column<bool>(nullable: false),
                    IsLongStay = table.Column<bool>(nullable: false),
                    NeedToAddress = table.Column<string>(nullable: true),
                    TypeOfNursingHome = table.Column<string>(nullable: true),
                    Weekly = table.Column<bool>(nullable: false),
                    OneOff = table.Column<bool>(nullable: false),
                    AdditionalNeedToAddress = table.Column<string>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCarePackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NursingCarePackage_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackage_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCarePackage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    IsRespiteCare = table.Column<bool>(nullable: false),
                    IsDischargePackage = table.Column<bool>(nullable: false),
                    IsImmediateReenablementPackage = table.Column<bool>(nullable: false),
                    IsExpectedStayOver52Weeks = table.Column<bool>(nullable: false),
                    IsThisUserUnderS117 = table.Column<bool>(nullable: false),
                    NeedToAddress = table.Column<string>(nullable: true),
                    TypeOfCareHome = table.Column<string>(nullable: true),
                    Weekly = table.Column<bool>(nullable: false),
                    OneOff = table.Column<bool>(nullable: false),
                    AdditionalNeedToAddress = table.Column<string>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCarePackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackage_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackage_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackageSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HomeCarePackageId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false),
                    PrimaryCarer = table.Column<string>(nullable: true),
                    SecondaryCarer = table.Column<string>(nullable: true),
                    NeedToAddress = table.Column<string>(nullable: true),
                    WhatShouldBeDone = table.Column<string>(nullable: true),
                    TimeSlotTypeId = table.Column<Guid>(nullable: false),
                    TimeSlotShiftId = table.Column<Guid>(nullable: false),
                    InMinutes = table.Column<int>(nullable: false),
                    InHours = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarePackageSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageSlots_PackageServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "PackageServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageSlots_TimeSlotShifts_TimeSlotShiftId",
                        column: x => x.TimeSlotShiftId,
                        principalTable: "TimeSlotShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageSlots_TimeSlotType_TimeSlotTypeId",
                        column: x => x.TimeSlotTypeId,
                        principalTable: "TimeSlotType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayCarePackages",
                columns: table => new
                {
                    DayCarePackageId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    PackageId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    IsFixedPeriodOrOngoing = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    IsThisAnImmediateService = table.Column<bool>(nullable: false),
                    IsThisUserUnderS117 = table.Column<bool>(nullable: false),
                    NeedToAddress = table.Column<string>(nullable: true),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    TransportNeeded = table.Column<bool>(nullable: false),
                    EscortNeeded = table.Column<bool>(nullable: false),
                    TermTimeConsiderationOptionId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCarePackages", x => x.DayCarePackageId);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_TermTimeConsiderationOptions_TermTimeConsiderationOptionId",
                        column: x => x.TermTimeConsiderationOptionId,
                        principalTable: "TermTimeConsiderationOptions",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_Users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayCarePackageOpportunities",
                columns: table => new
                {
                    DayCarePackageOpportunityId = table.Column<Guid>(nullable: false),
                    HowLong = table.Column<string>(nullable: true),
                    HowManyTimesPerMonth = table.Column<string>(nullable: true),
                    OpportunitiesNeedToAddress = table.Column<string>(nullable: true),
                    DayCarePackageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCarePackageOpportunities", x => x.DayCarePackageOpportunityId);
                    table.ForeignKey(
                        name: "FK_DayCarePackageOpportunities_DayCarePackages_DayCarePackageId",
                        column: x => x.DayCarePackageId,
                        principalTable: "DayCarePackages",
                        principalColumn: "DayCarePackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TermTimeConsiderationOptions",
                columns: new[] { "OptionId", "OptionName" },
                values: new object[] { 1, "N/A" });

            migrationBuilder.InsertData(
                table: "TermTimeConsiderationOptions",
                columns: new[] { "OptionId", "OptionName" },
                values: new object[] { 2, "Term Time" });

            migrationBuilder.InsertData(
                table: "TermTimeConsiderationOptions",
                columns: new[] { "OptionId", "OptionName" },
                values: new object[] { 3, "Holiday" });

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageOpportunities_DayCarePackageId",
                table: "DayCarePackageOpportunities",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_ClientId",
                table: "DayCarePackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_CreatorId",
                table: "DayCarePackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_PackageId",
                table: "DayCarePackages",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_StatusId",
                table: "DayCarePackages",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_TermTimeConsiderationOptionId",
                table: "DayCarePackages",
                column: "TermTimeConsiderationOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_UpdaterId",
                table: "DayCarePackages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_ClientId",
                table: "HomeCarePackage",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_StatusId",
                table: "HomeCarePackage",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageSlots_ServiceId",
                table: "HomeCarePackageSlots",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageSlots_TimeSlotShiftId",
                table: "HomeCarePackageSlots",
                column: "TimeSlotShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageSlots_TimeSlotTypeId",
                table: "HomeCarePackageSlots",
                column: "TimeSlotTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackage_ClientId",
                table: "NursingCarePackage",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackage_StatusId",
                table: "NursingCarePackage",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageServices_PackageId",
                table: "PackageServices",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackage_ClientId",
                table: "ResidentialCarePackage",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackage_StatusId",
                table: "ResidentialCarePackage",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayCarePackageOpportunities");

            migrationBuilder.DropTable(
                name: "example_table");

            migrationBuilder.DropTable(
                name: "HomeCarePackage");

            migrationBuilder.DropTable(
                name: "HomeCarePackageSlots");

            migrationBuilder.DropTable(
                name: "NursingCarePackage");

            migrationBuilder.DropTable(
                name: "ResidentialCarePackage");

            migrationBuilder.DropTable(
                name: "DayCarePackages");

            migrationBuilder.DropTable(
                name: "PackageServices");

            migrationBuilder.DropTable(
                name: "TimeSlotShifts");

            migrationBuilder.DropTable(
                name: "TimeSlotType");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TermTimeConsiderationOptions");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
