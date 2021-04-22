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
                name: "OpportunityLengthOptions",
                columns: table => new
                {
                    OpportunityLengthOptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(nullable: true),
                    TimeInMinutes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityLengthOptions", x => x.OpportunityLengthOptionId);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityTimesPerMonthOptions",
                columns: table => new
                {
                    OpportunityTimePerMonthOptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityTimesPerMonthOptions", x => x.OpportunityTimePerMonthOptionId);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    PackageType = table.Column<string>(nullable: true),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "PackageStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
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
                name: "TypesOfNursingCareHomes",
                columns: table => new
                {
                    TypeOfCareHomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfCareHomeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfNursingCareHome", x => x.TypeOfCareHomeId);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfResidentialCareHomes",
                columns: table => new
                {
                    TypeOfCareHomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfCareHomeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfResidentialCareHome", x => x.TypeOfCareHomeId);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackageCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    HomeCarePackageId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    PrimaryCarer = table.Column<string>(nullable: true),
                    SecondaryCarer = table.Column<int>(nullable: false),
                    CostPerHour = table.Column<decimal>(nullable: false),
                    HoursPerWeek = table.Column<int>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarePackageCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageCosts_HomeCareServiceTypes_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "HomeCareServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    RoleId = table.Column<int>(nullable: false),
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
                    ClientId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    IsFixedPeriod = table.Column<bool>(nullable: false),
                    IsOngoingPeriod = table.Column<bool>(nullable: false),
                    IsThisAnImmediateService = table.Column<bool>(nullable: false),
                    IsThisuserUnderS117 = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
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
                        principalTable: "PackageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NursingCarePackages",
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
                    TypeOfNursingCareHomeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
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
                        principalTable: "PackageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackage_TypesOfNursingCareHome_TypeOfNursingCareHomeId",
                        column: x => x.TypeOfNursingCareHomeId,
                        principalTable: "TypesOfNursingCareHomes",
                        principalColumn: "TypeOfCareHomeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCarePackages",
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
                    TypeOfResidentialCareHomeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
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
                        principalTable: "PackageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackage_TypesOfResidentialCareHome_TypeOfResidentialCareHomeId",
                        column: x => x.TypeOfResidentialCareHomeId,
                        principalTable: "TypesOfResidentialCareHomes",
                        principalColumn: "TypeOfCareHomeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackageSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HomeCarePackageId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    PrimaryInMinutes = table.Column<int>(nullable: false),
                    SecondaryInMinutes = table.Column<int>(nullable: false),
                    NeedToAddress = table.Column<string>(nullable: true),
                    WhatShouldBeDone = table.Column<string>(nullable: true),
                    TimeSlotShiftId = table.Column<int>(nullable: false),
                    DayId = table.Column<int>(nullable: false)
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
                    PackageId = table.Column<int>(nullable: false),
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
                    StatusId = table.Column<int>(nullable: false)
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
                        principalTable: "PackageStatuses",
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
                        principalTable: "NursingCarePackages",
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
                        principalTable: "ResidentialCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayCarePackageOpportunities",
                columns: table => new
                {
                    DayCarePackageOpportunityId = table.Column<Guid>(nullable: false),
                    OpportunityLengthOptionId = table.Column<int>(nullable: false),
                    OpportunityTimePerMonthOptionId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_DayCarePackageOpportunities_OpportunityLengthOptions_OpportunityLengthOptionId",
                        column: x => x.OpportunityLengthOptionId,
                        principalTable: "OpportunityLengthOptions",
                        principalColumn: "OpportunityLengthOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackageOpportunities_OpportunityTimesPerMonthOptions_OpportunityTimePerMonthOptionId",
                        column: x => x.OpportunityTimePerMonthOptionId,
                        principalTable: "OpportunityTimesPerMonthOptions",
                        principalColumn: "OpportunityTimePerMonthOptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "County", "CreatorId", "DateCreated", "DateOfBirth", "DateUpdated", "FirstName", "HackneyId", "LastName", "MiddleName", "PostCode", "Town", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"), "Queens Town Road", null, null, null, 0, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 504, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 504, DateTimeKind.Unspecified).AddTicks(6820), new TimeSpan(0, 0, 0, 0, 0)), "Furkan", 66666, "Kayar", null, "SW11", "London", 0 });

            migrationBuilder.InsertData(
                table: "HomeCareServiceTypes",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "ServiceName", "UpdaterId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(322), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(1952), new TimeSpan(0, 0, 0, 0, 0)), "Personal Home Care", 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2361), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2394), new TimeSpan(0, 0, 0, 0, 0)), "Domestic Care", 1 },
                    { 3, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2402), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2404), new TimeSpan(0, 0, 0, 0, 0)), "Live-in Care", 1 },
                    { 4, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2406), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, 0, 0, 0, 0)), "Escort Care", 1 },
                    { 5, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2409), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2412), new TimeSpan(0, 0, 0, 0, 0)), "Night Owl", 1 },
                    { 6, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2413), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2415), new TimeSpan(0, 0, 0, 0, 0)), "Waking Nights", 1 },
                    { 7, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2416), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 485, DateTimeKind.Unspecified).AddTicks(2418), new TimeSpan(0, 0, 0, 0, 0)), "Sleeping Nights", 1 }
                });

            migrationBuilder.InsertData(
                table: "OpportunityLengthOptions",
                columns: new[] { "OpportunityLengthOptionId", "OptionName", "TimeInMinutes" },
                values: new object[,]
                {
                    { 3, "1 hour 15 minutes", 75 },
                    { 2, "1 hour", 60 },
                    { 1, "45 minutes", 45 }
                });

            migrationBuilder.InsertData(
                table: "OpportunityTimesPerMonthOptions",
                columns: new[] { "OpportunityTimePerMonthOptionId", "OptionName" },
                values: new object[,]
                {
                    { 3, "Monthly" },
                    { 2, "Weekly" },
                    { 1, "Daily" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "PackageType", "Sequence", "UpdaterId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(7341), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(7349), new TimeSpan(0, 0, 0, 0, 0)), "Home Care Package", 0, 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(8444), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(8450), new TimeSpan(0, 0, 0, 0, 0)), "Residential Care Package", 0, 1 },
                    { 3, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(8481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(8482), new TimeSpan(0, 0, 0, 0, 0)), "Day Care Package", 0, 1 },
                    { 4, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(8483), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(8484), new TimeSpan(0, 0, 0, 0, 0)), "Nursing Care Package", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "IsDefault", "RoleName", "Sequence", "UpdaterId" },
                values: new object[,]
                {
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 503, DateTimeKind.Unspecified).AddTicks(2268), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 503, DateTimeKind.Unspecified).AddTicks(2273), new TimeSpan(0, 0, 0, 0, 0)), false, "Broker", 2, 1 },
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 503, DateTimeKind.Unspecified).AddTicks(833), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 503, DateTimeKind.Unspecified).AddTicks(840), new TimeSpan(0, 0, 0, 0, 0)), true, "Social Worker", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "PackageStatuses",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "StatusName", "UpdaterId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(3490), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(3518), new TimeSpan(0, 0, 0, 0, 0)), "New", 1 },
                    { 7, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4708), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4709), new TimeSpan(0, 0, 0, 0, 0)), "Contracted", 1 },
                    { 6, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4705), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4706), new TimeSpan(0, 0, 0, 0, 0)), "Commercially Approved", 1 },
                    { 5, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4703), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4704), new TimeSpan(0, 0, 0, 0, 0)), "Supplier Sourced", 1 },
                    { 4, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4701), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4702), new TimeSpan(0, 0, 0, 0, 0)), "Brokering", 1 },
                    { 3, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4697), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 0, 0, 0, 0)), "Approved For Brokerage", 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 502, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 0, 0, 0, 0)), "Package Confirmation", 1 }
                });

            migrationBuilder.InsertData(
                table: "TermTimeConsiderationOptions",
                columns: new[] { "OptionId", "OptionName" },
                values: new object[,]
                {
                    { 1, "N/A" },
                    { 3, "Holiday" },
                    { 2, "Term Time" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlotShifts",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "LinkedToHomeCareServiceTypeId", "TimeSlotShiftName", "TimeSlotTimeLabel", "UpdaterId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(4918), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(4949), new TimeSpan(0, 0, 0, 0, 0)), null, "Morning", "08:00 - 10:00", 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6263), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6268), new TimeSpan(0, 0, 0, 0, 0)), null, "Mid Morning", "10:00 - 12:00", 1 },
                    { 3, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6306), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6307), new TimeSpan(0, 0, 0, 0, 0)), null, "Lunch", "12:00 - 14:00", 1 },
                    { 4, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6308), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6309), new TimeSpan(0, 0, 0, 0, 0)), null, "Afternoon", "14:00 - 17:00", 1 },
                    { 5, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6311), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6312), new TimeSpan(0, 0, 0, 0, 0)), null, "Evening", "17:00 - 20:00", 1 },
                    { 6, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6313), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6315), new TimeSpan(0, 0, 0, 0, 0)), null, "Night", "20:00 - 22:00", 1 }
                });

            migrationBuilder.InsertData(
                table: "TypesOfNursingCareHomes",
                columns: new[] { "TypeOfCareHomeId", "TypeOfCareHomeName" },
                values: new object[,]
                {
                    { 2, "Nursing Care Type Two" },
                    { 1, "Nursing Care Type One" }
                });

            migrationBuilder.InsertData(
                table: "TypesOfResidentialCareHomes",
                columns: new[] { "TypeOfCareHomeId", "TypeOfCareHomeName" },
                values: new object[,]
                {
                    { 1, "Residential Care Type One" },
                    { 2, "Residential Care Type Two" }
                });

            migrationBuilder.InsertData(
                table: "HomeCareServiceTypeMinutes",
                columns: new[] { "Id", "HomeCareServiceTypeId", "IsSecondaryCarer", "Label", "Minutes" },
                values: new object[,]
                {
                    { 1, 1, false, "30 minutes", 30 },
                    { 22, 2, false, "2 hours", 120 },
                    { 23, 3, false, "30 minutes", 30 },
                    { 24, 3, false, "45 minutes", 45 },
                    { 25, 3, false, "1 hour", 60 },
                    { 26, 3, false, "1 hour 15 minutes", 75 },
                    { 27, 3, false, "1 hour 30 minutes", 90 },
                    { 28, 3, false, "1 hour 45 minutes", 105 },
                    { 29, 3, false, "2 hours", 120 },
                    { 30, 4, false, "30 minutes", 30 },
                    { 31, 4, false, "45 minutes", 45 },
                    { 32, 4, false, "1 hour", 60 },
                    { 33, 4, false, "1 hour 15 minutes", 75 },
                    { 34, 4, false, "1 hour 30 minutes", 90 },
                    { 35, 4, false, "1 hour 45 minutes", 105 },
                    { 36, 4, false, "2 hours", 120 },
                    { 20, 2, false, "1 hour 30 minutes", 90 },
                    { 19, 2, false, "1 hour 15 minutes", 75 },
                    { 21, 2, false, "1 hour 45 minutes", 105 },
                    { 17, 2, false, "45 minutes", 45 },
                    { 2, 1, false, "45 minutes", 45 },
                    { 3, 1, false, "1 hour", 60 },
                    { 4, 1, false, "1 hour 15 minutes", 75 },
                    { 5, 1, false, "1 hour 30 minutes", 90 },
                    { 6, 1, false, "1 hour 45 minutes", 105 },
                    { 7, 1, false, "2 hours", 120 },
                    { 18, 2, false, "1 hour", 60 },
                    { 9, 1, true, "30 minutes", 30 },
                    { 8, 1, true, "N/A", 0 },
                    { 11, 1, true, "1 hour", 60 },
                    { 12, 1, true, "1 hour 15 minutes", 75 },
                    { 13, 1, true, "1 hour 30 minutes", 90 },
                    { 14, 1, true, "1 hour 45 minutes", 105 },
                    { 15, 1, true, "2 hours", 120 },
                    { 16, 2, false, "30 minutes", 30 },
                    { 10, 1, true, "45 minutes", 45 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlotShifts",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "LinkedToHomeCareServiceTypeId", "TimeSlotShiftName", "TimeSlotTimeLabel", "UpdaterId" },
                values: new object[,]
                {
                    { 7, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6316), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6317), new TimeSpan(0, 0, 0, 0, 0)), 5, "Night Owl", null, 1 },
                    { 8, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6623), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6628), new TimeSpan(0, 0, 0, 0, 0)), 6, "Waking Nights", null, 1 },
                    { 9, 1, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6642), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 491, DateTimeKind.Unspecified).AddTicks(6643), new TimeSpan(0, 0, 0, 0, 0)), 7, "Sleeping Nights", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "County", "CreatorId", "DateCreated", "DateUpdated", "FirstName", "HackneyId", "LastName", "MiddleName", "PostCode", "RoleId", "Town", "UpdaterId" },
                values: new object[,]
                {
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), "Queens Gate", null, null, null, 0, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 504, DateTimeKind.Unspecified).AddTicks(791), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 504, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 0, 0, 0, 0)), "Furkan", 1111, "Kayar", null, "W11", 1, "London", 0 },
                    { new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"), "Nairobi", null, null, null, 0, new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 504, DateTimeKind.Unspecified).AddTicks(3044), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 20, 16, 4, 12, 504, DateTimeKind.Unspecified).AddTicks(3050), new TimeSpan(0, 0, 0, 0, 0)), "Duncan", 4444, "Okeno", null, "W11", 2, "Nairobi", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageOpportunities_DayCarePackageId",
                table: "DayCarePackageOpportunities",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageOpportunities_OpportunityLengthOptionId",
                table: "DayCarePackageOpportunities",
                column: "OpportunityLengthOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageOpportunities_OpportunityTimePerMonthOptionId",
                table: "DayCarePackageOpportunities",
                column: "OpportunityTimePerMonthOptionId");

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
                name: "IX_HomeCarePackageCosts_ServiceId",
                table: "HomeCarePackageCosts",
                column: "ServiceId");

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
                table: "NursingCarePackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackage_StatusId",
                table: "NursingCarePackages",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackage_TypeOfNursingCareHomeId",
                table: "NursingCarePackages",
                column: "TypeOfNursingCareHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityLengthOptions_OptionName",
                table: "OpportunityLengthOptions",
                column: "OptionName",
                unique: true,
                filter: "[OptionName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityTimesPerMonthOptions_OptionName",
                table: "OpportunityTimesPerMonthOptions",
                column: "OptionName",
                unique: true,
                filter: "[OptionName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeeds_ResidentialCarePackageId",
                table: "ResidentialCareAdditionalNeeds",
                column: "ResidentialCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackage_ClientId",
                table: "ResidentialCarePackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackage_StatusId",
                table: "ResidentialCarePackages",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackage_TypeOfResidentialCareHomeId",
                table: "ResidentialCarePackages",
                column: "TypeOfResidentialCareHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_TermTimeConsiderationOptions_OptionName",
                table: "TermTimeConsiderationOptions",
                column: "OptionName",
                unique: true,
                filter: "[OptionName] IS NOT NULL");

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
                name: "DayCarePackages");

            migrationBuilder.DropTable(
                name: "OpportunityLengthOptions");

            migrationBuilder.DropTable(
                name: "OpportunityTimesPerMonthOptions");

            migrationBuilder.DropTable(
                name: "TimeSlotShifts");

            migrationBuilder.DropTable(
                name: "NursingCarePackages");

            migrationBuilder.DropTable(
                name: "ResidentialCarePackages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "TermTimeConsiderationOptions");

            migrationBuilder.DropTable(
                name: "HomeCareServiceTypes");

            migrationBuilder.DropTable(
                name: "TypesOfNursingCareHomes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "PackageStatuses");

            migrationBuilder.DropTable(
                name: "TypesOfResidentialCareHomes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
