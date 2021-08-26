using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class ResidentialCareAdditionalNeedsCostBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareAdditionalNeedsCosts_AspNetUsers_UpdatorId",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_UpdatorId",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "ResidentialCareAdditionalNeedsCosts",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "ResidentialCareAdditionalNeedsCosts",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "ResidentialCareAdditionalNeedsCosts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(7649), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(7656), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(8492), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(8497), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(8542), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(8543), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(8547), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(8548), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(8551), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(8552), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(8556), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 14, 21, 54, 358, DateTimeKind.Unspecified).AddTicks(8556), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_UpdaterId",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareAdditionalNeedsCosts_AspNetUsers_UpdaterId",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareAdditionalNeedsCosts_AspNetUsers_UpdaterId",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_UpdaterId",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatorId",
                table: "ResidentialCareAdditionalNeedsCosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(72), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(78), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(863), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(867), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(942), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(943), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(946), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(947), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(950), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(951), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(954), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 13, 44, 48, 300, DateTimeKind.Unspecified).AddTicks(955), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_UpdatorId",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "UpdatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareAdditionalNeedsCosts_AspNetUsers_UpdatorId",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "UpdatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
