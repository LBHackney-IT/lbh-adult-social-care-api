using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AssignUserToPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignedUserId",
                table: "ResidentialCarePackages",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedUserId",
                table: "NursingCarePackages",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                column: "ConcurrencyStamp",
                value: "c9f450a5-615e-420e-8ccd-1028dfd205aa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                column: "ConcurrencyStamp",
                value: "d3689461-4b3b-42fe-84fa-65abe1ca593d");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedUserId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropColumn(
                name: "AssignedUserId",
                table: "NursingCarePackages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                column: "ConcurrencyStamp",
                value: "1ad077b2-c217-45e7-8c07-ac7f78603ce2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                column: "ConcurrencyStamp",
                value: "c9e473dc-4d17-4b51-85a3-020db0d71d4e");
        }
    }
}
