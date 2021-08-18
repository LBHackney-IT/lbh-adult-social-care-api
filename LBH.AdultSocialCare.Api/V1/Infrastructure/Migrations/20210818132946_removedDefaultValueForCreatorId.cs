using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class removedDefaultValueForCreatorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TransportPackages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TransportEscortPackages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TimeSlotShifts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Suppliers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackageReclaims",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareBrokerageInfos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareApprovalHistories",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareAdditionalNeeds",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "PackageStatuses",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Packages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackageReclaims",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareBrokerageInfos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareApprovalHistories",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareAdditionalNeeds",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareSupplierCosts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareStages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareServiceTypes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackageReclaims",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackageCosts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "EscortPackages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackageStatuses",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackageReclaims",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareColleges",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareBrokerageInfo",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareApprovalHistory",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"));

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(730), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(747), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1578), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1586), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1648), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1650), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1656), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1661), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1663), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1667), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TransportPackages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TransportEscortPackages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "TimeSlotShifts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Suppliers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCarePackageReclaims",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareBrokerageInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareApprovalHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "ResidentialCareAdditionalNeeds",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "PackageStatuses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Packages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCarePackageReclaims",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareBrokerageInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareApprovalHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "NursingCareAdditionalNeeds",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareSupplierCosts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareStages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCareServiceTypes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackageReclaims",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackageCosts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "HomeCarePackage",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "EscortPackages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackageStatuses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCarePackageReclaims",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareColleges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareBrokerageInfo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "DayCareApprovalHistory",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Clients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                oldClrType: typeof(Guid));

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(5410), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(5421), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6213), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6219), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6282), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6287), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6288), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6293), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6294), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6299), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6300), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
