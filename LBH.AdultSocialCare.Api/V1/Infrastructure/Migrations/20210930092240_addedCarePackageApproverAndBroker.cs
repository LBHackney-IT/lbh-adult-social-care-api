using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class addedCarePackageApproverAndBroker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApproverId",
                table: "CarePackages",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BrokerId",
                table: "CarePackages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_ApproverId",
                table: "CarePackages",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackages_BrokerId",
                table: "CarePackages",
                column: "BrokerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_AspNetUsers_ApproverId",
                table: "CarePackages",
                column: "ApproverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarePackages_AspNetUsers_BrokerId",
                table: "CarePackages",
                column: "BrokerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_AspNetUsers_ApproverId",
                table: "CarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarePackages_AspNetUsers_BrokerId",
                table: "CarePackages");

            migrationBuilder.DropIndex(
                name: "IX_CarePackages_ApproverId",
                table: "CarePackages");

            migrationBuilder.DropIndex(
                name: "IX_CarePackages_BrokerId",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "CarePackages");
        }
    }
}
