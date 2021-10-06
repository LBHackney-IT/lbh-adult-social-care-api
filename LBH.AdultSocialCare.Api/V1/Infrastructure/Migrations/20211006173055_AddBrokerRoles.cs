using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AddBrokerRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1e958e66-b2a3-4e9d-9806-c5ca8bafda5d"), "8", "Broker Manager", "BROKER MANAGER" },
                    { new Guid("1f0bea0c-9f9a-4ef1-b911-83e2113dd503"), "9", "Broker Assistant", "BROKER ASSISTANT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e958e66-b2a3-4e9d-9806-c5ca8bafda5d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1f0bea0c-9f9a-4ef1-b911-83e2113dd503"));
        }
    }
}
