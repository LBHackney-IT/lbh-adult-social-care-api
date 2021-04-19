using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class HomeCareServiceTypeMinutesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HomeCareServiceTypeMinutes",
                columns: new[] { "Id", "HomeCareServiceTypeId", "IsSecondaryCarer", "Label", "Minutes" },
                values: new object[,]
                {
                    { 1, 1, false, "30 minutes", 30 },
                    { 21, 2, false, "1 hour 45 minutes", 105 },
                    { 22, 2, false, "2 hours", 120 },
                    { 23, 3, false, "30 minutes", 30 },
                    { 24, 3, false, "45 minutes", 45 },
                    { 25, 3, false, "1 hour", 60 },
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
                    { 26, 3, false, "1 hour 15 minutes", 75 },
                    { 17, 2, false, "45 minutes", 45 },
                    { 18, 2, false, "1 hour", 60 },
                    { 3, 1, false, "1 hour", 60 },
                    { 4, 1, false, "1 hour 15 minutes", 75 },
                    { 5, 1, false, "1 hour 30 minutes", 90 },
                    { 6, 1, false, "1 hour 45 minutes", 105 },
                    { 7, 1, false, "2 hours", 120 },
                    { 8, 1, true, "N/A", 0 },
                    { 9, 1, true, "30 minutes", 30 },
                    { 2, 1, false, "45 minutes", 45 },
                    { 11, 1, true, "1 hour", 60 },
                    { 12, 1, true, "1 hour 15 minutes", 75 },
                    { 13, 1, true, "1 hour 30 minutes", 90 },
                    { 14, 1, true, "1 hour 45 minutes", 105 },
                    { 15, 1, true, "2 hours", 120 },
                    { 16, 2, false, "30 minutes", 30 },
                    { 10, 1, true, "45 minutes", 45 }
                });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(7944), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9421), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9721), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9754), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9762), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9766), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9768), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9770), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9772), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9773), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9776), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9777), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 85, DateTimeKind.Unspecified).AddTicks(9779), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(414), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(443), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(1990), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(1997), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2040), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2041), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2043), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2044), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2046), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2047), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2049), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2050), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2051), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2052), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2371), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2375), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2389), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 17, 4, 8, 46, 93, DateTimeKind.Unspecified).AddTicks(2390), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "HomeCareServiceTypeMinutes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 888, DateTimeKind.Unspecified).AddTicks(9085), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(632), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(963), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(999), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(1008), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(1011), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(1012), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(1014), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(1015), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(1017), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(1019), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(1021), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(1022), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(1025), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(5978), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(5987), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7682), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7688), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7743), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7746), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7747), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7748), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7749), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7752), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7753), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(7754), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(8091), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(8096), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(8112), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 13, 23, 19, 889, DateTimeKind.Unspecified).AddTicks(8113), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
