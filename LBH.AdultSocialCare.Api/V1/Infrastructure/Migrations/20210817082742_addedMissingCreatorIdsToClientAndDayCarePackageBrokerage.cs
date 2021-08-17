using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class addedMissingCreatorIdsToClientAndDayCarePackageBrokerage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TransportPackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TransportEscortPackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TimeSlotShifts",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Suppliers",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackageReclaims",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareBrokerageInfos",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareAdditionalNeeds",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "PackageStatuses",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Packages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackageReclaims",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareBrokerageInfos",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareAdditionalNeeds",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareSupplierCosts",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareStages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareServiceTypes",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackageReclaims",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackageCosts",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackage",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "EscortPackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackageStatuses",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackageReclaims",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareColleges",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "DayCareBrokerageInfo",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "DayCareBrokerageInfo",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "DayCareBrokerageInfo",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "DayCareBrokerageInfo",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareApprovalHistory",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Clients",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("2f043f6f-09ed-42f0-ab30-c0409c05cb7e"),
                column: "CreatorId",
                value: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                column: "CreatorId",
                value: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(1355), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2086), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2091), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2152), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2154), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2158), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2159), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2163), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2164), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2168), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2169), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_DayCareBrokerageInfo_CreatorId",
                table: "DayCareBrokerageInfo",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareBrokerageInfo_UpdaterId",
                table: "DayCareBrokerageInfo",
                column: "UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareBrokerageInfo_AspNetUsers_CreatorId",
                table: "DayCareBrokerageInfo",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareBrokerageInfo_AspNetUsers_UpdaterId",
                table: "DayCareBrokerageInfo",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayCareBrokerageInfo_AspNetUsers_CreatorId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareBrokerageInfo_AspNetUsers_UpdaterId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropIndex(
                name: "IX_DayCareBrokerageInfo_CreatorId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropIndex(
                name: "IX_DayCareBrokerageInfo_UpdaterId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TransportPackages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TransportEscortPackages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TimeSlotShifts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Suppliers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackageReclaims",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareBrokerageInfos",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareAdditionalNeeds",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "PackageStatuses",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Packages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackageReclaims",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareBrokerageInfos",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareAdditionalNeeds",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareSupplierCosts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareStages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareServiceTypes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackageReclaims",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackageCosts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackage",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "EscortPackages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackageStatuses",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackageReclaims",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareColleges",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareApprovalHistory",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Clients",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("2f043f6f-09ed-42f0-ab30-c0409c05cb7e"),
                column: "CreatorId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                column: "CreatorId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(4271), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(4283), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(5190), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(5200), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(5326), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(5334), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(5343), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(5344), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(5353), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(5355), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(5359), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 14, 17, 13, 795, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
