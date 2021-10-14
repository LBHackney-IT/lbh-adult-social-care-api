using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
#pragma warning disable CA1814
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarePackageSchedulingOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    OptionName = table.Column<string>(nullable: true),
                    OptionPeriod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackageSchedulingOptions", x => x.Id);
                    table.CheckConstraint("CK_CarePackageSchedulingOptions_Id", "\"Id\" IN (0, 1, 2, 3)");
                });

            migrationBuilder.CreateTable(
                name: "FundedNursingCarePrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PricePerWeek = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    ActiveFrom = table.Column<DateTimeOffset>(nullable: false),
                    ActiveTo = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundedNursingCarePrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(nullable: true),
                    StatusDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageStatuses", x => x.Id);
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
                name: "ProvisionalCareChargeAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: false),
                    AgeFrom = table.Column<int>(nullable: false),
                    AgeTo = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(13, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvisionalCareChargeAmounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    RoleId1 = table.Column<Guid>(nullable: true),
                    UserId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PackageTypeId = table.Column<int>(nullable: false),
                    IsSupplierInternal = table.Column<bool>(nullable: false),
                    HasSupplierFrameworkContractedRates = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    HackneyId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PreferredContact = table.Column<string>(nullable: true),
                    CanSpeakEnglish = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    PrimarySupportReasonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceUsers_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceUsers_PrimarySupportReasons_PrimarySupportReasonId",
                        column: x => x.PrimarySupportReasonId,
                        principalTable: "PrimarySupportReasons",
                        principalColumn: "PrimarySupportReasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceUsers_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarePackages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    PackageType = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ServiceUserId = table.Column<Guid>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    ApproverId = table.Column<Guid>(nullable: true),
                    BrokerId = table.Column<Guid>(nullable: true),
                    PrimarySupportReasonId = table.Column<int>(nullable: false),
                    PackageScheduling = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackages", x => x.Id);
                    table.CheckConstraint("CK_CarePackages_PackageScheduling", "\"PackageScheduling\" IN (0, 1, 2, 3)");
                    table.CheckConstraint("CK_CarePackages_PackageType", "\"PackageType\" IN (0, 2, 4)");
                    table.CheckConstraint("CK_CarePackages_Status", "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7)");
                    table.ForeignKey(
                        name: "FK_CarePackages_AspNetUsers_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarePackages_AspNetUsers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarePackages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackages_PrimarySupportReasons_PrimarySupportReasonId",
                        column: x => x.PrimarySupportReasonId,
                        principalTable: "PrimarySupportReasons",
                        principalColumn: "PrimarySupportReasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackages_ServiceUsers_ServiceUserId",
                        column: x => x.ServiceUserId,
                        principalTable: "ServiceUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackages_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarePackages_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarePackageDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    CarePackageId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    CostPeriod = table.Column<int>(nullable: false),
                    ServicePeriod = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    UnitOfMeasure = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackageDetails", x => x.Id);
                    table.CheckConstraint("CK_CarePackageDetails_CostPeriod", "\"CostPeriod\" IN (0, 1, 2, 3, 4)");
                    table.CheckConstraint("CK_CarePackageDetails_ServicePeriod", "\"ServicePeriod\" IN (0, 1, 2, 3, 4)");
                    table.CheckConstraint("CK_CarePackageDetails_Type", "\"Type\" IN (0, 1, 2)");
                    table.ForeignKey(
                        name: "FK_CarePackageDetails_CarePackages_CarePackageId",
                        column: x => x.CarePackageId,
                        principalTable: "CarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageDetails_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageDetails_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarePackageHistories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    CarePackageId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RequestMoreInformation = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackageHistories", x => x.Id);
                    table.CheckConstraint("CK_CarePackageHistories_Status", "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)");
                    table.ForeignKey(
                        name: "FK_CarePackageHistories_CarePackages_CarePackageId",
                        column: x => x.CarePackageId,
                        principalTable: "CarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageHistories_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageHistories_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarePackageReclaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    CarePackageId = table.Column<Guid>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    ClaimCollector = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SubType = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ClaimReason = table.Column<string>(nullable: true),
                    AssessmentFileUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackageReclaims", x => x.Id);
                    table.CheckConstraint("CK_CarePackageReclaims_ClaimCollector", "\"ClaimCollector\" IN (0, 1, 2)");
                    table.CheckConstraint("CK_CarePackageReclaims_Status", "\"Status\" IN (0, 1, 2, 3, 4)");
                    table.CheckConstraint("CK_CarePackageReclaims_SubType", "\"SubType\" IN (0, 1, 2, 3)");
                    table.CheckConstraint("CK_CarePackageReclaims_Type", "\"Type\" IN (0, 1, 2)");
                    table.ForeignKey(
                        name: "FK_CarePackageReclaims_CarePackages_CarePackageId",
                        column: x => x.CarePackageId,
                        principalTable: "CarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaims_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaims_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageReclaims_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarePackageSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    CarePackageId = table.Column<Guid>(nullable: false),
                    HasRespiteCare = table.Column<bool>(nullable: false),
                    HasDischargePackage = table.Column<bool>(nullable: false),
                    HospitalAvoidance = table.Column<bool>(nullable: false),
                    IsReEnablement = table.Column<bool>(nullable: false),
                    IsS117Client = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackageSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarePackageSettings_CarePackages_CarePackageId",
                        column: x => x.CarePackageId,
                        principalTable: "CarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageSettings_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageSettings_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1f0bea0c-9f9a-4ef1-b911-83e2113dd503"), "9", "Broker Assistant", "BROKER ASSISTANT" },
                    { new Guid("1e958e66-b2a3-4e9d-9806-c5ca8bafda5d"), "8", "Broker Manager", "BROKER MANAGER" },
                    { new Guid("80f1ea68-9335-4efe-b247-7aa58cc45af0"), "7", "User", "USER" },
                    { new Guid("74b93ac7-1778-485d-a482-d76893f31aff"), "6", "Finance", "FINANCE" },
                    { new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089"), "5", "Approver", "APPROVER" },
                    { new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83"), "4", "Broker", "BROKER" },
                    { new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d"), "3", "Social Worker", "SOCIAL WORKER" },
                    { new Guid("66e830f6-ea42-44ad-beed-bbede0ff69df"), "2", "Administrator", "ADMINISTRATOR" },
                    { new Guid("7335e791-1d08-437a-974e-809944d29bc6"), "1", "Super Administrator", "SUPER ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"), 0, "df0c47dc-a59f-4a66-a2c0-1e844b073466", "duncan@gmail.com", false, false, null, "Duncan Okeno", null, null, null, "12345678910", false, null, false, "duncan@gmail.com" },
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), 0, "6b3d758b-924a-482c-af77-e31711a74a2f", "furkan@gmail.com", false, false, null, "Furkan Kuyar", null, null, null, "1234567890", false, null, false, "furkan@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CarePackageSchedulingOptions",
                columns: new[] { "Id", "OptionName", "OptionPeriod" },
                values: new object[,]
                {
                    { 1, "Interim or immediate service", "6 weeks and under" },
                    { 2, "Temporary", "Expected 52 weeks or under" },
                    { 3, "Long term", "52+ weeks" }
                });

            migrationBuilder.InsertData(
                table: "FundedNursingCarePrices",
                columns: new[] { "Id", "ActiveFrom", "ActiveTo", "PricePerWeek" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 187.6m },
                    { 2, new DateTimeOffset(new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 187.6m },
                    { 3, new DateTimeOffset(new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 187.6m }
                });

            migrationBuilder.InsertData(
                table: "PackageStatuses",
                columns: new[] { "Id", "StatusDisplayName", "StatusName" },
                values: new object[,]
                {
                    { 7, "Cancelled", "Cancelled" },
                    { 5, "Not Approved", "NotApproved" },
                    { 1, "New", "New" },
                    { 2, "In Progress", "InProgress" },
                    { 3, "Waiting for approval", "SubmittedForApproval" },
                    { 4, "Approved", "Approved" },
                    { 6, "Ended", "Ended" }
                });

            migrationBuilder.InsertData(
                table: "PrimarySupportReasons",
                columns: new[] { "PrimarySupportReasonId", "CederBudgetCode", "PrimarySupportReasonName" },
                values: new object[,]
                {
                    { 6, "Ceder Social Support", "Social Support" },
                    { 7, "Ceder Mental Health Support (ELFT)", "Mental Health Support (ELFT)" },
                    { 5, "Ceder Mental Health Support (ASC)", "Mental Health Support (ASC)" },
                    { 4, "Ceder Learning Disability Support", "Learning Disability Support" },
                    { 3, "Ceder Support with memory and cognition", "Support with memory and cognition" },
                    { 2, "Ceder Sensory Support", "Sensory Support" },
                    { 1, "Ceder - Physical Support", "Physical Support" }
                });

            migrationBuilder.InsertData(
                table: "ProvisionalCareChargeAmounts",
                columns: new[] { "Id", "AgeFrom", "AgeTo", "Amount", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 6, 60, null, 152.20m, new DateTimeOffset(new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, 60, null, 148.45m, new DateTimeOffset(new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, 25, 59, 84.40m, new DateTimeOffset(new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 1, 18, 24, 68.95m, new DateTimeOffset(new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, 18, 24, 69.40m, new DateTimeOffset(new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, 25, 59, 84.90m, new DateTimeOffset(new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "RoleId1", "UserId1" },
                values: new object[,]
                {
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("7335e791-1d08-437a-974e-809944d29bc6"), null, null },
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d"), null, null },
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83"), null, null }
                });

            migrationBuilder.InsertData(
                table: "ServiceUsers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "CanSpeakEnglish", "County", "CreatorId", "DateCreated", "DateOfBirth", "DateUpdated", "FirstName", "HackneyId", "LastName", "MiddleName", "PostCode", "PreferredContact", "PrimarySupportReasonId", "Town", "UpdaterId" },
                values: new object[,]
                {
                    { new Guid("dde0741c-f9a9-4d42-b889-a1d17864d77e"), "New Town", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1940, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Emma", 66779, "Coleman", null, "E1", "Phone", null, "Newcastle", null },
                    { new Guid("3c96cc5b-557e-42eb-957b-f9b0b7302ad7"), "X Road", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1950, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Jake", 33322, "Hart", null, "D1", "Phone", null, "Dorset", null },
                    { new Guid("9a84d6c3-e570-4f30-8bb2-80425d6f8e60"), "Y Street", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1958, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Colin", 10532, "Edmunds", null, "B4", "Phone", null, "Brighton", null },
                    { new Guid("0c6edb1d-799b-4ce3-98a8-e6fe271c4a8f"), "New Road", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mark", 33322, "Ateer", null, "I12", "Phone", null, "Ipswich", null },
                    { new Guid("de846662-e8fe-4c47-bd0a-20113b71e02d"), "Anfield", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Willie", 22222, "Makit", null, "L9", "Mail", null, "Liverpool", null },
                    { new Guid("14ffd252-a98b-4489-ab58-6db72ed317c6"), "X Town", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1944, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tim", 57806, "Gray", null, "W2", "Phone", null, "Watford", null },
                    { new Guid("a99f4b55-7c49-4bad-a338-86c6d79dfe36"), "YY Street", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Isabelle", 99999, "Ringing", null, "N7", "Phone", null, "Norwich", null },
                    { new Guid("6691fbfc-e398-41e0-8733-9ae98ebe2ba8"), "XX Road", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Constance", 88888, "Noring", null, "C2", "Phone", null, "Cardiff", null },
                    { new Guid("91990f8a-b325-43eb-8482-0d1c7dcf8cd5"), "Z Street", null, null, "Mid-Level", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Allie", 65653, "Grater", null, "W4", "Phone", null, "Ealing", null },
                    { new Guid("2f043f6f-09ed-42f0-ab30-c0409c05cb7e"), "Old Town Road", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Henry", 55555, "Ford", null, "SW16", "Phone", null, "Bristol", null },
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"), "Queens Town Road", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Furkan", 66666, "Kayar", null, "SW11", "Phone", null, "London", null },
                    { new Guid("61e8b256-3bb6-42a2-9d24-38a44a3bd5f2"), "Old Trafford", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Harriet", 11111, "Upp", null, "M8", "Phone", null, "Manchester", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "CreatorId", "DateCreated", "DateUpdated", "HasSupplierFrameworkContractedRates", "IsSupplierInternal", "PackageTypeId", "SupplierName", "UpdaterId" },
                values: new object[,]
                {
                    { 9, "The Hornchurch Care Home", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "The Hornchurch Care Home", null },
                    { 1, "Abbeleigh House", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Abbeleigh House", null },
                    { 2, "Abbey Care Complex", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Abbey Care Complex", null },
                    { 3, "Acacia Lodge [Cedar Site 0]", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Acacia Lodge", null },
                    { 4, "Hc-One Limited", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Hc-One Limited", null },
                    { 5, "Acorn Lodge", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Acorn Lodge", null },
                    { 6, "Albany Nursing Home", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Albany Nursing Home", null },
                    { 7, "Manor Farm Care Home", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Manor Farm Care Home", null },
                    { 8, "Four Seasons Health Care [Cedar Site 8] Lingfield Point", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Four Seasons Health Care", null },
                    { 10, "Bupa Care Homes [Cedar Site 10] Wynne Road", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Bupa Care Homes", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageDetails_CarePackageId",
                table: "CarePackageDetails",
                column: "CarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageDetails_CreatorId",
                table: "CarePackageDetails",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageDetails_UpdaterId",
                table: "CarePackageDetails",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageHistories_CarePackageId",
                table: "CarePackageHistories",
                column: "CarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageHistories_CreatorId",
                table: "CarePackageHistories",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageHistories_UpdaterId",
                table: "CarePackageHistories",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaims_CarePackageId",
                table: "CarePackageReclaims",
                column: "CarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaims_CreatorId",
                table: "CarePackageReclaims",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaims_SupplierId",
                table: "CarePackageReclaims",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageReclaims_UpdaterId",
                table: "CarePackageReclaims",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_ApproverId",
                table: "CarePackages",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_BrokerId",
                table: "CarePackages",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_CreatorId",
                table: "CarePackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_PrimarySupportReasonId",
                table: "CarePackages",
                column: "PrimarySupportReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_ServiceUserId",
                table: "CarePackages",
                column: "ServiceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_SupplierId",
                table: "CarePackages",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_UpdaterId",
                table: "CarePackages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageSettings_CarePackageId",
                table: "CarePackageSettings",
                column: "CarePackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageSettings_CreatorId",
                table: "CarePackageSettings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageSettings_UpdaterId",
                table: "CarePackageSettings",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_CreatorId",
                table: "ServiceUsers",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_PrimarySupportReasonId",
                table: "ServiceUsers",
                column: "PrimarySupportReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_UpdaterId",
                table: "ServiceUsers",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CreatorId",
                table: "Suppliers",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UpdaterId",
                table: "Suppliers",
                column: "UpdaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarePackageDetails");

            migrationBuilder.DropTable(
                name: "CarePackageHistories");

            migrationBuilder.DropTable(
                name: "CarePackageReclaims");

            migrationBuilder.DropTable(
                name: "CarePackageSchedulingOptions");

            migrationBuilder.DropTable(
                name: "CarePackageSettings");

            migrationBuilder.DropTable(
                name: "FundedNursingCarePrices");

            migrationBuilder.DropTable(
                name: "PackageStatuses");

            migrationBuilder.DropTable(
                name: "ProvisionalCareChargeAmounts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CarePackages");

            migrationBuilder.DropTable(
                name: "ServiceUsers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "PrimarySupportReasons");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
#pragma warning restore CA1814
}
