using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class NursingCareAdditionalCostsUseBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareAdditionalNeedsCosts_AspNetUsers_UpdatorId",
                table: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_UpdatorId",
                table: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "NursingCareAdditionalNeedsCosts",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "NursingCareAdditionalNeedsCosts",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "NursingCareAdditionalNeedsCosts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_UpdaterId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareAdditionalNeedsCosts_AspNetUsers_UpdaterId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareAdditionalNeedsCosts_AspNetUsers_UpdaterId",
                table: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_UpdaterId",
                table: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatorId",
                table: "NursingCareAdditionalNeedsCosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_UpdatorId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "UpdatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareAdditionalNeedsCosts_AspNetUsers_UpdatorId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "UpdatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
