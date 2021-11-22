using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class FileUploadUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialWorkerCarePlanFileUrl",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "AssessmentFileUrl",
                table: "CarePackageReclaims");

            migrationBuilder.AddColumn<Guid>(
                name: "SocialWorkerCarePlanFileId",
                table: "CarePackages",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SocialWorkerCarePlanFileName",
                table: "CarePackages",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssessmentFileId",
                table: "CarePackageReclaims",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AssessmentFileName",
                table: "CarePackageReclaims",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialWorkerCarePlanFileId",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "SocialWorkerCarePlanFileName",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "AssessmentFileId",
                table: "CarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "AssessmentFileName",
                table: "CarePackageReclaims");

            migrationBuilder.AddColumn<string>(
                name: "SocialWorkerCarePlanFileUrl",
                table: "CarePackages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssessmentFileUrl",
                table: "CarePackageReclaims",
                type: "text",
                nullable: true);
        }
    }
}
