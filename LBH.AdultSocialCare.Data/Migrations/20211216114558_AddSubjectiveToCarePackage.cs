using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AddSubjectiveToCarePackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subjective",
                table: "CarePackageReclaims",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subjective",
                table: "CarePackageDetails",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEE7oLV5MdDSgaXX8VXuAivUBbj2I7qD7JyNqDl3btiUUl2x5Bqik1YAD71wMeljKVw==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subjective",
                table: "CarePackageReclaims");

            migrationBuilder.DropColumn(
                name: "Subjective",
                table: "CarePackageDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJMF9t0Ryx8UeTtqprU/mA9L5FAq1Iv76Hz20QKlDLMb4T8w3K7eCt4ywGC2BhLJHQ==");
        }
    }
}
