using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class creatorIdAndUpdaterIdMovedToBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayCareBrokerageInfo_AspNetUsers_CreatorId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareBrokerageInfo_AspNetUsers_UpdaterId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareBrokerageInfos_AspNetUsers_UpdatorId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareBrokerageInfos_UpdatorId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropIndex(
                name: "IX_DayCareBrokerageInfo_CreatorId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropIndex(
                name: "IX_DayCareBrokerageInfo_UpdaterId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "TimeSlotShifts");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "HomeCareSupplierCosts");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "HomeCareServiceTypes");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "HomeCarePackage");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "TransportPackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "TransportPackages",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "TransportEscortPackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "TransportEscortPackages",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TimeSlotShifts",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "TimeSlotShifts",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Suppliers",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackageReclaims",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "ResidentialCarePackageReclaims",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareBrokerageInfos",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "ResidentialCareBrokerageInfos",
                nullable: true);

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
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "Packages",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackageReclaims",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "NursingCarePackageReclaims",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareBrokerageInfos",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "NursingCareBrokerageInfos",
                nullable: true);

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
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "HomeCareSupplierCosts",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "HomeCareSupplierCosts",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "HomeCareSupplierCosts",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareStages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "HomeCareStages",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "HomeCareStages",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareServiceTypes",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "HomeCareServiceTypes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackageReclaims",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "HomeCarePackageReclaims",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackageCosts",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "HomeCarePackageCosts",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackage",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "HomeCarePackage",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "EscortPackages",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "EscortPackages",
                nullable: true);

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

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackageReclaims",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "DayCarePackageReclaims",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareColleges",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "DayCareColleges",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "DayCareColleges",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareApprovalHistory",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "DayCareApprovalHistory",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Clients",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "Clients",
                nullable: true);

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
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(3540), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(3547), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(4116), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(4120), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(4166), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(4167), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(4172), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(4175), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(4176), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(4229), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 13, 11, 28, 50, 39, DateTimeKind.Unspecified).AddTicks(4230), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatorId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatorId", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.CreateIndex(
                name: "IX_TransportPackages_CreatorId",
                table: "TransportPackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportPackages_UpdaterId",
                table: "TransportPackages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEscortPackages_CreatorId",
                table: "TransportEscortPackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEscortPackages_UpdaterId",
                table: "TransportEscortPackages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotShifts_CreatorId",
                table: "TimeSlotShifts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotShifts_UpdaterId",
                table: "TimeSlotShifts",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CreatorId",
                table: "Suppliers",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UpdaterId",
                table: "Suppliers",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageReclaims_CreatorId",
                table: "ResidentialCarePackageReclaims",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageReclaims_UpdaterId",
                table: "ResidentialCarePackageReclaims",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareBrokerageInfos_CreatorId",
                table: "ResidentialCareBrokerageInfos",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareBrokerageInfos_UpdaterId",
                table: "ResidentialCareBrokerageInfos",
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
                name: "IX_NursingCarePackageReclaims_CreatorId",
                table: "NursingCarePackageReclaims",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageReclaims_UpdaterId",
                table: "NursingCarePackageReclaims",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareBrokerageInfos_UpdaterId",
                table: "NursingCareBrokerageInfos",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareSupplierCosts_CreatorId",
                table: "HomeCareSupplierCosts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareSupplierCosts_UpdaterId",
                table: "HomeCareSupplierCosts",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareServiceTypes_CreatorId",
                table: "HomeCareServiceTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareServiceTypes_UpdaterId",
                table: "HomeCareServiceTypes",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageReclaims_CreatorId",
                table: "HomeCarePackageReclaims",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageReclaims_UpdaterId",
                table: "HomeCarePackageReclaims",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_CreatorId",
                table: "HomeCarePackageCosts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageCosts_UpdaterId",
                table: "HomeCarePackageCosts",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_CreatorId",
                table: "HomeCarePackage",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackage_UpdaterId",
                table: "HomeCarePackage",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_EscortPackages_CreatorId",
                table: "EscortPackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_EscortPackages_UpdaterId",
                table: "EscortPackages",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageReclaims_CreatorId",
                table: "DayCarePackageReclaims",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageReclaims_UpdaterId",
                table: "DayCarePackageReclaims",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCareApprovalHistory_UpdaterId",
                table: "DayCareApprovalHistory",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatorId",
                table: "Clients",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UpdaterId",
                table: "Clients",
                column: "UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_CreatorId",
                table: "Clients",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_UpdaterId",
                table: "Clients",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareApprovalHistory_AspNetUsers_UpdaterId",
                table: "DayCareApprovalHistory",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackageReclaims_AspNetUsers_CreatorId",
                table: "DayCarePackageReclaims",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackageReclaims_AspNetUsers_UpdaterId",
                table: "DayCarePackageReclaims",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EscortPackages_AspNetUsers_CreatorId",
                table: "EscortPackages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EscortPackages_AspNetUsers_UpdaterId",
                table: "EscortPackages",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackage_AspNetUsers_CreatorId",
                table: "HomeCarePackage",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackage_AspNetUsers_UpdaterId",
                table: "HomeCarePackage",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackageCosts_AspNetUsers_CreatorId",
                table: "HomeCarePackageCosts",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackageCosts_AspNetUsers_UpdaterId",
                table: "HomeCarePackageCosts",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackageReclaims_AspNetUsers_CreatorId",
                table: "HomeCarePackageReclaims",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackageReclaims_AspNetUsers_UpdaterId",
                table: "HomeCarePackageReclaims",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCareServiceTypes_AspNetUsers_CreatorId",
                table: "HomeCareServiceTypes",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCareServiceTypes_AspNetUsers_UpdaterId",
                table: "HomeCareServiceTypes",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCareSupplierCosts_AspNetUsers_CreatorId",
                table: "HomeCareSupplierCosts",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCareSupplierCosts_AspNetUsers_UpdaterId",
                table: "HomeCareSupplierCosts",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareBrokerageInfos_AspNetUsers_UpdaterId",
                table: "NursingCareBrokerageInfos",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackageReclaims_AspNetUsers_CreatorId",
                table: "NursingCarePackageReclaims",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackageReclaims_AspNetUsers_UpdaterId",
                table: "NursingCarePackageReclaims",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_CreatorId",
                table: "Packages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_UpdaterId",
                table: "Packages",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareBrokerageInfos_AspNetUsers_CreatorId",
                table: "ResidentialCareBrokerageInfos",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareBrokerageInfos_AspNetUsers_UpdaterId",
                table: "ResidentialCareBrokerageInfos",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackageReclaims_AspNetUsers_CreatorId",
                table: "ResidentialCarePackageReclaims",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackageReclaims_AspNetUsers_UpdaterId",
                table: "ResidentialCarePackageReclaims",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AspNetUsers_CreatorId",
                table: "Suppliers",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AspNetUsers_UpdaterId",
                table: "Suppliers",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlotShifts_AspNetUsers_CreatorId",
                table: "TimeSlotShifts",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlotShifts_AspNetUsers_UpdaterId",
                table: "TimeSlotShifts",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportEscortPackages_AspNetUsers_CreatorId",
                table: "TransportEscortPackages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportEscortPackages_AspNetUsers_UpdaterId",
                table: "TransportEscortPackages",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportPackages_AspNetUsers_CreatorId",
                table: "TransportPackages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportPackages_AspNetUsers_UpdaterId",
                table: "TransportPackages",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_CreatorId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_UpdaterId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareApprovalHistory_AspNetUsers_UpdaterId",
                table: "DayCareApprovalHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackageReclaims_AspNetUsers_CreatorId",
                table: "DayCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackageReclaims_AspNetUsers_UpdaterId",
                table: "DayCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_EscortPackages_AspNetUsers_CreatorId",
                table: "EscortPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_EscortPackages_AspNetUsers_UpdaterId",
                table: "EscortPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackage_AspNetUsers_CreatorId",
                table: "HomeCarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackage_AspNetUsers_UpdaterId",
                table: "HomeCarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackageCosts_AspNetUsers_CreatorId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackageCosts_AspNetUsers_UpdaterId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackageReclaims_AspNetUsers_CreatorId",
                table: "HomeCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackageReclaims_AspNetUsers_UpdaterId",
                table: "HomeCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareServiceTypes_AspNetUsers_CreatorId",
                table: "HomeCareServiceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareServiceTypes_AspNetUsers_UpdaterId",
                table: "HomeCareServiceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareSupplierCosts_AspNetUsers_CreatorId",
                table: "HomeCareSupplierCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareSupplierCosts_AspNetUsers_UpdaterId",
                table: "HomeCareSupplierCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareBrokerageInfos_AspNetUsers_UpdaterId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackageReclaims_AspNetUsers_CreatorId",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackageReclaims_AspNetUsers_UpdaterId",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_CreatorId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_UpdaterId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareBrokerageInfos_AspNetUsers_CreatorId",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareBrokerageInfos_AspNetUsers_UpdaterId",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackageReclaims_AspNetUsers_CreatorId",
                table: "ResidentialCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackageReclaims_AspNetUsers_UpdaterId",
                table: "ResidentialCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AspNetUsers_CreatorId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AspNetUsers_UpdaterId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlotShifts_AspNetUsers_CreatorId",
                table: "TimeSlotShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlotShifts_AspNetUsers_UpdaterId",
                table: "TimeSlotShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportEscortPackages_AspNetUsers_CreatorId",
                table: "TransportEscortPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportEscortPackages_AspNetUsers_UpdaterId",
                table: "TransportEscortPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportPackages_AspNetUsers_CreatorId",
                table: "TransportPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportPackages_AspNetUsers_UpdaterId",
                table: "TransportPackages");

            migrationBuilder.DropIndex(
                name: "IX_TransportPackages_CreatorId",
                table: "TransportPackages");

            migrationBuilder.DropIndex(
                name: "IX_TransportPackages_UpdaterId",
                table: "TransportPackages");

            migrationBuilder.DropIndex(
                name: "IX_TransportEscortPackages_CreatorId",
                table: "TransportEscortPackages");

            migrationBuilder.DropIndex(
                name: "IX_TransportEscortPackages_UpdaterId",
                table: "TransportEscortPackages");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlotShifts_CreatorId",
                table: "TimeSlotShifts");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlotShifts_UpdaterId",
                table: "TimeSlotShifts");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_CreatorId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_UpdaterId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCarePackageReclaims_CreatorId",
                table: "ResidentialCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCarePackageReclaims_UpdaterId",
                table: "ResidentialCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareBrokerageInfos_CreatorId",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareBrokerageInfos_UpdaterId",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.DropIndex(
                name: "IX_Packages_CreatorId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_UpdaterId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_NursingCarePackageReclaims_CreatorId",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_NursingCarePackageReclaims_UpdaterId",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareBrokerageInfos_UpdaterId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropIndex(
                name: "IX_HomeCareSupplierCosts_CreatorId",
                table: "HomeCareSupplierCosts");

            migrationBuilder.DropIndex(
                name: "IX_HomeCareSupplierCosts_UpdaterId",
                table: "HomeCareSupplierCosts");

            migrationBuilder.DropIndex(
                name: "IX_HomeCareServiceTypes_CreatorId",
                table: "HomeCareServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_HomeCareServiceTypes_UpdaterId",
                table: "HomeCareServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackageReclaims_CreatorId",
                table: "HomeCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackageReclaims_UpdaterId",
                table: "HomeCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackageCosts_CreatorId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackageCosts_UpdaterId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackage_CreatorId",
                table: "HomeCarePackage");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackage_UpdaterId",
                table: "HomeCarePackage");

            migrationBuilder.DropIndex(
                name: "IX_EscortPackages_CreatorId",
                table: "EscortPackages");

            migrationBuilder.DropIndex(
                name: "IX_EscortPackages_UpdaterId",
                table: "EscortPackages");

            migrationBuilder.DropIndex(
                name: "IX_DayCarePackageReclaims_CreatorId",
                table: "DayCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_DayCarePackageReclaims_UpdaterId",
                table: "DayCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_DayCareApprovalHistory_UpdaterId",
                table: "DayCareApprovalHistory");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatorId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UpdaterId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TransportPackages");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "TransportPackages");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TransportEscortPackages");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "TransportEscortPackages");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "TimeSlotShifts");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ResidentialCarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "ResidentialCarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "HomeCareSupplierCosts");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HomeCareSupplierCosts");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "HomeCareSupplierCosts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "HomeCareStages");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HomeCareStages");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "HomeCareServiceTypes");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "HomeCarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "HomeCarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "HomeCarePackageCosts");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "HomeCarePackage");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "EscortPackages");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "EscortPackages");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "DayCarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "DayCarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "DayCareColleges");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "DayCareColleges");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "DayCareApprovalHistory");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "TimeSlotShifts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "TimeSlotShifts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "ResidentialCareBrokerageInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "ResidentialCareBrokerageInfos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Packages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "Packages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackages",
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

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatorId",
                table: "NursingCareBrokerageInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareAdditionalNeeds",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "HomeCareSupplierCosts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "HomeCareSupplierCosts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareStages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "HomeCareServiceTypes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "HomeCareServiceTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "HomeCarePackageCosts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "HomeCarePackageCosts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackage",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "HomeCarePackage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                table: "DayCareColleges",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "DayCareBrokerageInfo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "DayCareBrokerageInfo",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareApprovalHistory",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Clients",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("2f043f6f-09ed-42f0-ab30-c0409c05cb7e"),
                column: "CreatorId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                column: "CreatorId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "HomeCareServiceTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatorId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "TimeSlotShifts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatorId", "UpdatorId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareBrokerageInfos_UpdatorId",
                table: "NursingCareBrokerageInfos",
                column: "UpdatorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareBrokerageInfos_AspNetUsers_UpdatorId",
                table: "NursingCareBrokerageInfos",
                column: "UpdatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
