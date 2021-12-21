using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class UpdatePayRunTypeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns");

            migrationBuilder.Sql(@"DELETE FROM ""Payruns"" CASCADE WHERE ""Type"" IN (2,4);");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Type",
                table: "Payruns",
                sql: "\"Type\" IN (1, 2, 3, 4)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75996f73-3a1a-4efa-8729-eb4a48c465b0"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDazWD57ElBqImqmsmQWOz2nSr6HJMoP4Zlugh04V5hRFU2mTNbrt+WZ6dTli/6vog==");
        }
    }
}
