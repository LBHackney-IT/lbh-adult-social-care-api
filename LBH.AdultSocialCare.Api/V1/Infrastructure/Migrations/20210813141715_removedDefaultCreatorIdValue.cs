using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class removedDefaultCreatorIdValue : Migration
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
        }
    }
}
