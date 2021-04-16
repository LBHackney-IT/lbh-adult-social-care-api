using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class CreateDayCarePackageOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HowLong",
                table: "DayCarePackageOpportunities");

            migrationBuilder.DropColumn(
                name: "HowManyTimesPerMonth",
                table: "DayCarePackageOpportunities");

            migrationBuilder.AlterColumn<string>(
                name: "OptionName",
                table: "TermTimeConsiderationOptions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpportunityLengthOptionId",
                table: "DayCarePackageOpportunities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpportunityTimePerMonthOptionId",
                table: "DayCarePackageOpportunities",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "OpportunityLengthOptions",
                columns: new[] { "OpportunityLengthOptionId", "OptionName", "TimeInMinutes" },
                values: new object[,]
                {
                    { 1, "45 minutes", 45 },
                    { 3, "1 hour 15 minutes", 75 },
                    { 2, "1 hour", 60 }
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

            migrationBuilder.CreateIndex(
                name: "IX_TermTimeConsiderationOptions_OptionName",
                table: "TermTimeConsiderationOptions",
                column: "OptionName",
                unique: true,
                filter: "[OptionName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageOpportunities_OpportunityLengthOptionId",
                table: "DayCarePackageOpportunities",
                column: "OpportunityLengthOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageOpportunities_OpportunityTimePerMonthOptionId",
                table: "DayCarePackageOpportunities",
                column: "OpportunityTimePerMonthOptionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackageOpportunities_OpportunityLengthOptions_OpportunityLengthOptionId",
                table: "DayCarePackageOpportunities",
                column: "OpportunityLengthOptionId",
                principalTable: "OpportunityLengthOptions",
                principalColumn: "OpportunityLengthOptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackageOpportunities_OpportunityTimesPerMonthOptions_OpportunityTimePerMonthOptionId",
                table: "DayCarePackageOpportunities",
                column: "OpportunityTimePerMonthOptionId",
                principalTable: "OpportunityTimesPerMonthOptions",
                principalColumn: "OpportunityTimePerMonthOptionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackageOpportunities_OpportunityLengthOptions_OpportunityLengthOptionId",
                table: "DayCarePackageOpportunities");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackageOpportunities_OpportunityTimesPerMonthOptions_OpportunityTimePerMonthOptionId",
                table: "DayCarePackageOpportunities");

            migrationBuilder.DropTable(
                name: "OpportunityLengthOptions");

            migrationBuilder.DropTable(
                name: "OpportunityTimesPerMonthOptions");

            migrationBuilder.DropIndex(
                name: "IX_TermTimeConsiderationOptions_OptionName",
                table: "TermTimeConsiderationOptions");

            migrationBuilder.DropIndex(
                name: "IX_DayCarePackageOpportunities_OpportunityLengthOptionId",
                table: "DayCarePackageOpportunities");

            migrationBuilder.DropIndex(
                name: "IX_DayCarePackageOpportunities_OpportunityTimePerMonthOptionId",
                table: "DayCarePackageOpportunities");

            migrationBuilder.DropColumn(
                name: "OpportunityLengthOptionId",
                table: "DayCarePackageOpportunities");

            migrationBuilder.DropColumn(
                name: "OpportunityTimePerMonthOptionId",
                table: "DayCarePackageOpportunities");

            migrationBuilder.AlterColumn<string>(
                name: "OptionName",
                table: "TermTimeConsiderationOptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HowLong",
                table: "DayCarePackageOpportunities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HowManyTimesPerMonth",
                table: "DayCarePackageOpportunities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(2829), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4308), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4605), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4643), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4658), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4659), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4661), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4663), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4665), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4666), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4668), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4669), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(4671), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 630, DateTimeKind.Unspecified).AddTicks(9000), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(293), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(298), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(342), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(343), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(345), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(346), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(348), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(349), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(350), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(351), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(352), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(353), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(663), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(667), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(681), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 15, 14, 52, 3, 631, DateTimeKind.Unspecified).AddTicks(682), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
