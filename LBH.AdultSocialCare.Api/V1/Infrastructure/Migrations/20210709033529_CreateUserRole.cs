using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class CreateUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d"),
                column: "ConcurrencyStamp",
                value: "3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66e830f6-ea42-44ad-beed-bbede0ff69df"),
                column: "ConcurrencyStamp",
                value: "2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7335e791-1d08-437a-974e-809944d29bc6"),
                column: "ConcurrencyStamp",
                value: "1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83"),
                column: "ConcurrencyStamp",
                value: "4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("80f1ea68-9335-4efe-b247-7aa58cc45af0"), "5", "User", "USER" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("80f1ea68-9335-4efe-b247-7aa58cc45af0"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d"),
                column: "ConcurrencyStamp",
                value: "SocialWorker");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66e830f6-ea42-44ad-beed-bbede0ff69df"),
                column: "ConcurrencyStamp",
                value: "Administrator");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7335e791-1d08-437a-974e-809944d29bc6"),
                column: "ConcurrencyStamp",
                value: "SuperAdministrator");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83"),
                column: "ConcurrencyStamp",
                value: "Broker");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                column: "ConcurrencyStamp",
                value: "8a013c09-dba1-4514-83e7-d285c5f9e9ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                column: "ConcurrencyStamp",
                value: "578c865c-a932-44a1-b999-d4e78d1f644c");
        }
    }
}
