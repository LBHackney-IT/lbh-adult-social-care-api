using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class NursingCareBrokerageOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NursingCareBrokerageInfos_NursingCarePackageId",
                table: "NursingCareBrokerageInfos");

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

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareBrokerageInfos_NursingCarePackageId",
                table: "NursingCareBrokerageInfos",
                column: "NursingCarePackageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NursingCareBrokerageInfos_NursingCarePackageId",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                column: "ConcurrencyStamp",
                value: "f7b12132-8b15-456c-98fc-5c005e8740b6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                column: "ConcurrencyStamp",
                value: "aa3a00e3-ac8d-4653-b096-ef7b423c9d14");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareBrokerageInfos_NursingCarePackageId",
                table: "NursingCareBrokerageInfos",
                column: "NursingCarePackageId");
        }
    }
}
