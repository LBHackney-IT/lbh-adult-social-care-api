using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class removedLegacyEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_FundedNursingCareCollectors_FundedNursingCareColl~",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Packages_PackageTypeId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "DayCareApprovalHistory");

            migrationBuilder.DropTable(
                name: "DayCareBrokerageInfo");

            migrationBuilder.DropTable(
                name: "DayCareColleges");

            migrationBuilder.DropTable(
                name: "DayCarePackageOpportunities");

            migrationBuilder.DropTable(
                name: "DayCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "DayCareRequestMoreInformations");

            migrationBuilder.DropTable(
                name: "EscortPackages");

            migrationBuilder.DropTable(
                name: "FundedNursingCares");

            migrationBuilder.DropTable(
                name: "HomeCareApprovalHistories");

            migrationBuilder.DropTable(
                name: "HomeCarePackageCosts");

            migrationBuilder.DropTable(
                name: "HomeCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "HomeCarePackageSlots");

            migrationBuilder.DropTable(
                name: "HomeCareRequestMoreInformations");

            migrationBuilder.DropTable(
                name: "HomeCareServiceTypeMinutes");

            migrationBuilder.DropTable(
                name: "HomeCareStages");

            migrationBuilder.DropTable(
                name: "HomeCareSupplierCosts");

            migrationBuilder.DropTable(
                name: "InvoiceCreditNotes");

            migrationBuilder.DropTable(
                name: "NursingCareAdditionalNeeds");

            migrationBuilder.DropTable(
                name: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.DropTable(
                name: "NursingCareApprovalHistories");

            migrationBuilder.DropTable(
                name: "NursingCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "NursingCareRequestMoreInformations");

            migrationBuilder.DropTable(
                name: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropTable(
                name: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.DropTable(
                name: "ResidentialCareApprovalHistories");

            migrationBuilder.DropTable(
                name: "ResidentialCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "ResidentialCareRequestMoreInformations");

            migrationBuilder.DropTable(
                name: "TransportEscortPackages");

            migrationBuilder.DropTable(
                name: "TransportPackages");

            migrationBuilder.DropTable(
                name: "OpportunityLengthOptions");

            migrationBuilder.DropTable(
                name: "OpportunityTimesPerMonthOptions");

            migrationBuilder.DropTable(
                name: "FundedNursingCareCollectors");

            migrationBuilder.DropTable(
                name: "HomeCarePackage");

            migrationBuilder.DropTable(
                name: "TimeSlotShifts");

            migrationBuilder.DropTable(
                name: "CarerTypes");

            migrationBuilder.DropTable(
                name: "CareChargeElements");

            migrationBuilder.DropTable(
                name: "InvoiceNoteChargeTypes");

            migrationBuilder.DropTable(
                name: "InvoiceItemPriceEffects");

            migrationBuilder.DropTable(
                name: "NursingCareBrokerageInfos");

            migrationBuilder.DropTable(
                name: "AdditionalNeedsPaymentTypes");

            migrationBuilder.DropTable(
                name: "ResidentialCareBrokerageInfos");

            migrationBuilder.DropTable(
                name: "ReclaimAmountOptions");

            migrationBuilder.DropTable(
                name: "ReclaimCategories");

            migrationBuilder.DropTable(
                name: "ReclaimFroms");

            migrationBuilder.DropTable(
                name: "DayCarePackages");

            migrationBuilder.DropTable(
                name: "HomeCareServiceTypes");

            migrationBuilder.DropTable(
                name: "PackageCostClaimers");

            migrationBuilder.DropTable(
                name: "CareChargeStatuses");

            migrationBuilder.DropTable(
                name: "CareChargeTypes");

            migrationBuilder.DropTable(
                name: "NursingCarePackages");

            migrationBuilder.DropTable(
                name: "ResidentialCarePackages");

            migrationBuilder.DropTable(
                name: "DayCarePackageStatuses");

            migrationBuilder.DropTable(
                name: "TermTimeConsiderationOptions");

            migrationBuilder.DropTable(
                name: "PackageCareCharges");

            migrationBuilder.DropTable(
                name: "TypesOfNursingCareHomes");

            migrationBuilder.DropTable(
                name: "NursingCareTypeOfStayOptions");

            migrationBuilder.DropTable(
                name: "PackageStages");

            migrationBuilder.DropTable(
                name: "TypesOfResidentialCareHomes");

            migrationBuilder.DropTable(
                name: "ResidentialCareTypeOfStayOptions");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_FundedNursingCareCollectorId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_PackageTypeId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "FundedNursingCareCollectorId",
                table: "Suppliers");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.AddColumn<int>(
                name: "FundedNursingCareCollectorId",
                table: "Suppliers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdditionalNeedsPaymentTypes",
                columns: table => new
                {
                    AdditionalNeedsPaymentTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalNeedsPaymentTypes", x => x.AdditionalNeedsPaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CareChargeStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareChargeStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CareChargeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareChargeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarerTypes",
                columns: table => new
                {
                    CarerTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarerTypeMinutes = table.Column<int>(type: "integer", nullable: false),
                    CarerTypeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarerTypes", x => x.CarerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DayCareColleges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CollegeName = table.Column<string>(type: "text", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCareColleges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayCareColleges_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCareColleges_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayCarePackageStatuses",
                columns: table => new
                {
                    PackageStatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDayCareStatus = table.Column<bool>(type: "boolean", nullable: false),
                    IsStatusActive = table.Column<bool>(type: "boolean", nullable: false),
                    PackageAction = table.Column<string>(type: "text", nullable: true),
                    SequenceNumber = table.Column<int>(type: "integer", nullable: false),
                    Stage = table.Column<string>(type: "text", nullable: true),
                    StatusName = table.Column<string>(type: "text", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCarePackageStatuses", x => x.PackageStatusId);
                    table.ForeignKey(
                        name: "FK_DayCarePackageStatuses_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackageStatuses_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayCareRequestMoreInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DayCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    InformationText = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCareRequestMoreInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareRequestMoreInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    InformationText = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareRequestMoreInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ServiceName = table.Column<string>(type: "text", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareServiceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCareServiceTypes_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCareServiceTypes_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StageName = table.Column<string>(type: "text", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCareStages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCareStages_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItemPriceEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EffectName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItemPriceEffects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceNoteChargeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChargeTypeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceNoteChargeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NursingCareRequestMoreInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InformationText = table.Column<string>(type: "text", nullable: true),
                    NursingCarePackageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareRequestMoreInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NursingCareTypeOfStayOptions",
                columns: table => new
                {
                    TypeOfStayOptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(type: "text", nullable: true),
                    OptionPeriod = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareTypeOfStayOptions", x => x.TypeOfStayOptionId);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityLengthOptions",
                columns: table => new
                {
                    OpportunityLengthOptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(type: "text", nullable: true),
                    TimeInMinutes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityLengthOptions", x => x.OpportunityLengthOptionId);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityTimesPerMonthOptions",
                columns: table => new
                {
                    OpportunityTimePerMonthOptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityTimesPerMonthOptions", x => x.OpportunityTimePerMonthOptionId);
                });

            migrationBuilder.CreateTable(
                name: "PackageCostClaimers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageCostClaimers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PackageType = table.Column<string>(type: "text", nullable: true),
                    Sequence = table.Column<int>(type: "integer", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StageName = table.Column<string>(type: "text", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageStages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageStages_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReclaimAmountOptions",
                columns: table => new
                {
                    AmountOptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AmountOptionName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimAmountOptions", x => x.AmountOptionId);
                });

            migrationBuilder.CreateTable(
                name: "ReclaimCategories",
                columns: table => new
                {
                    ReclaimCategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReclaimCategoryName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimCategories", x => x.ReclaimCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ReclaimFroms",
                columns: table => new
                {
                    ReclaimFromId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReclaimFromName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimFroms", x => x.ReclaimFromId);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareRequestMoreInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InformationText = table.Column<string>(type: "text", nullable: true),
                    ResidentialCarePackageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareRequestMoreInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareTypeOfStayOptions",
                columns: table => new
                {
                    TypeOfStayOptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(type: "text", nullable: true),
                    OptionPeriod = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareTypeOfStayOptions", x => x.TypeOfStayOptionId);
                });

            migrationBuilder.CreateTable(
                name: "TermTimeConsiderationOptions",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermTimeConsiderationOptions", x => x.OptionId);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfNursingCareHomes",
                columns: table => new
                {
                    TypeOfCareHomeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeOfCareHomeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfNursingCareHomes", x => x.TypeOfCareHomeId);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfResidentialCareHomes",
                columns: table => new
                {
                    TypeOfCareHomeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeOfCareHomeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfResidentialCareHomes", x => x.TypeOfCareHomeId);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackageCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarerTypeId = table.Column<int>(type: "integer", nullable: true),
                    CostPerHour = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    HomeCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    HomeCareServiceTypeId = table.Column<int>(type: "integer", nullable: false),
                    HoursPerWeek = table.Column<double>(type: "double precision", nullable: false),
                    IsSecondaryCarer = table.Column<bool>(type: "boolean", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
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
                        name: "FK_HomeCarePackageCosts_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageCosts_HomeCareServiceTypes_HomeCareServiceTy~",
                        column: x => x.HomeCareServiceTypeId,
                        principalTable: "HomeCareServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageCosts_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareServiceTypeMinutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeCareServiceTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsSecondaryCarer = table.Column<bool>(type: "boolean", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    Minutes = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarerTypeId = table.Column<int>(type: "integer", nullable: true),
                    CostPerHour = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    HomeCareServiceTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsSecondaryCarer = table.Column<bool>(type: "boolean", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
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
                        name: "FK_HomeCareSupplierCosts_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCareSupplierCosts_HomeCareServiceTypes_HomeCareServiceT~",
                        column: x => x.HomeCareServiceTypeId,
                        principalTable: "HomeCareServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCareSupplierCosts_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlotShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LinkedToHomeCareServiceTypeId = table.Column<int>(type: "integer", nullable: true),
                    TimeSlotShiftName = table.Column<string>(type: "text", nullable: false),
                    TimeSlotTimeLabel = table.Column<string>(type: "text", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlotShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlotShifts_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSlotShifts_HomeCareServiceTypes_LinkedToHomeCareService~",
                        column: x => x.LinkedToHomeCareServiceTypeId,
                        principalTable: "HomeCareServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeSlotShifts_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundedNursingCareCollectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaimedBy = table.Column<int>(type: "integer", nullable: false),
                    OptionInvoiceName = table.Column<string>(type: "text", nullable: true),
                    OptionName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundedNursingCareCollectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundedNursingCareCollectors_PackageCostClaimers_ClaimedBy",
                        column: x => x.ClaimedBy,
                        principalTable: "PackageCostClaimers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageCareCharges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsProvisional = table.Column<bool>(type: "boolean", nullable: false),
                    PackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    PackageTypeId = table.Column<int>(type: "integer", nullable: false),
                    ServiceUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageCareCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageCareCharges_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageCareCharges_Packages_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageCareCharges_Clients_ServiceUserId",
                        column: x => x.ServiceUserId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageCareCharges_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageCareCharges_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsFixedPeriod = table.Column<bool>(type: "boolean", nullable: false),
                    IsOngoingPeriod = table.Column<bool>(type: "boolean", nullable: false),
                    IsThisAnImmediateService = table.Column<bool>(type: "boolean", nullable: false),
                    IsThisuserUnderS117 = table.Column<bool>(type: "boolean", nullable: false),
                    StageId = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
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
                        name: "FK_HomeCarePackage_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCarePackage_PackageStages_StageId",
                        column: x => x.StageId,
                        principalTable: "PackageStages",
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
                    table.ForeignKey(
                        name: "FK_HomeCarePackage_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayCarePackages",
                columns: table => new
                {
                    DayCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CollegeId = table.Column<int>(type: "integer", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EscortNeeded = table.Column<bool>(type: "boolean", nullable: false),
                    Friday = table.Column<bool>(type: "boolean", nullable: false),
                    IsFixedPeriodOrOngoing = table.Column<bool>(type: "boolean", nullable: false),
                    IsThisAnImmediateService = table.Column<bool>(type: "boolean", nullable: false),
                    IsThisUserUnderS117 = table.Column<bool>(type: "boolean", nullable: false),
                    Monday = table.Column<bool>(type: "boolean", nullable: false),
                    NeedToAddress = table.Column<string>(type: "text", nullable: true),
                    PackageId = table.Column<int>(type: "integer", nullable: false),
                    Saturday = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    Sunday = table.Column<bool>(type: "boolean", nullable: false),
                    TermTimeConsiderationOptionId = table.Column<int>(type: "integer", nullable: false),
                    Thursday = table.Column<bool>(type: "boolean", nullable: false),
                    TransportEscortNeeded = table.Column<bool>(type: "boolean", nullable: false),
                    TransportNeeded = table.Column<bool>(type: "boolean", nullable: false),
                    Tuesday = table.Column<bool>(type: "boolean", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Wednesday = table.Column<bool>(type: "boolean", nullable: false)
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
                        name: "FK_DayCarePackages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_DayCarePackages_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCarePackages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    HasDischargePackage = table.Column<bool>(type: "boolean", nullable: false),
                    HasRespiteCare = table.Column<bool>(type: "boolean", nullable: false),
                    IsFixedPeriod = table.Column<bool>(type: "boolean", nullable: false),
                    IsThisAnImmediateService = table.Column<bool>(type: "boolean", nullable: false),
                    IsThisUserUnderS117 = table.Column<bool>(type: "boolean", nullable: false),
                    NeedToAddress = table.Column<string>(type: "text", nullable: true),
                    PaidUpTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PreviousPaidUpTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StageId = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: true),
                    TypeOfResidentialCareHomeId = table.Column<int>(type: "integer", nullable: true),
                    TypeOfStayId = table.Column<int>(type: "integer", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCarePackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_PackageStages_StageId",
                        column: x => x.StageId,
                        principalTable: "PackageStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_PackageStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PackageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackages_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
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
                        name: "FK_ResidentialCarePackages_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackageSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DayId = table.Column<int>(type: "integer", nullable: false),
                    HomeCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    NeedToAddress = table.Column<string>(type: "text", nullable: true),
                    PrimaryInMinutes = table.Column<int>(type: "integer", nullable: false),
                    SecondaryInMinutes = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    TimeSlotShiftId = table.Column<int>(type: "integer", nullable: false),
                    WhatShouldBeDone = table.Column<string>(type: "text", nullable: true)
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
                name: "CareChargeElements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    CareChargeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimCollectorId = table.Column<int>(type: "integer", nullable: false),
                    ClaimReasons = table.Column<string>(type: "text", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PaidUpTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PreviousPaidUpTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareChargeElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_PackageCareCharges_CareChargeId",
                        column: x => x.CareChargeId,
                        principalTable: "PackageCareCharges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_PackageCostClaimers_ClaimCollectorId",
                        column: x => x.ClaimCollectorId,
                        principalTable: "PackageCostClaimers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_CareChargeStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "CareChargeStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_CareChargeTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CareChargeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NursingCarePackages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CareChargeId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    HasDischargePackage = table.Column<bool>(type: "boolean", nullable: false),
                    HasRespiteCare = table.Column<bool>(type: "boolean", nullable: false),
                    IsFixedPeriod = table.Column<bool>(type: "boolean", nullable: false),
                    IsThisAnImmediateService = table.Column<bool>(type: "boolean", nullable: false),
                    IsThisUserUnderS117 = table.Column<bool>(type: "boolean", nullable: false),
                    NeedToAddress = table.Column<string>(type: "text", nullable: true),
                    PaidUpTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PreviousPaidUpTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StageId = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: true),
                    TypeOfNursingCareHomeId = table.Column<int>(type: "integer", nullable: true),
                    TypeOfStayId = table.Column<int>(type: "integer", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCarePackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_AspNetUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_PackageCareCharges_CareChargeId",
                        column: x => x.CareChargeId,
                        principalTable: "PackageCareCharges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_PackageStages_StageId",
                        column: x => x.StageId,
                        principalTable: "PackageStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_PackageStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PackageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCarePackages_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
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
                        name: "FK_NursingCarePackages_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareApprovalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApprovedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorRole = table.Column<string>(type: "text", nullable: true),
                    HomeCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    LogSubText = table.Column<string>(type: "text", nullable: true),
                    LogText = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareApprovalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCareApprovalHistories_HomeCarePackage_HomeCarePackageId",
                        column: x => x.HomeCarePackageId,
                        principalTable: "HomeCarePackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCareApprovalHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackageReclaims",
                columns: table => new
                {
                    HomeCarePackageReclaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    HomeCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ReclaimAmountOptionId = table.Column<int>(type: "integer", nullable: false),
                    ReclaimCategoryId = table.Column<int>(type: "integer", nullable: false),
                    ReclaimFromId = table.Column<int>(type: "integer", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarePackageReclaims", x => x.HomeCarePackageReclaimId);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageReclaims_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeCarePackageReclaims_HomeCarePackage_HomeCarePackageId",
                        column: x => x.HomeCarePackageId,
                        principalTable: "HomeCarePackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_HomeCarePackageReclaims_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayCareApprovalHistory",
                columns: table => new
                {
                    HistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorRole = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DayCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    LogSubText = table.Column<string>(type: "text", nullable: true),
                    LogText = table.Column<string>(type: "text", nullable: false),
                    PackageStatusId = table.Column<int>(type: "integer", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCareApprovalHistory", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_DayCareApprovalHistory_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
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
                    table.ForeignKey(
                        name: "FK_DayCareApprovalHistory_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayCareBrokerageInfo",
                columns: table => new
                {
                    BrokerageInfoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CorePackageCostPerDay = table.Column<decimal>(type: "numeric", nullable: false),
                    CorePackageDaysPerWeek = table.Column<int>(type: "integer", nullable: false),
                    CorePackageSupplierId = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DayCareOpportunitiesCostPerHour = table.Column<decimal>(type: "numeric", nullable: true),
                    DayCareOpportunitiesHoursPerWeek = table.Column<int>(type: "integer", nullable: true),
                    DayCareOpportunitiesSupplierId = table.Column<int>(type: "integer", nullable: true),
                    DayCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    EscortCostPerHour = table.Column<decimal>(type: "numeric", nullable: true),
                    EscortHoursPerWeek = table.Column<int>(type: "integer", nullable: true),
                    EscortSupplierId = table.Column<int>(type: "integer", nullable: true),
                    TransportCostPerDay = table.Column<decimal>(type: "numeric", nullable: true),
                    TransportDaysPerWeek = table.Column<int>(type: "integer", nullable: true),
                    TransportEscortCostPerWeek = table.Column<decimal>(type: "numeric", nullable: true),
                    TransportEscortHoursPerWeek = table.Column<int>(type: "integer", nullable: true),
                    TransportEscortSupplierId = table.Column<int>(type: "integer", nullable: true),
                    TransportSupplierId = table.Column<int>(type: "integer", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCareBrokerageInfo", x => x.BrokerageInfoId);
                    table.ForeignKey(
                        name: "FK_DayCareBrokerageInfo_Suppliers_CorePackageSupplierId",
                        column: x => x.CorePackageSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCareBrokerageInfo_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCareBrokerageInfo_Suppliers_DayCareOpportunitiesSupplier~",
                        column: x => x.DayCareOpportunitiesSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayCareBrokerageInfo_DayCarePackages_DayCarePackageId",
                        column: x => x.DayCarePackageId,
                        principalTable: "DayCarePackages",
                        principalColumn: "DayCarePackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCareBrokerageInfo_Suppliers_EscortSupplierId",
                        column: x => x.EscortSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayCareBrokerageInfo_Suppliers_TransportEscortSupplierId",
                        column: x => x.TransportEscortSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayCareBrokerageInfo_Suppliers_TransportSupplierId",
                        column: x => x.TransportSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayCareBrokerageInfo_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayCarePackageOpportunities",
                columns: table => new
                {
                    DayCarePackageOpportunityId = table.Column<Guid>(type: "uuid", nullable: false),
                    DayCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    OpportunitiesNeedToAddress = table.Column<string>(type: "text", nullable: true),
                    OpportunityLengthOptionId = table.Column<int>(type: "integer", nullable: false),
                    OpportunityTimePerMonthOptionId = table.Column<int>(type: "integer", nullable: false)
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
                name: "DayCarePackageReclaims",
                columns: table => new
                {
                    DayCarePackageReclaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DayCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ReclaimAmountOptionId = table.Column<int>(type: "integer", nullable: false),
                    ReclaimCategoryId = table.Column<int>(type: "integer", nullable: false),
                    ReclaimFromId = table.Column<int>(type: "integer", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCarePackageReclaims", x => x.DayCarePackageReclaimId);
                    table.ForeignKey(
                        name: "FK_DayCarePackageReclaims_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackageReclaims_DayCarePackages_DayCarePackageId",
                        column: x => x.DayCarePackageId,
                        principalTable: "DayCarePackages",
                        principalColumn: "DayCarePackageId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_DayCarePackageReclaims_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EscortPackages",
                columns: table => new
                {
                    EscortPackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DayCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Destination = table.Column<string>(type: "text", nullable: true),
                    EscortCostPerHour = table.Column<decimal>(type: "numeric", nullable: true),
                    EscortHoursPerWeek = table.Column<int>(type: "integer", nullable: true),
                    Friday = table.Column<bool>(type: "boolean", nullable: false),
                    Monday = table.Column<bool>(type: "boolean", nullable: false),
                    Saturday = table.Column<bool>(type: "boolean", nullable: false),
                    Sunday = table.Column<bool>(type: "boolean", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: true),
                    Thursday = table.Column<bool>(type: "boolean", nullable: false),
                    Tuesday = table.Column<bool>(type: "boolean", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Wednesday = table.Column<bool>(type: "boolean", nullable: false)
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
                        name: "FK_EscortPackages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
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
                    table.ForeignKey(
                        name: "FK_EscortPackages_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportEscortPackages",
                columns: table => new
                {
                    TransportEscortPackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DayCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Destination = table.Column<string>(type: "text", nullable: true),
                    Friday = table.Column<bool>(type: "boolean", nullable: false),
                    Monday = table.Column<bool>(type: "boolean", nullable: false),
                    Saturday = table.Column<bool>(type: "boolean", nullable: false),
                    Sunday = table.Column<bool>(type: "boolean", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: true),
                    Thursday = table.Column<bool>(type: "boolean", nullable: false),
                    TransportEscortCostPerWeek = table.Column<decimal>(type: "numeric", nullable: true),
                    TransportEscortHoursPerWeek = table.Column<int>(type: "integer", nullable: true),
                    Tuesday = table.Column<bool>(type: "boolean", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Wednesday = table.Column<bool>(type: "boolean", nullable: false)
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
                        name: "FK_TransportEscortPackages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
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
                    table.ForeignKey(
                        name: "FK_TransportEscortPackages_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportPackages",
                columns: table => new
                {
                    TransportPackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DayCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Destination = table.Column<string>(type: "text", nullable: true),
                    Friday = table.Column<bool>(type: "boolean", nullable: false),
                    Monday = table.Column<bool>(type: "boolean", nullable: false),
                    Saturday = table.Column<bool>(type: "boolean", nullable: false),
                    Sunday = table.Column<bool>(type: "boolean", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: true),
                    Thursday = table.Column<bool>(type: "boolean", nullable: false),
                    TransportCostPerDay = table.Column<decimal>(type: "numeric", nullable: true),
                    TransportDaysPerWeek = table.Column<int>(type: "integer", nullable: true),
                    Tuesday = table.Column<bool>(type: "boolean", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Wednesday = table.Column<bool>(type: "boolean", nullable: false)
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
                        name: "FK_TransportPackages_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
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
                    table.ForeignKey(
                        name: "FK_TransportPackages_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareAdditionalNeeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionalNeedsPaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NeedToAddress = table.Column<string>(type: "text", nullable: true),
                    ResidentialCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareAdditionalNeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeeds_AdditionalNeedsPaymentTypes_~",
                        column: x => x.AdditionalNeedsPaymentTypeId,
                        principalTable: "AdditionalNeedsPaymentTypes",
                        principalColumn: "AdditionalNeedsPaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeeds_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeeds_ResidentialCarePackages_Resi~",
                        column: x => x.ResidentialCarePackageId,
                        principalTable: "ResidentialCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeeds_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareApprovalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorRole = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LogSubText = table.Column<string>(type: "text", nullable: true),
                    LogText = table.Column<string>(type: "text", nullable: true),
                    ResidentialCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareApprovalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialCareApprovalHistories_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareApprovalHistories_ResidentialCarePackages_Re~",
                        column: x => x.ResidentialCarePackageId,
                        principalTable: "ResidentialCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareApprovalHistories_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareBrokerageInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    HasCareCharges = table.Column<bool>(type: "boolean", nullable: false),
                    ResidentialCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResidentialCore = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareBrokerageInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialCareBrokerageInfos_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareBrokerageInfos_ResidentialCarePackages_Resid~",
                        column: x => x.ResidentialCarePackageId,
                        principalTable: "ResidentialCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareBrokerageInfos_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCarePackageReclaims",
                columns: table => new
                {
                    ResidentialCarePackageReclaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ReclaimAmountOptionId = table.Column<int>(type: "integer", nullable: false),
                    ReclaimCategoryId = table.Column<int>(type: "integer", nullable: false),
                    ReclaimFromId = table.Column<int>(type: "integer", nullable: false),
                    ResidentialCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCarePackageReclaims", x => x.ResidentialCarePackageReclaimId);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageReclaims_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageReclaims_ResidentialCarePackages_Resi~",
                        column: x => x.ResidentialCarePackageId,
                        principalTable: "ResidentialCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageReclaims_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceCreditNotes",
                columns: table => new
                {
                    InvoiceCreditNoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    CareChargeElementId = table.Column<Guid>(type: "uuid", nullable: true),
                    ChargeTypeId = table.Column<int>(type: "integer", nullable: false),
                    ClaimCollectorId = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HasBeenAddedToUserInvoice = table.Column<bool>(type: "boolean", nullable: false),
                    PackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    PackageTypeId = table.Column<int>(type: "integer", nullable: false),
                    PriceEffectId = table.Column<int>(type: "integer", nullable: false),
                    SentOrInvoiced = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceCreditNotes", x => x.InvoiceCreditNoteId);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_CareChargeElements_CareChargeElementId",
                        column: x => x.CareChargeElementId,
                        principalTable: "CareChargeElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_InvoiceNoteChargeTypes_ChargeTypeId",
                        column: x => x.ChargeTypeId,
                        principalTable: "InvoiceNoteChargeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_PackageCostClaimers_ClaimCollectorId",
                        column: x => x.ClaimCollectorId,
                        principalTable: "PackageCostClaimers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_Packages_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_InvoiceItemPriceEffects_PriceEffectId",
                        column: x => x.PriceEffectId,
                        principalTable: "InvoiceItemPriceEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_Clients_ServiceUserId",
                        column: x => x.ServiceUserId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceCreditNotes_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundedNursingCares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CollectorId = table.Column<int>(type: "integer", nullable: false),
                    NursingCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReclaimTargetInstitutionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundedNursingCares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundedNursingCares_FundedNursingCareCollectors_CollectorId",
                        column: x => x.CollectorId,
                        principalTable: "FundedNursingCareCollectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundedNursingCares_NursingCarePackages_NursingCarePackageId",
                        column: x => x.NursingCarePackageId,
                        principalTable: "NursingCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundedNursingCares_ReclaimFroms_ReclaimTargetInstitutionId",
                        column: x => x.ReclaimTargetInstitutionId,
                        principalTable: "ReclaimFroms",
                        principalColumn: "ReclaimFromId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NursingCareAdditionalNeeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionalNeedsPaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NeedToAddress = table.Column<string>(type: "text", nullable: true),
                    NursingCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareAdditionalNeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeeds_AdditionalNeedsPaymentTypes_Addi~",
                        column: x => x.AdditionalNeedsPaymentTypeId,
                        principalTable: "AdditionalNeedsPaymentTypes",
                        principalColumn: "AdditionalNeedsPaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeeds_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeeds_NursingCarePackages_NursingCareP~",
                        column: x => x.NursingCarePackageId,
                        principalTable: "NursingCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeeds_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NursingCareApprovalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorRole = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LogSubText = table.Column<string>(type: "text", nullable: true),
                    LogText = table.Column<string>(type: "text", nullable: true),
                    NursingCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareApprovalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NursingCareApprovalHistories_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareApprovalHistories_NursingCarePackages_NursingCar~",
                        column: x => x.NursingCarePackageId,
                        principalTable: "NursingCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareApprovalHistories_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NursingCareBrokerageInfos",
                columns: table => new
                {
                    NursingCareBrokerageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    HasCareCharges = table.Column<bool>(type: "boolean", nullable: false),
                    NursingCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    NursingCore = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareBrokerageInfos", x => x.NursingCareBrokerageId);
                    table.ForeignKey(
                        name: "FK_NursingCareBrokerageInfos_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareBrokerageInfos_NursingCarePackages_NursingCarePa~",
                        column: x => x.NursingCarePackageId,
                        principalTable: "NursingCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareBrokerageInfos_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NursingCarePackageReclaims",
                columns: table => new
                {
                    NursingCarePackageReclaimId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    NursingCarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReclaimAmountOptionId = table.Column<int>(type: "integer", nullable: false),
                    ReclaimCategoryId = table.Column<int>(type: "integer", nullable: false),
                    ReclaimFromId = table.Column<int>(type: "integer", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCarePackageReclaims", x => x.NursingCarePackageReclaimId);
                    table.ForeignKey(
                        name: "FK_NursingCarePackageReclaims_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackageReclaims_NursingCarePackages_NursingCareP~",
                        column: x => x.NursingCarePackageId,
                        principalTable: "NursingCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_NursingCarePackageReclaims_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareAdditionalNeedsCosts",
                columns: table => new
                {
                    ResidentialCareAdditionalNeedsCostId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionalNeedsCost = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    AdditionalNeedsPaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ResidentialCareBrokerageId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareAdditionalNeedsCosts", x => x.ResidentialCareAdditionalNeedsCostId);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeedsCosts_AdditionalNeedsPaymentT~",
                        column: x => x.AdditionalNeedsPaymentTypeId,
                        principalTable: "AdditionalNeedsPaymentTypes",
                        principalColumn: "AdditionalNeedsPaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeedsCosts_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeedsCosts_ResidentialCareBrokerag~",
                        column: x => x.ResidentialCareBrokerageId,
                        principalTable: "ResidentialCareBrokerageInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeedsCosts_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NursingCareAdditionalNeedsCosts",
                columns: table => new
                {
                    NursingCareAdditionalNeedsCostId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdditionalNeedsCost = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    AdditionalNeedsPaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    NursingCareBrokerageId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareAdditionalNeedsCosts", x => x.NursingCareAdditionalNeedsCostId);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeedsCosts_AdditionalNeedsPaymentTypes~",
                        column: x => x.AdditionalNeedsPaymentTypeId,
                        principalTable: "AdditionalNeedsPaymentTypes",
                        principalColumn: "AdditionalNeedsPaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeedsCosts_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeedsCosts_NursingCareBrokerageInfos_N~",
                        column: x => x.NursingCareBrokerageId,
                        principalTable: "NursingCareBrokerageInfos",
                        principalColumn: "NursingCareBrokerageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeedsCosts_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

#pragma warning disable CA1814
            migrationBuilder.InsertData(
                table: "AdditionalNeedsPaymentTypes",
                columns: new[] { "AdditionalNeedsPaymentTypeId", "OptionName" },
                values: new object[,]
                {
                    { 1, "Weekly" },
                    { 2, "One Off" },
                    { 3, "Fixed Period" }
                });

            migrationBuilder.InsertData(
                table: "CareChargeStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Ended" },
                    { 3, "Cancelled" },
                    { 4, "Future" }
                });

            migrationBuilder.InsertData(
                table: "CareChargeTypes",
                columns: new[] { "Id", "OptionName" },
                values: new object[,]
                {
                    { 1, "Provisional" },
                    { 2, "Without Property 1-12 Weeks" },
                    { 3, "Without Property 13+ Weeks" }
                });

            migrationBuilder.InsertData(
                table: "CarerTypes",
                columns: new[] { "CarerTypeId", "CarerTypeMinutes", "CarerTypeName" },
                values: new object[,]
                {
                    { 3, 60, "60m+ Call" },
                    { 1, 30, "30m Call" },
                    { 2, 45, "45m Call" }
                });

            migrationBuilder.InsertData(
                table: "DayCarePackageStatuses",
                columns: new[] { "PackageStatusId", "CreatorId", "DateCreated", "DateUpdated", "IsDayCareStatus", "IsStatusActive", "PackageAction", "SequenceNumber", "Stage", "StatusName", "UpdaterId" },
                values: new object[,]
                {
                    { 14, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Request More Information", 8, "BROKERAGE APPROVAL", "Clarifying Commercials", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 15, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Contracted", 9, "CONTRACTION", "Package Contracted", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 13, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Rejected", 8, "BROKERAGE APPROVAL", "Package Commercials - Rejected", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 12, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Approved", 8, "BROKERAGE APPROVAL", "Commercials Approved", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 10, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "PricingAgreed", 6, "PACKAGE BROKERING", "Brokerage - Pricing Agreed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 9, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "SupplierSourced", 6, "PACKAGE BROKERING", "Brokerage - Supplier Sourced", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 8, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Querying", 6, "PACKAGE BROKERING", "Brokerage - Querying", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 7, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Assigned", 5, "NEW BROKERAGE", "Brokerage - Assigned", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 11, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "New", 7, "NEW BROKERAGE APPROVAL", "Brokerage - Submitted for Approval", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 5, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Request More Information", 3, "PACKAGE DETAIL APPROVAL", "Clarification Needed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 4, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Reject", 3, "PACKAGE DETAIL APPROVAL", "Reject Package", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 3, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Approve", 3, "PACKAGE DETAIL APPROVAL", "Contents Approved", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 2, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "New", 2, "NEW PACKAGE DETAIL APPROVAL", "Submitted for Approval", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 1, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "Created", 1, "PACKAGE BUILDER", "New Package", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 6, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, "New", 4, "NEW BROKERAGE", "Brokerage - New", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
                });

            migrationBuilder.InsertData(
                table: "HomeCareServiceTypes",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "ServiceName", "UpdaterId" },
                values: new object[,]
                {
                    { 7, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sleeping Nights", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 1, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Personal Home Care", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 2, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Domestic Care", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 3, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Live-in Care", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 4, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Escort Care", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 5, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Night Owl", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 6, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Waking Nights", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
                });

            migrationBuilder.InsertData(
                table: "HomeCareStages",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "StageName", "UpdaterId" },
                values: new object[,]
                {
                    { 2, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Assigned", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 1, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "New", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 3, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Querying", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 6, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Submitted For Approval", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 5, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Pricing agreed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 4, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Supplier Sourced", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
                });

            migrationBuilder.InsertData(
                table: "InvoiceItemPriceEffects",
                columns: new[] { "Id", "EffectName" },
                values: new object[,]
                {
                    { 1, "None" },
                    { 3, "Subtract" },
                    { 2, "Add" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceNoteChargeTypes",
                columns: new[] { "Id", "ChargeTypeName" },
                values: new object[,]
                {
                    { 1, "OverCharge" },
                    { 2, "UnderCharge" }
                });

            migrationBuilder.InsertData(
                table: "NursingCareTypeOfStayOptions",
                columns: new[] { "TypeOfStayOptionId", "OptionName", "OptionPeriod" },
                values: new object[,]
                {
                    { 1, "Interim", "Under 6 weeks" },
                    { 2, "Temporary", "Expected under 52 weeks" },
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
                    { 2, "Weekly" },
                    { 3, "Monthly" },
                    { 1, "Daily" }
                });

            migrationBuilder.InsertData(
                table: "PackageCostClaimers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Hackney" },
                    { 1, "Supplier" }
                });

            migrationBuilder.InsertData(
                table: "PackageStages",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "StageName", "UpdaterId" },
                values: new object[,]
                {
                    { 2, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Assigned", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 3, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Querying", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 4, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Supplier Sourced", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 5, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Pricing agreed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 1, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "New", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 6, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Submitted For Approval", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "PackageType", "Sequence", "UpdaterId" },
                values: new object[,]
                {
                    { 4, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nursing Care Package", 0, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 3, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Day Care Package", 0, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 1, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Home Care Package", 0, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 2, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Residential Care Package", 0, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
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
                    { 2, "CCG" },
                    { 1, "NHS" }
                });

            migrationBuilder.InsertData(
                table: "ResidentialCareTypeOfStayOptions",
                columns: new[] { "TypeOfStayOptionId", "OptionName", "OptionPeriod" },
                values: new object[,]
                {
                    { 3, "Long Term", "52+ weeks" },
                    { 1, "Interim", "Under 6 weeks" },
                    { 2, "Temporary", "Expected under 52 weeks" }
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
                    { 1, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Morning", "08:00 - 10:00", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 2, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Mid Morning", "10:00 - 12:00", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 3, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Lunch", "12:00 - 14:00", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 4, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Afternoon", "14:00 - 17:00", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 5, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Evening", "17:00 - 20:00", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 6, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Night", "20:00 - 22:00", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
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
                table: "FundedNursingCareCollectors",
                columns: new[] { "Id", "ClaimedBy", "OptionInvoiceName", "OptionName" },
                values: new object[,]
                {
                    { 2, 2, "Funded Nursing Care", "FNC Collected by Hackney" },
                    { 1, 1, "FNC Claimed By Supplier", "FNC Collected by Supplier" }
                });

            migrationBuilder.InsertData(
                table: "HomeCareServiceTypeMinutes",
                columns: new[] { "Id", "HomeCareServiceTypeId", "IsSecondaryCarer", "Label", "Minutes" },
                values: new object[,]
                {
                    { 22, 2, false, "2 hours", 120 },
                    { 23, 3, false, "30 minutes", 30 },
                    { 24, 3, false, "45 minutes", 45 },
                    { 25, 3, false, "1 hour", 60 },
                    { 26, 3, false, "1 hour 15 minutes", 75 },
                    { 27, 3, false, "1 hour 30 minutes", 90 },
                    { 28, 3, false, "1 hour 45 minutes", 105 },
                    { 29, 3, false, "2 hours", 120 },
                    { 31, 4, false, "45 minutes", 45 },
                    { 32, 4, false, "1 hour", 60 },
                    { 33, 4, false, "1 hour 15 minutes", 75 },
                    { 34, 4, false, "1 hour 30 minutes", 90 },
                    { 35, 4, false, "1 hour 45 minutes", 105 },
                    { 36, 4, false, "2 hours", 120 },
                    { 30, 4, false, "30 minutes", 30 },
                    { 20, 2, false, "1 hour 30 minutes", 90 },
                    { 21, 2, false, "1 hour 45 minutes", 105 },
                    { 18, 2, false, "1 hour", 60 },
                    { 2, 1, false, "45 minutes", 45 },
                    { 3, 1, false, "1 hour", 60 },
                    { 4, 1, false, "1 hour 15 minutes", 75 },
                    { 5, 1, false, "1 hour 30 minutes", 90 },
                    { 6, 1, false, "1 hour 45 minutes", 105 },
                    { 7, 1, false, "2 hours", 120 },
                    { 19, 2, false, "1 hour 15 minutes", 75 },
                    { 9, 1, true, "30 minutes", 30 },
                    { 8, 1, true, "N/A", 0 },
                    { 11, 1, true, "1 hour", 60 },
                    { 12, 1, true, "1 hour 15 minutes", 75 },
                    { 13, 1, true, "1 hour 30 minutes", 90 },
                    { 14, 1, true, "1 hour 45 minutes", 105 },
                    { 15, 1, true, "2 hours", 120 },
                    { 16, 2, false, "30 minutes", 30 },
                    { 17, 2, false, "45 minutes", 45 },
                    { 10, 1, true, "45 minutes", 45 },
                    { 1, 1, false, "30 minutes", 30 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlotShifts",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "LinkedToHomeCareServiceTypeId", "TimeSlotShiftName", "TimeSlotTimeLabel", "UpdaterId" },
                values: new object[,]
                {
                    { 7, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, "Night Owl", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 8, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, "Waking Nights", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 9, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, "Sleeping Nights", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
                });
#pragma warning restore CA1814

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_FundedNursingCareCollectorId",
                table: "Suppliers",
                column: "FundedNursingCareCollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PackageTypeId",
                table: "Suppliers",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_CareChargeId",
                table: "CareChargeElements",
                column: "CareChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_ClaimCollectorId",
                table: "CareChargeElements",
                column: "ClaimCollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_CreatorId",
                table: "CareChargeElements",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_StatusId",
                table: "CareChargeElements",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_TypeId",
                table: "CareChargeElements",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_UpdaterId",
                table: "CareChargeElements",
                column: "UpdaterId");

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
                name: "IX_DayCareApprovalHistory_UpdaterId",
                table: "DayCareApprovalHistory",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareBrokerageInfo_CorePackageSupplierId",
                table: "DayCareBrokerageInfo",
                column: "CorePackageSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareBrokerageInfo_CreatorId",
                table: "DayCareBrokerageInfo",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareBrokerageInfo_DayCareOpportunitiesSupplierId",
                table: "DayCareBrokerageInfo",
                column: "DayCareOpportunitiesSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareBrokerageInfo_DayCarePackageId",
                table: "DayCareBrokerageInfo",
                column: "DayCarePackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayCareBrokerageInfo_EscortSupplierId",
                table: "DayCareBrokerageInfo",
                column: "EscortSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareBrokerageInfo_TransportEscortSupplierId",
                table: "DayCareBrokerageInfo",
                column: "TransportEscortSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareBrokerageInfo_TransportSupplierId",
                table: "DayCareBrokerageInfo",
                column: "TransportSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareBrokerageInfo_UpdaterId",
                table: "DayCareBrokerageInfo",
                column: "UpdaterId");

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
                name: "IX_DayCarePackageReclaims_CreatorId",
                table: "DayCarePackageReclaims",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageReclaims_DayCarePackageId",
                table: "DayCarePackageReclaims",
                column: "DayCarePackageId");

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
                name: "IX_DayCarePackageReclaims_UpdaterId",
                table: "DayCarePackageReclaims",
                column: "UpdaterId");

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
                name: "IX_EscortPackages_ClientId",
                table: "EscortPackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_EscortPackages_CreatorId",
                table: "EscortPackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_EscortPackages_DayCarePackageId",
                table: "EscortPackages",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_EscortPackages_SupplierId",
                table: "EscortPackages",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_EscortPackages_UpdaterId",
                table: "EscortPackages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_FundedNursingCareCollectors_ClaimedBy",
                table: "FundedNursingCareCollectors",
                column: "ClaimedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FundedNursingCares_CollectorId",
                table: "FundedNursingCares",
                column: "CollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_FundedNursingCares_NursingCarePackageId",
                table: "FundedNursingCares",
                column: "NursingCarePackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FundedNursingCares_ReclaimTargetInstitutionId",
                table: "FundedNursingCares",
                column: "ReclaimTargetInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareApprovalHistories_HomeCarePackageId",
                table: "HomeCareApprovalHistories",
                column: "HomeCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareApprovalHistories_UserId",
                table: "HomeCareApprovalHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_ClientId",
                table: "HomeCarePackage",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_CreatorId",
                table: "HomeCarePackage",
                column: "CreatorId");

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
                name: "IX_HomeCarePackage_UpdaterId",
                table: "HomeCarePackage",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_CarerTypeId",
                table: "HomeCarePackageCosts",
                column: "CarerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_CreatorId",
                table: "HomeCarePackageCosts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_HomeCareServiceTypeId",
                table: "HomeCarePackageCosts",
                column: "HomeCareServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_UpdaterId",
                table: "HomeCarePackageCosts",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageReclaims_CreatorId",
                table: "HomeCarePackageReclaims",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageReclaims_HomeCarePackageId",
                table: "HomeCarePackageReclaims",
                column: "HomeCarePackageId");

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
                name: "IX_HomeCarePackageReclaims_UpdaterId",
                table: "HomeCarePackageReclaims",
                column: "UpdaterId");

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
                name: "IX_HomeCareServiceTypes_CreatorId",
                table: "HomeCareServiceTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareServiceTypes_UpdaterId",
                table: "HomeCareServiceTypes",
                column: "UpdaterId");

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
                name: "IX_HomeCareSupplierCosts_CreatorId",
                table: "HomeCareSupplierCosts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareSupplierCosts_HomeCareServiceTypeId",
                table: "HomeCareSupplierCosts",
                column: "HomeCareServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareSupplierCosts_UpdaterId",
                table: "HomeCareSupplierCosts",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_CareChargeElementId",
                table: "InvoiceCreditNotes",
                column: "CareChargeElementId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_ChargeTypeId",
                table: "InvoiceCreditNotes",
                column: "ChargeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_ClaimCollectorId",
                table: "InvoiceCreditNotes",
                column: "ClaimCollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_CreatorId",
                table: "InvoiceCreditNotes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_PackageTypeId",
                table: "InvoiceCreditNotes",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_PriceEffectId",
                table: "InvoiceCreditNotes",
                column: "PriceEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_ServiceUserId",
                table: "InvoiceCreditNotes",
                column: "ServiceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_SupplierId",
                table: "InvoiceCreditNotes",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCreditNotes_UpdaterId",
                table: "InvoiceCreditNotes",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeeds_AdditionalNeedsPaymentTypeId",
                table: "NursingCareAdditionalNeeds",
                column: "AdditionalNeedsPaymentTypeId");

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
                name: "IX_NursingCareAdditionalNeedsCosts_AdditionalNeedsPaymentTypeId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "AdditionalNeedsPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_CreatorId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_NursingCareBrokerageId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "NursingCareBrokerageId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_UpdaterId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareApprovalHistories_CreatorId",
                table: "NursingCareApprovalHistories",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareApprovalHistories_NursingCarePackageId",
                table: "NursingCareApprovalHistories",
                column: "NursingCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareApprovalHistories_UpdaterId",
                table: "NursingCareApprovalHistories",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareBrokerageInfos_CreatorId",
                table: "NursingCareBrokerageInfos",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareBrokerageInfos_NursingCarePackageId",
                table: "NursingCareBrokerageInfos",
                column: "NursingCarePackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareBrokerageInfos_UpdaterId",
                table: "NursingCareBrokerageInfos",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageReclaims_CreatorId",
                table: "NursingCarePackageReclaims",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageReclaims_NursingCarePackageId",
                table: "NursingCarePackageReclaims",
                column: "NursingCarePackageId");

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

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageReclaims_UpdaterId",
                table: "NursingCarePackageReclaims",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_AssignedUserId",
                table: "NursingCarePackages",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_CareChargeId",
                table: "NursingCarePackages",
                column: "CareChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_ClientId",
                table: "NursingCarePackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_CreatorId",
                table: "NursingCarePackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_StageId",
                table: "NursingCarePackages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_StatusId",
                table: "NursingCarePackages",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_SupplierId",
                table: "NursingCarePackages",
                column: "SupplierId");

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
                name: "IX_PackageCareCharges_CreatorId",
                table: "PackageCareCharges",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageCareCharges_PackageTypeId",
                table: "PackageCareCharges",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageCareCharges_ServiceUserId",
                table: "PackageCareCharges",
                column: "ServiceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageCareCharges_SupplierId",
                table: "PackageCareCharges",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageCareCharges_UpdaterId",
                table: "PackageCareCharges",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CreatorId",
                table: "Packages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_UpdaterId",
                table: "Packages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageStages_CreatorId",
                table: "PackageStages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageStages_UpdaterId",
                table: "PackageStages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeeds_AdditionalNeedsPaymentTypeId",
                table: "ResidentialCareAdditionalNeeds",
                column: "AdditionalNeedsPaymentTypeId");

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
                name: "IX_ResidentialCareAdditionalNeedsCosts_AdditionalNeedsPaymentT~",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "AdditionalNeedsPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_CreatorId",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_ResidentialCareBrokerag~",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "ResidentialCareBrokerageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_UpdaterId",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareApprovalHistories_CreatorId",
                table: "ResidentialCareApprovalHistories",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareApprovalHistories_ResidentialCarePackageId",
                table: "ResidentialCareApprovalHistories",
                column: "ResidentialCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareApprovalHistories_UpdaterId",
                table: "ResidentialCareApprovalHistories",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareBrokerageInfos_CreatorId",
                table: "ResidentialCareBrokerageInfos",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareBrokerageInfos_ResidentialCarePackageId",
                table: "ResidentialCareBrokerageInfos",
                column: "ResidentialCarePackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareBrokerageInfos_UpdaterId",
                table: "ResidentialCareBrokerageInfos",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageReclaims_CreatorId",
                table: "ResidentialCarePackageReclaims",
                column: "CreatorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageReclaims_ResidentialCarePackageId",
                table: "ResidentialCarePackageReclaims",
                column: "ResidentialCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageReclaims_UpdaterId",
                table: "ResidentialCarePackageReclaims",
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
                name: "IX_ResidentialCarePackages_StageId",
                table: "ResidentialCarePackages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackages_StatusId",
                table: "ResidentialCarePackages",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackages_SupplierId",
                table: "ResidentialCarePackages",
                column: "SupplierId");

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
                name: "IX_TermTimeConsiderationOptions_OptionName",
                table: "TermTimeConsiderationOptions",
                column: "OptionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotShifts_CreatorId",
                table: "TimeSlotShifts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotShifts_LinkedToHomeCareServiceTypeId",
                table: "TimeSlotShifts",
                column: "LinkedToHomeCareServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotShifts_UpdaterId",
                table: "TimeSlotShifts",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEscortPackages_ClientId",
                table: "TransportEscortPackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEscortPackages_CreatorId",
                table: "TransportEscortPackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEscortPackages_DayCarePackageId",
                table: "TransportEscortPackages",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEscortPackages_SupplierId",
                table: "TransportEscortPackages",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEscortPackages_UpdaterId",
                table: "TransportEscortPackages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportPackages_ClientId",
                table: "TransportPackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportPackages_CreatorId",
                table: "TransportPackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportPackages_DayCarePackageId",
                table: "TransportPackages",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportPackages_SupplierId",
                table: "TransportPackages",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportPackages_UpdaterId",
                table: "TransportPackages",
                column: "UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_FundedNursingCareCollectors_FundedNursingCareColl~",
                table: "Suppliers",
                column: "FundedNursingCareCollectorId",
                principalTable: "FundedNursingCareCollectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Packages_PackageTypeId",
                table: "Suppliers",
                column: "PackageTypeId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
