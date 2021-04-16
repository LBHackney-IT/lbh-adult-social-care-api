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
                name: "HomeCarePackageCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    HomeCarePackageId = table.Column<Guid>(nullable: false),
                    ServiceName = table.Column<string>(nullable: true),
                    CostPerHour = table.Column<decimal>(nullable: false),
                    HoursPerWeek = table.Column<int>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarePackageCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    ServiceName = table.Column<string>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareServiceTypes", x => x.Id);
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
                name: "HomeCareServiceTypeMinutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true),
                    Minutes = table.Column<int>(nullable: false),
                    IsSecondaryCarer = table.Column<bool>(nullable: false),
                    HomeCareServiceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareServiceTypeMinutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCareServiceTypeMinutes_HomeCareServiceTypes_HomeCareServiceTypeId",
                        column: x => x.HomeCareServiceTypeId,
                        principalTable: "HomeCareServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlotShifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    TimeSlotShiftName = table.Column<string>(nullable: false),
                    TimeSlotTimeLabel = table.Column<string>(nullable: true),
                    LinkedToHomeCareServiceTypeId = table.Column<int>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlotShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlotShifts_HomeCareServiceTypes_LinkedToHomeCareServiceTypeId",
                        column: x => x.LinkedToHomeCareServiceTypeId,
                        principalTable: "HomeCareServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    ServiceId = table.Column<int>(nullable: false),
                    PrimaryCarer = table.Column<string>(nullable: true),
                    SecondaryCarer = table.Column<string>(nullable: true),
                    NeedToAddress = table.Column<string>(nullable: true),
                    WhatShouldBeDone = table.Column<string>(nullable: true),
                    TimeSlotShiftId = table.Column<int>(nullable: false),
                    InMinutes = table.Column<int>(nullable: false),
                    DayOfTheWeekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarePackageSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageSlots_HomeCareServiceTypes_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "HomeCareServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageSlots_TimeSlotShifts_TimeSlotShiftId",
                        column: x => x.TimeSlotShiftId,
                        principalTable: "TimeSlotShifts",
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
                name: "NursingCareAdditionalNeeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    NursingCarePackageId = table.Column<Guid>(nullable: false),
                    Weekly = table.Column<bool>(nullable: false),
                    OneOff = table.Column<bool>(nullable: false),
                    NeedToAddress = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareAdditionalNeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeeds_NursingCarePackage_NursingCarePackageId",
                        column: x => x.NursingCarePackageId,
                        principalTable: "NursingCarePackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareAdditionalNeeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    ResidentialCarePackageId = table.Column<Guid>(nullable: false),
                    Weekly = table.Column<bool>(nullable: false),
                    OneOff = table.Column<bool>(nullable: false),
                    NeedToAddress = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareAdditionalNeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeeds_ResidentialCarePackage_ResidentialCarePackageId",
                        column: x => x.ResidentialCarePackageId,
                        principalTable: "ResidentialCarePackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "HomeCareServiceTypes",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "ServiceName", "UpdatorId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(2829), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4308), new TimeSpan(0, 0, 0, 0, 0)), "Personal Home Care", 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4605), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4643), new TimeSpan(0, 0, 0, 0, 0)), "Domestic Care", 1 },
                    { 3, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4658), new TimeSpan(0, 0, 0, 0, 0)), "Live-in Care", 1 },
                    { 4, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4659), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4661), new TimeSpan(0, 0, 0, 0, 0)), "Escort Care", 1 },
                    { 5, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4663), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4665), new TimeSpan(0, 0, 0, 0, 0)), "Night Owl", 1 },
                    { 6, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4666), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4668), new TimeSpan(0, 0, 0, 0, 0)), "Waking Nights", 1 },
                    { 7, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4669), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4671), new TimeSpan(0, 0, 0, 0, 0)), "Sleeping Nights", 1 }
                });

            migrationBuilder.InsertData(
                table: "TermTimeConsiderationOptions",
                columns: new[] { "OptionId", "OptionName" },
                values: new object[,]
                {
                    { 1, "N/A" },
                    { 2, "Term Time" },
                    { 3, "Holiday" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlotShifts",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "LinkedToHomeCareServiceTypeId", "TimeSlotShiftName", "TimeSlotTimeLabel", "UpdatorId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(9000), new TimeSpan(0, 0, 0, 0, 0)), null, "Morning", "08:00 - 10:00", 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(293), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(298), new TimeSpan(0, 0, 0, 0, 0)), null, "Mid Morning", "10:00 - 12:00", 1 },
                    { 3, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(342), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(343), new TimeSpan(0, 0, 0, 0, 0)), null, "Lunch", "12:00 - 14:00", 1 },
                    { 4, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(345), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(346), new TimeSpan(0, 0, 0, 0, 0)), null, "Afternoon", "14:00 - 17:00", 1 },
                    { 5, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(348), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(349), new TimeSpan(0, 0, 0, 0, 0)), null, "Evening", "17:00 - 20:00", 1 },
                    { 6, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(350), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(351), new TimeSpan(0, 0, 0, 0, 0)), null, "Night", "20:00 - 22:00", 1 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlotShifts",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "LinkedToHomeCareServiceTypeId", "TimeSlotShiftName", "TimeSlotTimeLabel", "UpdatorId" },
                values: new object[] { 7, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(352), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(353), new TimeSpan(0, 0, 0, 0, 0)), 5, "Night Owl", null, 1 });

            migrationBuilder.InsertData(
                table: "TimeSlotShifts",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "LinkedToHomeCareServiceTypeId", "TimeSlotShiftName", "TimeSlotTimeLabel", "UpdatorId" },
                values: new object[] { 8, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(663), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(667), new TimeSpan(0, 0, 0, 0, 0)), 6, "Waking Nights", null, 1 });

            migrationBuilder.InsertData(
                table: "TimeSlotShifts",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "LinkedToHomeCareServiceTypeId", "TimeSlotShiftName", "TimeSlotTimeLabel", "UpdatorId" },
                values: new object[] { 9, 1, new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(681), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(682), new TimeSpan(0, 0, 0, 0, 0)), 7, "Sleeping Nights", null, 1 });

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
                name: "IX_HomeCareServiceTypeMinutes_HomeCareServiceTypeId",
                table: "HomeCareServiceTypeMinutes",
                column: "HomeCareServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeeds_NursingCarePackageId",
                table: "NursingCareAdditionalNeeds",
                column: "NursingCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackage_ClientId",
                table: "NursingCarePackage",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackage_StatusId",
                table: "NursingCarePackage",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeeds_ResidentialCarePackageId",
                table: "ResidentialCareAdditionalNeeds",
                column: "ResidentialCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackage_ClientId",
                table: "ResidentialCarePackage",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackage_StatusId",
                table: "ResidentialCarePackage",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotShifts_LinkedToHomeCareServiceTypeId",
                table: "TimeSlotShifts",
                column: "LinkedToHomeCareServiceTypeId");

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
                name: "HomeCarePackage");

            migrationBuilder.DropTable(
                name: "HomeCarePackageCosts");

            migrationBuilder.DropTable(
                name: "HomeCarePackageSlots");

            migrationBuilder.DropTable(
                name: "HomeCareServiceTypeMinutes");

            migrationBuilder.DropTable(
                name: "NursingCareAdditionalNeeds");

            migrationBuilder.DropTable(
                name: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropTable(
                name: "TimeSlotType");

            migrationBuilder.DropTable(
                name: "DayCarePackages");

            migrationBuilder.DropTable(
                name: "TimeSlotShifts");

            migrationBuilder.DropTable(
                name: "NursingCarePackage");

            migrationBuilder.DropTable(
                name: "ResidentialCarePackage");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "TermTimeConsiderationOptions");

            migrationBuilder.DropTable(
                name: "HomeCareServiceTypes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
