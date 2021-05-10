using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class HomeCarePackageBrokerageUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackageCosts_HomeCareServiceTypes_ServiceId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackageCosts_ServiceId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropColumn(
                name: "PrimaryCarer",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropColumn(
                name: "SecondaryCarer",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "HomeCarePackageCosts");

            migrationBuilder.AddColumn<int>(
                name: "CarerTypeId",
                table: "HomeCarePackageCosts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeCareServiceTypeId",
                table: "HomeCarePackageCosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSecondaryCarer",
                table: "HomeCarePackageCosts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "HomeCarePackage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "HomeCarePackage",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarerTypes",
                columns: table => new
                {
                    CarerTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarerTypeMinutes = table.Column<int>(nullable: false),
                    CarerTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarerTypes", x => x.CarerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "HomeCareApprovalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "HomeCareStages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 538, DateTimeKind.Unspecified).AddTicks(7735), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 538, DateTimeKind.Unspecified).AddTicks(7743), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(2894), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5324), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5797), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5834), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5843), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5845), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5846), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5851), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5852), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5854), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5856), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5858), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5860), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 526, DateTimeKind.Unspecified).AddTicks(5862), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6757), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6764), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6827), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6828), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6832), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6837), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6838), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6842), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6843), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6883), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 535, DateTimeKind.Unspecified).AddTicks(6884), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(260), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(1872), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(1879), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(1958), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(1959), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(1961), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(1962), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(5039), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(5047), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(7444), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 536, DateTimeKind.Unspecified).AddTicks(7450), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "HasSupplierFrameworkContractedRates", "IsSupplierInternal", "PackageTypeId", "SupplierName", "UpdatorId" },
                values: new object[] { 1, 0, new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 540, DateTimeKind.Unspecified).AddTicks(2299), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 540, DateTimeKind.Unspecified).AddTicks(2307), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "Furkan", 0 });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(5409), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(5438), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7486), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7492), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7532), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7533), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7535), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7536), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7537), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7538), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7540), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7541), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7542), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(7543), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(8010), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(8015), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(8029), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 534, DateTimeKind.Unspecified).AddTicks(8030), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 538, DateTimeKind.Unspecified).AddTicks(4370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 538, DateTimeKind.Unspecified).AddTicks(4376), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 538, DateTimeKind.Unspecified).AddTicks(1110), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 6, 10, 2, 2, 538, DateTimeKind.Unspecified).AddTicks(1122), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_CarerTypeId",
                table: "HomeCarePackageCosts",
                column: "CarerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_HomeCareServiceTypeId",
                table: "HomeCarePackageCosts",
                column: "HomeCareServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_StageId",
                table: "HomeCarePackage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_SupplierId",
                table: "HomeCarePackage",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareStages_CreatorId",
                table: "HomeCareStages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareStages_UpdaterId",
                table: "HomeCareStages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PackageTypeId",
                table: "Suppliers",
                column: "PackageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackage_HomeCareStages_StageId",
                table: "HomeCarePackage",
                column: "StageId",
                principalTable: "HomeCareStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackage_Suppliers_SupplierId",
                table: "HomeCarePackage",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackageCosts_CarerTypes_CarerTypeId",
                table: "HomeCarePackageCosts",
                column: "CarerTypeId",
                principalTable: "CarerTypes",
                principalColumn: "CarerTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackageCosts_HomeCareServiceTypes_HomeCareServiceTypeId",
                table: "HomeCarePackageCosts",
                column: "HomeCareServiceTypeId",
                principalTable: "HomeCareServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackage_HomeCareStages_StageId",
                table: "HomeCarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackage_Suppliers_SupplierId",
                table: "HomeCarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackageCosts_CarerTypes_CarerTypeId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackageCosts_HomeCareServiceTypes_HomeCareServiceTypeId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropTable(
                name: "CarerTypes");

            migrationBuilder.DropTable(
                name: "HomeCareApprovalHistories");

            migrationBuilder.DropTable(
                name: "HomeCareStages");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackageCosts_CarerTypeId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackageCosts_HomeCareServiceTypeId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackage_StageId",
                table: "HomeCarePackage");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackage_SupplierId",
                table: "HomeCarePackage");

            migrationBuilder.DropColumn(
                name: "CarerTypeId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropColumn(
                name: "HomeCareServiceTypeId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropColumn(
                name: "IsSecondaryCarer",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "HomeCarePackage");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "HomeCarePackage");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryCarer",
                table: "HomeCarePackageCosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryCarer",
                table: "HomeCarePackageCosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "HomeCarePackageCosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 877, DateTimeKind.Unspecified).AddTicks(1585), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 877, DateTimeKind.Unspecified).AddTicks(1594), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(2112), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(6572), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7517), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7593), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7600), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7603), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7605), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7609), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7611), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7614), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7616), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 852, DateTimeKind.Unspecified).AddTicks(7619), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 870, DateTimeKind.Unspecified).AddTicks(8350), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 870, DateTimeKind.Unspecified).AddTicks(8378), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6500), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6526), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6648), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6651), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6661), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6672), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6674), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6681), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6682), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6689), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 871, DateTimeKind.Unspecified).AddTicks(6691), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 872, DateTimeKind.Unspecified).AddTicks(4075), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 872, DateTimeKind.Unspecified).AddTicks(4095), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 872, DateTimeKind.Unspecified).AddTicks(7433), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 872, DateTimeKind.Unspecified).AddTicks(7450), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 872, DateTimeKind.Unspecified).AddTicks(7514), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 872, DateTimeKind.Unspecified).AddTicks(7516), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 872, DateTimeKind.Unspecified).AddTicks(7519), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 872, DateTimeKind.Unspecified).AddTicks(7521), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 873, DateTimeKind.Unspecified).AddTicks(3461), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 873, DateTimeKind.Unspecified).AddTicks(3480), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 873, DateTimeKind.Unspecified).AddTicks(8585), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 873, DateTimeKind.Unspecified).AddTicks(8600), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 868, DateTimeKind.Unspecified).AddTicks(8431), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 868, DateTimeKind.Unspecified).AddTicks(8469), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3037), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3114), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3117), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3122), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3124), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3129), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3131), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3134), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(3136), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(4088), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(4100), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(4127), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 869, DateTimeKind.Unspecified).AddTicks(4129), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 876, DateTimeKind.Unspecified).AddTicks(7248), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 876, DateTimeKind.Unspecified).AddTicks(7256), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 876, DateTimeKind.Unspecified).AddTicks(2510), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 27, 13, 25, 53, 876, DateTimeKind.Unspecified).AddTicks(2550), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_ServiceId",
                table: "HomeCarePackageCosts",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackageCosts_HomeCareServiceTypes_ServiceId",
                table: "HomeCarePackageCosts",
                column: "ServiceId",
                principalTable: "HomeCareServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
