using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class PackageReclaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReclaimAmountOptions",
                columns: table => new
                {
                    AmountOptionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AmountOptionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimAmountOptions", x => x.AmountOptionId);
                });

            migrationBuilder.CreateTable(
                name: "ReclaimCategories",
                columns: table => new
                {
                    ReclaimCategoryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReclaimCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimCategories", x => x.ReclaimCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ReclaimFroms",
                columns: table => new
                {
                    ReclaimFromId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReclaimFromName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclaimFroms", x => x.ReclaimFromId);
                });

            migrationBuilder.CreateTable(
                name: "DayCarePackageReclaims",
                columns: table => new
                {
                    DayCarePackageReclaimId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    DayCarePackageId = table.Column<Guid>(nullable: false),
                    ReclaimFromId = table.Column<int>(nullable: false),
                    ReclaimCategoryId = table.Column<int>(nullable: false),
                    ReclaimAmountOptionId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCarePackageReclaims", x => x.DayCarePackageReclaimId);
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
                });

            migrationBuilder.CreateTable(
                name: "HomeCarePackageReclaims",
                columns: table => new
                {
                    HomeCarePackageReclaimId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    HomeCarePackageId = table.Column<Guid>(nullable: false),
                    ReclaimFromId = table.Column<int>(nullable: false),
                    ReclaimCategoryId = table.Column<int>(nullable: false),
                    ReclaimAmountOptionId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarePackageReclaims", x => x.HomeCarePackageReclaimId);
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
                });

            migrationBuilder.CreateTable(
                name: "NursingCarePackageReclaims",
                columns: table => new
                {
                    NursingCarePackageReclaimId = table.Column<Guid>(nullable: false),
                    NursingCarePackageId = table.Column<Guid>(nullable: false),
                    ReclaimFromId = table.Column<int>(nullable: false),
                    ReclaimCategoryId = table.Column<int>(nullable: false),
                    ReclaimAmountOptionId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCarePackageReclaims", x => x.NursingCarePackageReclaimId);
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
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 280, DateTimeKind.Unspecified).AddTicks(9285), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 280, DateTimeKind.Unspecified).AddTicks(9292), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(1244), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5474), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5476), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5482), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5487), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5493), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5498), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5499), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5503), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5504), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5508), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5509), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5514), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5515), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5519), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5520), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 12,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5524), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5525), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 13,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5530), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5531), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 14,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5535), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5536), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 15,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 285, DateTimeKind.Unspecified).AddTicks(5542), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(5943), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8242), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8705), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8740), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8751), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8752), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8754), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8755), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8757), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8759), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8761), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8762), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 222, DateTimeKind.Unspecified).AddTicks(8764), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(9029), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(9037), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1229), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1236), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1292), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1293), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1298), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1299), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1303), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1304), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1308), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1309), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1349), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1350), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1355), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1356), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1360), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1362), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1365), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1367), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(1371), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(4692), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(4699), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(6286), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(6291), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(6324), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(6325), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(6326), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(6327), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "ReclaimAmountOptions",
                columns: new[] { "AmountOptionId", "AmountOptionName" },
                values: new object[,]
                {
                    { 2, "Fixed amount - one off" },
                    { 3, "Fixed amount - weekly" },
                    { 1, "Percentage" }
                });

            migrationBuilder.InsertData(
                table: "ReclaimCategories",
                columns: new[] { "ReclaimCategoryId", "ReclaimCategoryName" },
                values: new object[,]
                {
                    { 2, "Option 2" },
                    { 1, "Option 1" }
                });

            migrationBuilder.InsertData(
                table: "ReclaimFroms",
                columns: new[] { "ReclaimFromId", "ReclaimFromName" },
                values: new object[,]
                {
                    { 2, "CCG" },
                    { 1, "NHS" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 278, DateTimeKind.Unspecified).AddTicks(9180), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 279, DateTimeKind.Unspecified).AddTicks(1745), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 279, DateTimeKind.Unspecified).AddTicks(1753), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 282, DateTimeKind.Unspecified).AddTicks(3668), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 282, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 276, DateTimeKind.Unspecified).AddTicks(8023), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 276, DateTimeKind.Unspecified).AddTicks(8049), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(192), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(198), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(237), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(239), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(241), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(242), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(243), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(244), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(246), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(247), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(248), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(249), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(707), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(712), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(727), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 277, DateTimeKind.Unspecified).AddTicks(728), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 280, DateTimeKind.Unspecified).AddTicks(5949), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 280, DateTimeKind.Unspecified).AddTicks(5954), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 280, DateTimeKind.Unspecified).AddTicks(2748), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 15, 7, 280, DateTimeKind.Unspecified).AddTicks(2759), new TimeSpan(0, 0, 0, 0, 0)) });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "HomeCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "NursingCarePackageReclaims");

            migrationBuilder.DropTable(
                name: "ReclaimAmountOptions");

            migrationBuilder.DropTable(
                name: "ReclaimCategories");

            migrationBuilder.DropTable(
                name: "ReclaimFroms");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(6805), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(6812), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(1168), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(1177), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3678), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3683), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3753), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3758), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3759), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3763), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3764), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3768), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3769), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3773), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3774), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3778), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3778), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3782), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3783), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3787), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3788), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3792), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3793), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 12,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3797), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3798), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 13,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3905), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3906), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 14,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3911), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3912), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 15,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3916), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 466, DateTimeKind.Unspecified).AddTicks(3917), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(17), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1821), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1861), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1863), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1865), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1867), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1868), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1870), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1873), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1875), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 452, DateTimeKind.Unspecified).AddTicks(1877), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(3272), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(3282), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4892), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4898), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4951), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4952), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4957), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4958), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4961), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4962), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4966), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4967), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4971), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4972), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4975), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4976), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4980), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4981), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4985), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4986), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4990), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(4991), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(7672), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(7680), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8704), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8709), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8745), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8746), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8747), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 460, DateTimeKind.Unspecified).AddTicks(8748), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 461, DateTimeKind.Unspecified).AddTicks(1039), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 461, DateTimeKind.Unspecified).AddTicks(1045), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 461, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 461, DateTimeKind.Unspecified).AddTicks(2484), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 463, DateTimeKind.Unspecified).AddTicks(7891), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 463, DateTimeKind.Unspecified).AddTicks(7899), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(3990), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(4014), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5618), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5625), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5666), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5667), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5669), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5672), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5674), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5676), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(5677), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(6018), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(6022), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(6037), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 459, DateTimeKind.Unspecified).AddTicks(6038), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(3787), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(1675), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 13, 10, 59, 9, 462, DateTimeKind.Unspecified).AddTicks(1683), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
