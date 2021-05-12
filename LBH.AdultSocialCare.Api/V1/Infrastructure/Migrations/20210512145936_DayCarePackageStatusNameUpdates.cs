using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class DayCarePackageStatusNameUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 895, DateTimeKind.Unspecified).AddTicks(6579), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 895, DateTimeKind.Unspecified).AddTicks(6586), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 900, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 900, DateTimeKind.Unspecified).AddTicks(5662), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 900, DateTimeKind.Unspecified).AddTicks(9919), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 900, DateTimeKind.Unspecified).AddTicks(9931), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated", "StatusName" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(56), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(58), new TimeSpan(0, 0, 0, 0, 0)), "Contents Approved" });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(67), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(69), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated", "StatusName" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(75), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(76), new TimeSpan(0, 0, 0, 0, 0)), "Clarification Needed" });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(82), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(83), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(89), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(91), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(98), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(99), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(106), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(108), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(115), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(116), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(123), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(125), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 12,
                columns: new[] { "DateCreated", "DateUpdated", "StatusName" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(132), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(134), new TimeSpan(0, 0, 0, 0, 0)), "Commercials Approved" });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 13,
                columns: new[] { "DateCreated", "DateUpdated", "StatusName" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(140), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(141), new TimeSpan(0, 0, 0, 0, 0)), "Package Commercials - Rejected" });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 14,
                columns: new[] { "DateCreated", "DateUpdated", "StatusName" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(147), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(148), new TimeSpan(0, 0, 0, 0, 0)), "Clarifying Commercials" });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 15,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(154), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 901, DateTimeKind.Unspecified).AddTicks(155), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(617), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2049), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2338), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2369), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2377), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2380), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2381), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2383), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2385), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2387), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2388), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2390), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2391), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 886, DateTimeKind.Unspecified).AddTicks(2393), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(1702), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(1711), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3224), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3232), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3290), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3292), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3296), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3297), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3300), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3301), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3305), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3306), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3309), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(5956), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(5964), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(6940), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(6945), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(6973), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(6974), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(6976), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(6977), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(9305), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 893, DateTimeKind.Unspecified).AddTicks(9312), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 894, DateTimeKind.Unspecified).AddTicks(723), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 894, DateTimeKind.Unspecified).AddTicks(729), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 896, DateTimeKind.Unspecified).AddTicks(6932), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 896, DateTimeKind.Unspecified).AddTicks(6939), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(4473), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(4483), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5722), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5727), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5763), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5764), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5766), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5768), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5770), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5771), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5773), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(5774), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(6081), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(6086), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(6098), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 892, DateTimeKind.Unspecified).AddTicks(6099), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 895, DateTimeKind.Unspecified).AddTicks(1686), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 895, DateTimeKind.Unspecified).AddTicks(1692), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 894, DateTimeKind.Unspecified).AddTicks(9403), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 12, 14, 59, 35, 894, DateTimeKind.Unspecified).AddTicks(9412), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 264, DateTimeKind.Unspecified).AddTicks(4208), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 264, DateTimeKind.Unspecified).AddTicks(4216), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(4878), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(4889), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7624), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7632), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated", "StatusName" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7698), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7699), new TimeSpan(0, 0, 0, 0, 0)), "Approve Package" });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7704), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7705), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated", "StatusName" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7709), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7710), new TimeSpan(0, 0, 0, 0, 0)), "Request More Information" });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7714), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7715), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7719), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7720), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7724), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7729), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7730), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7734), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7735), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7738), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7739), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 12,
                columns: new[] { "DateCreated", "DateUpdated", "StatusName" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7743), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 0, 0, 0, 0)), "Brokerage Approval - Approved" });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 13,
                columns: new[] { "DateCreated", "DateUpdated", "StatusName" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7748), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7749), new TimeSpan(0, 0, 0, 0, 0)), "Brokerage Approval - Rejected" });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 14,
                columns: new[] { "DateCreated", "DateUpdated", "StatusName" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7753), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7754), new TimeSpan(0, 0, 0, 0, 0)), "Brokerage Approval - Request more information" });

            migrationBuilder.UpdateData(
                table: "DayCarePackageStatuses",
                keyColumn: "PackageStatusId",
                keyValue: 15,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 268, DateTimeKind.Unspecified).AddTicks(7759), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(4757), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6261), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6574), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6612), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6620), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6622), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6623), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6625), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6627), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6629), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6630), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6632), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6633), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 254, DateTimeKind.Unspecified).AddTicks(6635), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(9066), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(9075), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1039), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1046), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1101), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1103), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1107), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1108), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1111), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1113), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1116), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1117), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1121), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(1122), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(3798), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(3804), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(5033), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(5038), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(5083), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(5085), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(5087), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(5087), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(7385), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(7393), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(9526), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 262, DateTimeKind.Unspecified).AddTicks(9531), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 265, DateTimeKind.Unspecified).AddTicks(4895), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 265, DateTimeKind.Unspecified).AddTicks(4903), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 260, DateTimeKind.Unspecified).AddTicks(9714), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 260, DateTimeKind.Unspecified).AddTicks(9726), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1069), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1074), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1109), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1110), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1112), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1113), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1114), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1115), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1117), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1118), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1119), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1120), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1431), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1435), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1448), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 261, DateTimeKind.Unspecified).AddTicks(1449), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 264, DateTimeKind.Unspecified).AddTicks(1518), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 264, DateTimeKind.Unspecified).AddTicks(1523), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 263, DateTimeKind.Unspecified).AddTicks(9269), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 11, 10, 48, 57, 263, DateTimeKind.Unspecified).AddTicks(9277), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
