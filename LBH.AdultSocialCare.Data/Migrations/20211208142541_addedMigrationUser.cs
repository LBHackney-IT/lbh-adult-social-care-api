using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class addedMigrationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"), 0, "6b3d758b-924a-482c-af77-e31711a74a2f", "migration@gmail.com", false, true, new DateTimeOffset(new DateTime(2521, 12, 8, 17, 25, 40, 935, DateTimeKind.Unspecified).AddTicks(7737), new TimeSpan(0, 3, 0, 0, 0)), "Migration User", null, null, "AQAAAAEAACcQAAAAEFZSuEqut3biK0yaWcDBpQR2draz7roFwzCnbTVF4yl38cMg1ULpUS3gVplbtitcmQ==", "1234567890", false, null, false, "migration@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"));
        }
    }
}
