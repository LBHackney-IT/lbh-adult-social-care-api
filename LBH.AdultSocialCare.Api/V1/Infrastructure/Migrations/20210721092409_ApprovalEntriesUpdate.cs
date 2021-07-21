using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class ApprovalEntriesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                column: "ConcurrencyStamp",
                value: "cb415cbe-5c1e-4bc2-8d6c-a610bb98bfbc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                column: "ConcurrencyStamp",
                value: "3e929a05-112c-4087-94f3-088c47c46ab2");
        }
    }
}
