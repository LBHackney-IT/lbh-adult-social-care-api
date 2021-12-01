using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdateRoleValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e958e66-b2a3-4e9d-9806-c5ca8bafda5d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1f0bea0c-9f9a-4ef1-b911-83e2113dd503"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66e830f6-ea42-44ad-beed-bbede0ff69df"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7335e791-1d08-437a-974e-809944d29bc6"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Super User", "SUPER USER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("74b93ac7-1778-485d-a482-d76893f31aff"),
                column: "ConcurrencyStamp",
                value: "4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("80f1ea68-9335-4efe-b247-7aa58cc45af0"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5", "Finance Approver", "FINANCE APPROVER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "Brokerage", "BROKERAGE" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3", "Brokerage Approver", "BROKERAGE APPROVER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7335e791-1d08-437a-974e-809944d29bc6"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Super Administrator", "SUPER ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("74b93ac7-1778-485d-a482-d76893f31aff"),
                column: "ConcurrencyStamp",
                value: "6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("80f1ea68-9335-4efe-b247-7aa58cc45af0"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4", "Broker", "BROKER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5", "Approver", "APPROVER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("66e830f6-ea42-44ad-beed-bbede0ff69df"), "2", "Administrator", "ADMINISTRATOR" },
                    { new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d"), "3", "Social Worker", "SOCIAL WORKER" },
                    { new Guid("1e958e66-b2a3-4e9d-9806-c5ca8bafda5d"), "8", "Broker Manager", "BROKER MANAGER" },
                    { new Guid("1f0bea0c-9f9a-4ef1-b911-83e2113dd503"), "9", "Broker Assistant", "BROKER ASSISTANT" }
                });
        }
    }
}
