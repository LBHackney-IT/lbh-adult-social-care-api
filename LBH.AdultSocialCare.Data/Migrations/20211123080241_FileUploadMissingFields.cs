using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class FileUploadMissingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SocialWorkerCarePlanFileId",
                table: "CarePackages",
                nullable: true);
            /*
            migrationBuilder.AlterColumn<Guid>(
                name: "SocialWorkerCarePlanFileId",
                table: "CarePackages",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialWorkerCarePlanFileId",
                table: "CarePackages");
            /*migrationBuilder.AlterColumn<Guid>(
                name: "SocialWorkerCarePlanFileId",
                table: "CarePackages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);*/
        }
    }
}
