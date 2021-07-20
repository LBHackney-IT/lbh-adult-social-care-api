using System;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class PackageEntityUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "HomeCarePackage",
                nullable: false,
                defaultValue: dateTimeOffset);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "HomeCarePackage",
                nullable: false,
                defaultValue: dateTimeOffset);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "HomeCarePackage");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HomeCarePackage");


        }
    }
}
