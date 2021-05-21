using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class PackageReclaimsUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 207, DateTimeKind.Unspecified).AddTicks(4242), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 207, DateTimeKind.Unspecified).AddTicks(4254), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 217, DateTimeKind.Unspecified).AddTicks(8611), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 217, DateTimeKind.Unspecified).AddTicks(8644), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(3978), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(3985), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4107), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4110), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4117), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4119), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4125), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4127), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4134), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4135), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4142), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4143), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4150), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4152), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4158), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4159), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4166), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4168), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4174), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4176), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 12,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4182), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4183), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 13,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4190), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4191), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 14,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4198), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4199), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 15,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4206), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 218, DateTimeKind.Unspecified).AddTicks(4208), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(4779), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(7755), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8464), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8523), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8541), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8545), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8547), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8550), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8552), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8555), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8557), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8562), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8564), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 143, DateTimeKind.Unspecified).AddTicks(8567), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 202, DateTimeKind.Unspecified).AddTicks(9707), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 202, DateTimeKind.Unspecified).AddTicks(9736), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(2838), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(2848), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(2938), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3011), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3013), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3022), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3029), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3031), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3037), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3039), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3045), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3046), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3053), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3055), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3062), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(3070), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(8704), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 203, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 204, DateTimeKind.Unspecified).AddTicks(982), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 204, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 204, DateTimeKind.Unspecified).AddTicks(1037), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 204, DateTimeKind.Unspecified).AddTicks(1039), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 204, DateTimeKind.Unspecified).AddTicks(1041), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 204, DateTimeKind.Unspecified).AddTicks(1043), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 204, DateTimeKind.Unspecified).AddTicks(5532), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 204, DateTimeKind.Unspecified).AddTicks(5541), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 204, DateTimeKind.Unspecified).AddTicks(8753), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 204, DateTimeKind.Unspecified).AddTicks(8762), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 209, DateTimeKind.Unspecified).AddTicks(5379), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 209, DateTimeKind.Unspecified).AddTicks(5402), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(1649), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(1683), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4546), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4562), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4626), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4628), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4631), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4633), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4636), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4639), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4643), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(4644), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(5297), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(5303), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(5326), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 201, DateTimeKind.Unspecified).AddTicks(5328), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 206, DateTimeKind.Unspecified).AddTicks(9064), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 206, DateTimeKind.Unspecified).AddTicks(9072), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 206, DateTimeKind.Unspecified).AddTicks(4465), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 20, 12, 24, 55, 206, DateTimeKind.Unspecified).AddTicks(4488), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
