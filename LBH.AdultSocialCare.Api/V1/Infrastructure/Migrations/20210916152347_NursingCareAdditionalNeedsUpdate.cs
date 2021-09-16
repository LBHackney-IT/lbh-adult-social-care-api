using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class NursingCareAdditionalNeedsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NursingCareAdditionalNeedsId",
                table: "NursingCareAdditionalNeedsCosts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_NursingCareAdditionalNeedsId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "NursingCareAdditionalNeedsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareAdditionalNeedsCosts_NursingCareAdditionalNeeds_~",
                table: "NursingCareAdditionalNeedsCosts",
                column: "NursingCareAdditionalNeedsId",
                principalTable: "NursingCareAdditionalNeeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareAdditionalNeedsCosts_NursingCareAdditionalNeeds_~",
                table: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_NursingCareAdditionalNeedsId",
                table: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.DropColumn(
                name: "NursingCareAdditionalNeedsId",
                table: "NursingCareAdditionalNeedsCosts");
        }
    }
}
