using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class ClientSeedPayRun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "CanSpeakEnglish", "County", "CreatorId", "DateCreated", "DateOfBirth", "DateUpdated", "FirstName", "HackneyId", "LastName", "MiddleName", "PostCode", "PreferredContact", "PrimarySupportReasonId", "Town", "UpdatorId" },
                values: new object[,]
                {
                    { new Guid("91990f8a-b325-43eb-8482-0d1c7dcf8cd5"), "Old Town Road", null, null, "Fluent", null, 0, new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Allie", 77777, "Grater", null, "SW16", "Phone", null, "Bristol", 0 },
                    { new Guid("6691fbfc-e398-41e0-8733-9ae98ebe2ba8"), "Old Town Road", null, null, "Fluent", null, 0, new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Constance", 88888, "Noring", null, "SW16", "Phone", null, "Bristol", 0 },
                    { new Guid("a99f4b55-7c49-4bad-a338-86c6d79dfe36"), "Old Town Road", null, null, "Fluent", null, 0, new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Isabelle", 99999, "Ringing", null, "SW16", "Phone", null, "Bristol", 0 },
                    { new Guid("61e8b256-3bb6-42a2-9d24-38a44a3bd5f2"), "Old Town Road", null, null, "Fluent", null, 0, new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Harriet", 11111, "Upp", null, "SW16", "Phone", null, "Bristol", 0 },
                    { new Guid("de846662-e8fe-4c47-bd0a-20113b71e02d"), "Old Town Road", null, null, "Fluent", null, 0, new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Willie", 22222, "Makit", null, "SW16", "Phone", null, "Bristol", 0 },
                    { new Guid("0c6edb1d-799b-4ce3-98a8-e6fe271c4a8f"), "Old Town Road", null, null, "Fluent", null, 0, new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mark", 33322, "Ateer", null, "SW16", "Phone", null, "Bristol", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("0c6edb1d-799b-4ce3-98a8-e6fe271c4a8f"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("61e8b256-3bb6-42a2-9d24-38a44a3bd5f2"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("6691fbfc-e398-41e0-8733-9ae98ebe2ba8"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("91990f8a-b325-43eb-8482-0d1c7dcf8cd5"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("a99f4b55-7c49-4bad-a338-86c6d79dfe36"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("de846662-e8fe-4c47-bd0a-20113b71e02d"));
        }
    }
}
