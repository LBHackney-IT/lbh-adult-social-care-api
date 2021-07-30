using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class NursingCareFKUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"delete from ""NursingCarePackageReclaims"";
delete from ""NursingCareAdditionalNeeds"";
delete from ""NursingCareApprovalHistories"";
delete from ""NursingCareBrokerageInfos"";
delete from ""NursingCareRequestMoreInformations"";
delete from ""NursingCarePackages"";");

            migrationBuilder.Sql(@"ALTER TABLE ""NursingCareBrokerageInfos"" DROP COLUMN ""CreatorId"";
ALTER TABLE ""NursingCareBrokerageInfos"" ADD COLUMN ""CreatorId"" UUID NOT NULL;
ALTER TABLE ""NursingCareBrokerageInfos"" DROP COLUMN ""UpdatorId"";
ALTER TABLE ""NursingCareBrokerageInfos"" ADD COLUMN ""UpdatorId"" UUID;");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                column: "ConcurrencyStamp",
                value: "f1e945af-8146-458f-adc5-f4d45bf59f90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                column: "ConcurrencyStamp",
                value: "87db33aa-900d-448f-a726-840b3599f9be");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackages_AssignedUserId",
                table: "NursingCarePackages",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareBrokerageInfos_CreatorId",
                table: "NursingCareBrokerageInfos",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareBrokerageInfos_UpdatorId",
                table: "NursingCareBrokerageInfos",
                column: "UpdatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareBrokerageInfos_AspNetUsers_CreatorId",
                table: "NursingCareBrokerageInfos",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareBrokerageInfos_AspNetUsers_UpdatorId",
                table: "NursingCareBrokerageInfos",
                column: "UpdatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_AspNetUsers_AssignedUserId",
                table: "NursingCarePackages",
                column: "AssignedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareBrokerageInfos_AspNetUsers_CreatorId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareBrokerageInfos_AspNetUsers_UpdatorId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_AspNetUsers_AssignedUserId",
                table: "NursingCarePackages");

            migrationBuilder.DropIndex(
                name: "IX_NursingCarePackages_AssignedUserId",
                table: "NursingCarePackages");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareBrokerageInfos_CreatorId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareBrokerageInfos_UpdatorId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.Sql(@"delete from ""NursingCarePackageReclaims"";
delete from ""NursingCareAdditionalNeeds"";
delete from ""NursingCareApprovalHistories"";
delete from ""NursingCareBrokerageInfos"";
delete from ""NursingCareRequestMoreInformations"";
delete from ""NursingCarePackages"";");

            migrationBuilder.Sql(@"ALTER TABLE ""NursingCareBrokerageInfos"" DROP COLUMN ""CreatorId"";
ALTER TABLE ""NursingCareBrokerageInfos"" ADD COLUMN ""CreatorId"" INT NOT NULL;
ALTER TABLE ""NursingCareBrokerageInfos"" DROP COLUMN ""UpdatorId"";
ALTER TABLE ""NursingCareBrokerageInfos"" ADD COLUMN ""UpdatorId"" INT;");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                column: "ConcurrencyStamp",
                value: "4d02b3e8-5154-4a66-9d73-13a43f40446e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                column: "ConcurrencyStamp",
                value: "6dfc51e5-4355-413e-9b0e-ed2d7bf337ac");
        }
    }
}
