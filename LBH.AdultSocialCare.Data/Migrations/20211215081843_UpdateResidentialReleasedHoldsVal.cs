using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdateResidentialReleasedHoldsVal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns");

            migrationBuilder.Sql(@"UPDATE ""Payruns"" SET ""Type"" = 2 WHERE ""Type"" = 3;");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns",
                sql: "\"Type\" IN (1, 2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJMF9t0Ryx8UeTtqprU/mA9L5FAq1Iv76Hz20QKlDLMb4T8w3K7eCt4ywGC2BhLJHQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns");

            migrationBuilder.Sql(@"UPDATE ""Payruns"" SET ""Type"" = 3 WHERE ""Type"" = 2;");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns",
                sql: "\"Type\" IN (1, 3)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBEO+mmspCIVNk8b2GsQirAlQElOn2Ep5ThcFo9cpkphwWQ79YeFRzNgQSpSRCWG+w==");
        }
    }
}
