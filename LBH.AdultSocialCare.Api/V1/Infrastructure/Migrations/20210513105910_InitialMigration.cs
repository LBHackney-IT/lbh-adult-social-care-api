using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarerTypes",
                columns: table => new
                {
                    CarerTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarerTypeMinutes = table.Column<int>(nullable: false),
                    CarerTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarerTypes", x => x.CarerTypeId);
                });

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
                name: "DayCareRequestMoreInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DayCarePackageId = table.Column<Guid>(nullable: false),
                    InformationText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCareRequestMoreInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareApprovalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeCarePackageId = table.Column<Guid>(nullable: false),
                    ApprovedDate = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    LogText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareApprovalHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareRequestMoreInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeCarePackageId = table.Column<Guid>(nullable: false),
                    InformationText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareRequestMoreInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "NursingCareApprovalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NursingCarePackageId = table.Column<Guid>(nullable: false),
                    ApprovedDate = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    LogText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareApprovalHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NursingCareRequestMoreInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NursingCarePackageId = table.Column<Guid>(nullable: false),
                    InformationText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareRequestMoreInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NursingCareTypeOfStayOptions",
                columns: table => new
                {
                    TypeOfStayOptionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(nullable: true),
                    OptionPeriod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareTypeOfStayOptions", x => x.TypeOfStayOptionId);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityLengthOptions",
                columns: table => new
                {
                    OpportunityLengthOptionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "ResidentialCareApprovalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResidentialCarePackageId = table.Column<Guid>(nullable: false),
                    ApprovedDate = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    LogText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareApprovalHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareRequestMoreInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResidentialCarePackageId = table.Column<Guid>(nullable: false),
                    InformationText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareRequestMoreInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareTypeOfStayOptions",
                columns: table => new
                {
                    TypeOfStayOptionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(nullable: true),
                    OptionPeriod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareTypeOfStayOptions", x => x.TypeOfStayOptionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "TermTimeConsiderationOptions",
                columns: table => new
                {
                    OptionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeOfCareHomeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfNursingCareHomes", x => x.TypeOfCareHomeId);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfResidentialCareHomes",
                columns: table => new
                {
                    TypeOfCareHomeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeOfCareHomeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfResidentialCareHomes", x => x.TypeOfCareHomeId);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackageCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    HomeCarePackageId = table.Column<Guid>(nullable: false),
                    HomeCareServiceTypeId = table.Column<int>(nullable: false),
                    CarerTypeId = table.Column<int>(nullable: true),
                    IsSecondaryCarer = table.Column<bool>(nullable: false),
                    CostPerHour = table.Column<decimal>(nullable: false),
                    HoursPerWeek = table.Column<double>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarePackageCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageCosts_CarerTypes_CarerTypeId",
                        column: x => x.CarerTypeId,
                        principalTable: "CarerTypes",
                        principalColumn: "CarerTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageCosts_HomeCareServiceTypes_HomeCareServiceTy~",
                        column: x => x.HomeCareServiceTypeId,
                        principalTable: "HomeCareServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareServiceTypeMinutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(nullable: true),
                    Minutes = table.Column<int>(nullable: false),
                    IsSecondaryCarer = table.Column<bool>(nullable: false),
                    HomeCareServiceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareServiceTypeMinutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCareServiceTypeMinutes_HomeCareServiceTypes_HomeCareSer~",
                        column: x => x.HomeCareServiceTypeId,
                        principalTable: "HomeCareServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareSupplierCosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierId = table.Column<int>(nullable: false),
                    HomeCareServiceTypeId = table.Column<int>(nullable: false),
                    CarerTypeId = table.Column<int>(nullable: true),
                    IsSecondaryCarer = table.Column<bool>(nullable: false),
                    CostPerHour = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareSupplierCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCareSupplierCosts_CarerTypes_CarerTypeId",
                        column: x => x.CarerTypeId,
                        principalTable: "CarerTypes",
                        principalColumn: "CarerTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeCareSupplierCosts_HomeCareServiceTypes_HomeCareServiceT~",
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        name: "FK_TimeSlotShifts_HomeCareServiceTypes_LinkedToHomeCareService~",
                        column: x => x.LinkedToHomeCareServiceTypeId,
                        principalTable: "HomeCareServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    PackageTypeId = table.Column<int>(nullable: false),
                    IsSupplierInternal = table.Column<bool>(nullable: false),
                    HasSupplierFrameworkContractedRates = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Packages_PackageTypeId",
                        column: x => x.PackageTypeId,
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
                name: "DayCareColleges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CollegeName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCareColleges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayCareColleges_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCareColleges_Users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayCarePackageStatuses",
                columns: table => new
                {
                    PackageStatusId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    StatusName = table.Column<string>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    SequenceNumber = table.Column<int>(nullable: false),
                    IsDayCareStatus = table.Column<bool>(nullable: false),
                    IsStatusActive = table.Column<bool>(nullable: false),
                    Stage = table.Column<string>(nullable: true),
                    PackageAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCarePackageStatuses", x => x.PackageStatusId);
                    table.ForeignKey(
                        name: "FK_DayCarePackageStatuses_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackageStatuses_Users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareStages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StageName = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCareStages_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCareStages_Users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageStatuses_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageStatuses_Users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    TransportEscortNeeded = table.Column<bool>(nullable: false),
                    TermTimeConsiderationOptionId = table.Column<int>(nullable: false),
                    CollegeId = table.Column<int>(nullable: true),
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
                        name: "FK_DayCarePackages_DayCarePackageStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DayCarePackageStatuses",
                        principalColumn: "PackageStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_TermTimeConsiderationOptions_TermTimeConsid~",
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
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    StageId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
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
                        name: "FK_HomeCarePackage_HomeCareStages_StageId",
                        column: x => x.StageId,
                        principalTable: "HomeCareStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeCarePackage_PackageStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PackageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeCarePackage_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NursingCarePackages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: true),
                    IsFixedPeriod = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    HasRespiteCare = table.Column<bool>(nullable: false),
                    HasDischargePackage = table.Column<bool>(nullable: false),
                    IsThisAnImmediateService = table.Column<bool>(nullable: false),
                    IsThisUserUnderS117 = table.Column<bool>(nullable: false),
                    TypeOfStayId = table.Column<int>(nullable: true),
                    NeedToAddress = table.Column<string>(nullable: true),
                    TypeOfNursingCareHomeId = table.Column<int>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCarePackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_PackageStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PackageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_TypesOfNursingCareHomes_TypeOfNursingCa~",
                        column: x => x.TypeOfNursingCareHomeId,
                        principalTable: "TypesOfNursingCareHomes",
                        principalColumn: "TypeOfCareHomeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_NursingCareTypeOfStayOptions_TypeOfStay~",
                        column: x => x.TypeOfStayId,
                        principalTable: "NursingCareTypeOfStayOptions",
                        principalColumn: "TypeOfStayOptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_Users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCarePackages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: true),
                    IsFixedPeriod = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    HasRespiteCare = table.Column<bool>(nullable: false),
                    HasDischargePackage = table.Column<bool>(nullable: false),
                    IsThisAnImmediateService = table.Column<bool>(nullable: false),
                    IsThisUserUnderS117 = table.Column<bool>(nullable: false),
                    TypeOfStayId = table.Column<int>(nullable: true),
                    NeedToAddress = table.Column<string>(nullable: true),
                    TypeOfResidentialCareHomeId = table.Column<int>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCarePackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_PackageStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PackageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_TypesOfResidentialCareHomes_TypeOfR~",
                        column: x => x.TypeOfResidentialCareHomeId,
                        principalTable: "TypesOfResidentialCareHomes",
                        principalColumn: "TypeOfCareHomeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_ResidentialCareTypeOfStayOptions_Ty~",
                        column: x => x.TypeOfStayId,
                        principalTable: "ResidentialCareTypeOfStayOptions",
                        principalColumn: "TypeOfStayOptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_Users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayCareApprovalHistory",
                columns: table => new
                {
                    HistoryId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    DayCarePackageId = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    PackageStatusId = table.Column<int>(nullable: false),
                    LogText = table.Column<string>(nullable: false),
                    LogSubText = table.Column<string>(nullable: true),
                    CreatorRole = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCareApprovalHistory", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_DayCareApprovalHistory_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCareApprovalHistory_DayCarePackages_DayCarePackageId",
                        column: x => x.DayCarePackageId,
                        principalTable: "DayCarePackages",
                        principalColumn: "DayCarePackageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayCareApprovalHistory_DayCarePackageStatuses_PackageStatus~",
                        column: x => x.PackageStatusId,
                        principalTable: "DayCarePackageStatuses",
                        principalColumn: "PackageStatusId",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_DayCarePackageOpportunities_OpportunityLengthOptions_Opport~",
                        column: x => x.OpportunityLengthOptionId,
                        principalTable: "OpportunityLengthOptions",
                        principalColumn: "OpportunityLengthOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackageOpportunities_OpportunityTimesPerMonthOptions~",
                        column: x => x.OpportunityTimePerMonthOptionId,
                        principalTable: "OpportunityTimesPerMonthOptions",
                        principalColumn: "OpportunityTimePerMonthOptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NursingCareAdditionalNeeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    NursingCarePackageId = table.Column<Guid>(nullable: false),
                    IsWeeklyCost = table.Column<bool>(nullable: false),
                    IsOneOffCost = table.Column<bool>(nullable: false),
                    NeedToAddress = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareAdditionalNeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeeds_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeeds_NursingCarePackages_NursingCareP~",
                        column: x => x.NursingCarePackageId,
                        principalTable: "NursingCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeeds_Users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareAdditionalNeeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    ResidentialCarePackageId = table.Column<Guid>(nullable: false),
                    IsWeeklyCost = table.Column<bool>(nullable: false),
                    IsOneOffCost = table.Column<bool>(nullable: false),
                    NeedToAddress = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareAdditionalNeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeeds_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeeds_ResidentialCarePackages_Resi~",
                        column: x => x.ResidentialCarePackageId,
                        principalTable: "ResidentialCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeeds_Users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CarerTypes",
                columns: new[] { "CarerTypeId", "CarerTypeMinutes", "CarerTypeName" },
                values: new object[,]
                {
                    { 1, 30, "30m Call" },
                    { 3, 60, "60m+ Call" },
                    { 2, 45, "45m Call" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "County", "CreatorId", "DateCreated", "DateOfBirth", "DateUpdated", "FirstName", "HackneyId", "LastName", "MiddleName", "PostCode", "Town", "UpdatorId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"), "Queens Town Road", null, null, null, 0, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(6805), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 0, 0, 0, 0)), "Furkan", 66666, "Kayar", null, "SW11", "London", 0 });

            migrationBuilder.InsertData(
                table: "HomeCareServiceTypes",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "ServiceName", "UpdatorId" },
                values: new object[,]
                {
                    { 4, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1865), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1867), new TimeSpan(0, 0, 0, 0, 0)), "Escort Care", 1 },
                    { 3, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1861), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1863), new TimeSpan(0, 0, 0, 0, 0)), "Live-in Care", 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1821), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, 0, 0, 0, 0)), "Domestic Care", 1 },
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(17), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 0, 0, 0, 0)), "Personal Home Care", 1 },
                    { 6, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1873), new TimeSpan(0, 0, 0, 0, 0)), "Waking Nights", 1 },
                    { 5, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1868), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 0, 0, 0, 0)), "Night Owl", 1 },
                    { 7, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1875), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1877), new TimeSpan(0, 0, 0, 0, 0)), "Sleeping Nights", 1 }
                });

            migrationBuilder.InsertData(
                table: "NursingCareTypeOfStayOptions",
                columns: new[] { "TypeOfStayOptionId", "OptionName", "OptionPeriod" },
                values: new object[,]
                {
                    { 2, "Temporary", "Expected under 52 weeks" },
                    { 1, "Interim", "Under 6 weeks" },
                    { 3, "Long Term", "52+ weeks" }
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
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "PackageType", "Sequence", "UpdatorId" },
                values: new object[,]
                {
                    { 3, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8745), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8746), new TimeSpan(0, 0, 0, 0, 0)), "Day Care Package", 0, 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8704), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 0, 0, 0, 0)), "Residential Care Package", 0, 1 },
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(7672), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(7680), new TimeSpan(0, 0, 0, 0, 0)), "Home Care Package", 0, 1 },
                    { 4, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8747), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 0, 0, 0, 0)), "Nursing Care Package", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "ResidentialCareTypeOfStayOptions",
                columns: new[] { "TypeOfStayOptionId", "OptionName", "OptionPeriod" },
                values: new object[,]
                {
                    { 1, "Interim", "Under 6 weeks" },
                    { 2, "Temporary", "Expected under 52 weeks" },
                    { 3, "Long Term", "52+ weeks" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "IsDefault", "RoleName", "Sequence", "UpdatorId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 461, DateTimeKind.Unspecified).AddTicks(1039), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 461, DateTimeKind.Unspecified).AddTicks(1045), new TimeSpan(0, 0, 0, 0, 0)), true, "Social Worker", 1, 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 461, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 461, DateTimeKind.Unspecified).AddTicks(2484), new TimeSpan(0, 0, 0, 0, 0)), false, "Broker", 2, 1 }
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
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "LinkedToHomeCareServiceTypeId", "TimeSlotShiftName", "TimeSlotTimeLabel", "UpdatorId" },
                values: new object[,]
                {
                    { 6, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5674), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, 0, 0, 0, 0)), null, "Night", "20:00 - 22:00", 1 },
                    { 5, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 0, 0, 0, 0)), null, "Evening", "17:00 - 20:00", 1 },
                    { 4, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 0, 0, 0, 0)), null, "Afternoon", "14:00 - 17:00", 1 },
                    { 3, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5666), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5667), new TimeSpan(0, 0, 0, 0, 0)), null, "Lunch", "12:00 - 14:00", 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5618), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5625), new TimeSpan(0, 0, 0, 0, 0)), null, "Mid Morning", "10:00 - 12:00", 1 },
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(3990), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(4014), new TimeSpan(0, 0, 0, 0, 0)), null, "Morning", "08:00 - 10:00", 1 }
                });

            migrationBuilder.InsertData(
                table: "TypesOfNursingCareHomes",
                columns: new[] { "TypeOfCareHomeId", "TypeOfCareHomeName" },
                values: new object[,]
                {
                    { 2, "Assisted Home" },
                    { 1, "Nursing Home" }
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
                    { 18, 2, false, "1 hour", 60 },
                    { 8, 1, true, "N/A", 0 },
                    { 9, 1, true, "30 minutes", 30 },
                    { 7, 1, false, "2 hours", 120 },
                    { 11, 1, true, "1 hour", 60 },
                    { 12, 1, true, "1 hour 15 minutes", 75 },
                    { 13, 1, true, "1 hour 30 minutes", 90 },
                    { 14, 1, true, "1 hour 45 minutes", 105 },
                    { 15, 1, true, "2 hours", 120 },
                    { 16, 2, false, "30 minutes", 30 },
                    { 10, 1, true, "45 minutes", 45 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "HasSupplierFrameworkContractedRates", "IsSupplierInternal", "PackageTypeId", "SupplierName", "UpdatorId" },
                values: new object[] { 1, 0, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 463, DateTimeKind.Unspecified).AddTicks(7891), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 463, DateTimeKind.Unspecified).AddTicks(7899), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Furkan", 0 });

            migrationBuilder.InsertData(
                table: "TimeSlotShifts",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "LinkedToHomeCareServiceTypeId", "TimeSlotShiftName", "TimeSlotTimeLabel", "UpdatorId" },
                values: new object[,]
                {
                    { 7, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5676), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5677), new TimeSpan(0, 0, 0, 0, 0)), 5, "Night Owl", null, 1 },
                    { 8, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(6018), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(6022), new TimeSpan(0, 0, 0, 0, 0)), 6, "Waking Nights", null, 1 },
                    { 9, 1, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(6037), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(6038), new TimeSpan(0, 0, 0, 0, 0)), 7, "Sleeping Nights", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "County", "CreatorId", "DateCreated", "DateUpdated", "FirstName", "HackneyId", "LastName", "MiddleName", "PostCode", "RoleId", "Town", "UpdatorId" },
                values: new object[,]
                {
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), "Queens Gate", null, null, null, 0, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(1675), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(1683), new TimeSpan(0, 0, 0, 0, 0)), "Furkan", 1111, "Kayar", null, "W11", 1, "London", 0 },
                    { new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"), "Nairobi", null, null, null, 0, new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(3787), new TimeSpan(0, 0, 0, 0, 0)), "Duncan", 4444, "Okeno", null, "W11", 2, "Nairobi", 0 }
                });

            migrationBuilder.InsertData(
                table: "DayCarePackageStatuses",
                columns: new[] { "PackageStatusId", "CreatorId", "DateCreated", "DateUpdated", "IsDayCareStatus", "IsStatusActive", "PackageAction", "SequenceNumber", "Stage", "StatusName", "UpdaterId" },
                values: new object[,]
                {
                    { 1, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(1168), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(1177), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Created", 1, "PACKAGE BUILDER", "New Package", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 15, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3916), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3917), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Contracted", 9, "CONTRACTION", "Package Contracted", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 14, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3911), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3912), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Request More Information", 8, "BROKERAGE APPROVAL", "Clarifying Commercials", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 13, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3905), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3906), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Rejected", 8, "BROKERAGE APPROVAL", "Package Commercials - Rejected", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 12, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3797), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3798), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Approved", 8, "BROKERAGE APPROVAL", "Commercials Approved", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 11, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3792), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3793), new TimeSpan(0, 0, 0, 0, 0)), true, true, "New", 7, "NEW BROKERAGE APPROVAL", "Brokerage - Submitted for Approval", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 9, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3782), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3783), new TimeSpan(0, 0, 0, 0, 0)), true, true, "SupplierSourced", 6, "PACKAGE BROKERING", "Brokerage - Supplier Sourced", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 10, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3787), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3788), new TimeSpan(0, 0, 0, 0, 0)), true, true, "PricingAgreed", 6, "PACKAGE BROKERING", "Brokerage - Pricing Agreed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 7, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3773), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3774), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Assigned", 5, "NEW BROKERAGE", "Brokerage - Assigned", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 6, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3768), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3769), new TimeSpan(0, 0, 0, 0, 0)), true, true, "New", 4, "NEW BROKERAGE", "Brokerage - New", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 5, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3763), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3764), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Request More Information", 3, "PACKAGE DETAIL APPROVAL", "Clarification Needed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 4, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3758), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3759), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Reject", 3, "PACKAGE DETAIL APPROVAL", "Reject Package", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 3, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3753), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Approve", 3, "PACKAGE DETAIL APPROVAL", "Contents Approved", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 2, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3678), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3683), new TimeSpan(0, 0, 0, 0, 0)), true, true, "New", 2, "NEW PACKAGE DETAIL APPROVAL", "Submitted for Approval", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 8, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3778), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3778), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Querying", 6, "PACKAGE BROKERING", "Brokerage - Querying", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
                });

            migrationBuilder.InsertData(
                table: "HomeCareStages",
                columns: new[] { "Id", "CreatorId", "StageName", "UpdaterId" },
                values: new object[,]
                {
                    { 2, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), "Assigned", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 4, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), "Supplier Sourced", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 3, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), "Querying", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 1, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), "New", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 6, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), "Submitted For Approval", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 5, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), "Pricing agreed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
                });

            migrationBuilder.InsertData(
                table: "PackageStatuses",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "StatusName", "UpdaterId" },
                values: new object[,]
                {
                    { 6, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4966), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4967), new TimeSpan(0, 0, 0, 0, 0)), "Commercially Approved Needed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 7, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4971), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4972), new TimeSpan(0, 0, 0, 0, 0)), "Clarifying Commercials", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 8, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4975), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4976), new TimeSpan(0, 0, 0, 0, 0)), "Commercials Approved", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 9, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4980), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4981), new TimeSpan(0, 0, 0, 0, 0)), "PO Issued", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 10, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4985), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4986), new TimeSpan(0, 0, 0, 0, 0)), "Suspended", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 11, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4990), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4991), new TimeSpan(0, 0, 0, 0, 0)), "Ended", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 4, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4957), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4958), new TimeSpan(0, 0, 0, 0, 0)), "Contents Approved", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 3, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4951), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4952), new TimeSpan(0, 0, 0, 0, 0)), "Clarification Needed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 2, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4892), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4898), new TimeSpan(0, 0, 0, 0, 0)), "For Contents Approval", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 5, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4961), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4962), new TimeSpan(0, 0, 0, 0, 0)), "Brokering", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 1, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(3272), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 0, 0, 0, 0)), "Draft", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayCareApprovalHistory_CreatorId",
                table: "DayCareApprovalHistory",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareApprovalHistory_DayCarePackageId",
                table: "DayCareApprovalHistory",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareApprovalHistory_PackageStatusId",
                table: "DayCareApprovalHistory",
                column: "PackageStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareColleges_CreatorId",
                table: "DayCareColleges",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareColleges_UpdaterId",
                table: "DayCareColleges",
                column: "UpdaterId");

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
                name: "IX_DayCarePackageStatuses_CreatorId",
                table: "DayCarePackageStatuses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageStatuses_UpdaterId",
                table: "DayCarePackageStatuses",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageStatuses_SequenceNumber_Stage_PackageAction",
                table: "DayCarePackageStatuses",
                columns: new[] { "SequenceNumber", "Stage", "PackageAction" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_ClientId",
                table: "HomeCarePackage",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_StageId",
                table: "HomeCarePackage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_StatusId",
                table: "HomeCarePackage",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_SupplierId",
                table: "HomeCarePackage",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_CarerTypeId",
                table: "HomeCarePackageCosts",
                column: "CarerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_HomeCareServiceTypeId",
                table: "HomeCarePackageCosts",
                column: "HomeCareServiceTypeId");

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
                name: "IX_HomeCareStages_CreatorId",
                table: "HomeCareStages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareStages_UpdaterId",
                table: "HomeCareStages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareSupplierCosts_CarerTypeId",
                table: "HomeCareSupplierCosts",
                column: "CarerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareSupplierCosts_HomeCareServiceTypeId",
                table: "HomeCareSupplierCosts",
                column: "HomeCareServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeeds_CreatorId",
                table: "NursingCareAdditionalNeeds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeeds_NursingCarePackageId",
                table: "NursingCareAdditionalNeeds",
                column: "NursingCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeeds_UpdaterId",
                table: "NursingCareAdditionalNeeds",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_ClientId",
                table: "NursingCarePackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_CreatorId",
                table: "NursingCarePackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_StatusId",
                table: "NursingCarePackages",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_TypeOfNursingCareHomeId",
                table: "NursingCarePackages",
                column: "TypeOfNursingCareHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_TypeOfStayId",
                table: "NursingCarePackages",
                column: "TypeOfStayId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_UpdaterId",
                table: "NursingCarePackages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityLengthOptions_OptionName",
                table: "OpportunityLengthOptions",
                column: "OptionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityTimesPerMonthOptions_OptionName",
                table: "OpportunityTimesPerMonthOptions",
                column: "OptionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageStatuses_CreatorId",
                table: "PackageStatuses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageStatuses_UpdaterId",
                table: "PackageStatuses",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeeds_CreatorId",
                table: "ResidentialCareAdditionalNeeds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeeds_ResidentialCarePackageId",
                table: "ResidentialCareAdditionalNeeds",
                column: "ResidentialCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeeds_UpdaterId",
                table: "ResidentialCareAdditionalNeeds",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackages_ClientId",
                table: "ResidentialCarePackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackages_CreatorId",
                table: "ResidentialCarePackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackages_StatusId",
                table: "ResidentialCarePackages",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackages_TypeOfResidentialCareHomeId",
                table: "ResidentialCarePackages",
                column: "TypeOfResidentialCareHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackages_TypeOfStayId",
                table: "ResidentialCarePackages",
                column: "TypeOfStayId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackages_UpdaterId",
                table: "ResidentialCarePackages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PackageTypeId",
                table: "Suppliers",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TermTimeConsiderationOptions_OptionName",
                table: "TermTimeConsiderationOptions",
                column: "OptionName",
                unique: true);

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
                name: "DayCareApprovalHistory");

            migrationBuilder.DropTable(
                name: "DayCareColleges");

            migrationBuilder.DropTable(
                name: "DayCarePackageOpportunities");

            migrationBuilder.DropTable(
                name: "DayCareRequestMoreInformations");

            migrationBuilder.DropTable(
                name: "HomeCareApprovalHistories");

            migrationBuilder.DropTable(
                name: "HomeCarePackage");

            migrationBuilder.DropTable(
                name: "HomeCarePackageCosts");

            migrationBuilder.DropTable(
                name: "HomeCarePackageSlots");

            migrationBuilder.DropTable(
                name: "HomeCareRequestMoreInformations");

            migrationBuilder.DropTable(
                name: "HomeCareServiceTypeMinutes");

            migrationBuilder.DropTable(
                name: "HomeCareSupplierCosts");

            migrationBuilder.DropTable(
                name: "NursingCareAdditionalNeeds");

            migrationBuilder.DropTable(
                name: "NursingCareApprovalHistories");

            migrationBuilder.DropTable(
                name: "NursingCareRequestMoreInformations");

            migrationBuilder.DropTable(
                name: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropTable(
                name: "ResidentialCareApprovalHistories");

            migrationBuilder.DropTable(
                name: "ResidentialCareRequestMoreInformations");

            migrationBuilder.DropTable(
                name: "DayCarePackages");

            migrationBuilder.DropTable(
                name: "OpportunityLengthOptions");

            migrationBuilder.DropTable(
                name: "OpportunityTimesPerMonthOptions");

            migrationBuilder.DropTable(
                name: "HomeCareStages");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "TimeSlotShifts");

            migrationBuilder.DropTable(
                name: "CarerTypes");

            migrationBuilder.DropTable(
                name: "NursingCarePackages");

            migrationBuilder.DropTable(
                name: "ResidentialCarePackages");

            migrationBuilder.DropTable(
                name: "DayCarePackageStatuses");

            migrationBuilder.DropTable(
                name: "TermTimeConsiderationOptions");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "HomeCareServiceTypes");

            migrationBuilder.DropTable(
                name: "TypesOfNursingCareHomes");

            migrationBuilder.DropTable(
                name: "NursingCareTypeOfStayOptions");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "PackageStatuses");

            migrationBuilder.DropTable(
                name: "TypesOfResidentialCareHomes");

            migrationBuilder.DropTable(
                name: "ResidentialCareTypeOfStayOptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
