using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdateAssessmentFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialWorkerCarePlanFileId",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "SocialWorkerCarePlanFileName",
                table: "CarePackages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SocialWorkerCarePlanFileId",
                table: "CarePackages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialWorkerCarePlanFileName",
                table: "CarePackages",
                type: "text",
                nullable: true);
        }
    }
}
