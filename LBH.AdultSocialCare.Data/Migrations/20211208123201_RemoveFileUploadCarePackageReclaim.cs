using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class RemoveFileUploadCarePackageReclaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssessmentFileId",
                table: "CarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "AssessmentFileName",
                table: "CarePackageReclaims");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssessmentFileId",
                table: "CarePackageReclaims",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssessmentFileName",
                table: "CarePackageReclaims",
                type: "text",
                nullable: true);
        }
    }
}
