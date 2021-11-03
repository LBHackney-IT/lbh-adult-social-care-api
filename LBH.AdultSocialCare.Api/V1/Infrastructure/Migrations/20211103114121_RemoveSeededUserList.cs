using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class RemoveSeededUserList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "Email", "Name", "UserName" },
                values: new object[] { "test@gmail.com", "Test User", "test@gmail.com" });


            migrationBuilder.Sql(@"UPDATE ""Suppliers""  SET ""CreatorId"" = 'aee45700-af9b-4ab5-bb43-535adbdcfb84';
UPDATE ""Suppliers""  SET ""UpdaterId""='aee45700-af9b-4ab5-bb43-535adbdcfb84' WHERE ""UpdaterId"" IS NOT NULL;
DELETE FROM ""AspNetUserRoles"";
DELETE FROM ""AspNetUserTokens"";
DELETE FROM ""ServiceUsers"";
DELETE FROM ""AspNetUserClaims"";
DELETE FROM ""CarePackages"";
DELETE FROM ""PayrunInvoices"";
DELETE FROM ""InvoiceItems"";
DELETE FROM ""PayrunInvoices"";
DELETE FROM ""InvoiceItems"";
DELETE FROM ""CarePackageDetails"";
DELETE FROM ""Payruns"";
DELETE FROM ""CarePackageHistories"";
DELETE FROM ""CarePackageReclaims"";
DELETE FROM ""Invoices"";
DELETE FROM ""CarePackageSettings"";
DELETE FROM ""AspNetUserLogins"";");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("3c44e4e1-78b8-471f-9f08-5081a0a534e9"), new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c6edb1d-799b-4ce3-98a8-e6fe271c4a8f"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("14ffd252-a98b-4489-ab58-6db72ed317c6"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("2f043f6f-09ed-42f0-ab30-c0409c05cb7e"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c96cc5b-557e-42eb-957b-f9b0b7302ad7"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("61e8b256-3bb6-42a2-9d24-38a44a3bd5f2"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("6691fbfc-e398-41e0-8733-9ae98ebe2ba8"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("91990f8a-b325-43eb-8482-0d1c7dcf8cd5"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a84d6c3-e570-4f30-8bb2-80425d6f8e60"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("a99f4b55-7c49-4bad-a338-86c6d79dfe36"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("dde0741c-f9a9-4d42-b889-a1d17864d77e"));

            migrationBuilder.DeleteData(
                table: "ServiceUsers",
                keyColumn: "Id",
                keyValue: new Guid("de846662-e8fe-4c47-bd0a-20113b71e02d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c44e4e1-78b8-471f-9f08-5081a0a534e9"));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "RoleId1", "UserId1" },
                values: new object[,]
                {
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d"), null, null },
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83"), null, null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "Email", "Name", "UserName" },
                values: new object[] { "furkan@gmail.com", "Furkan Kuyar", "furkan@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3c44e4e1-78b8-471f-9f08-5081a0a534e9"), 0, "4d24dcde-08b2-4e04-b4f5-c475fab1a22d", "burak@gmail.com", false, false, null, "Burak Ozkan", null, null, null, "9046464646", false, null, false, "burak@gmail.com" },
                    { new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"), 0, "df0c47dc-a59f-4a66-a2c0-1e844b073466", "duncan@gmail.com", false, false, null, "Duncan Okeno", null, null, null, "12345678910", false, null, false, "duncan@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "ServiceUsers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "CanSpeakEnglish", "County", "CreatorId", "DateCreated", "DateOfBirth", "DateUpdated", "FirstName", "HackneyId", "LastName", "MiddleName", "PostCode", "PreferredContact", "PrimarySupportReasonId", "Town", "UpdaterId" },
                values: new object[,]
                {
                    { new Guid("2f043f6f-09ed-42f0-ab30-c0409c05cb7e"), "Old Town Road", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Henry", 55555, "Ford", null, "SW16", "Phone", null, "Bristol", null },
                    { new Guid("91990f8a-b325-43eb-8482-0d1c7dcf8cd5"), "Z Street", null, null, "Mid-Level", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Allie", 65653, "Grater", null, "W4", "Phone", null, "Ealing", null },
                    { new Guid("6691fbfc-e398-41e0-8733-9ae98ebe2ba8"), "XX Road", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Constance", 88888, "Noring", null, "C2", "Phone", null, "Cardiff", null },
                    { new Guid("a99f4b55-7c49-4bad-a338-86c6d79dfe36"), "YY Street", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Isabelle", 99999, "Ringing", null, "N7", "Phone", null, "Norwich", null },
                    { new Guid("61e8b256-3bb6-42a2-9d24-38a44a3bd5f2"), "Old Trafford", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Harriet", 11111, "Upp", null, "M8", "Phone", null, "Manchester", null },
                    { new Guid("0c6edb1d-799b-4ce3-98a8-e6fe271c4a8f"), "New Road", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Mark", 33322, "Ateer", null, "I12", "Phone", null, "Ipswich", null },
                    { new Guid("9a84d6c3-e570-4f30-8bb2-80425d6f8e60"), "Y Street", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1958, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Colin", 10532, "Edmunds", null, "B4", "Phone", null, "Brighton", null },
                    { new Guid("14ffd252-a98b-4489-ab58-6db72ed317c6"), "X Town", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1944, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tim", 57806, "Gray", null, "W2", "Phone", null, "Watford", null },
                    { new Guid("3c96cc5b-557e-42eb-957b-f9b0b7302ad7"), "X Road", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1950, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Jake", 33322, "Hart", null, "D1", "Phone", null, "Dorset", null },
                    { new Guid("dde0741c-f9a9-4d42-b889-a1d17864d77e"), "New Town", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1940, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Emma", 66779, "Coleman", null, "E1", "Phone", null, "Newcastle", null },
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"), "Queens Town Road", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Furkan", 66666, "Kayar", null, "SW11", "Phone", null, "London", null },
                    { new Guid("de846662-e8fe-4c47-bd0a-20113b71e02d"), "Anfield", null, null, "Fluent", null, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Willie", 22222, "Makit", null, "L9", "Mail", null, "Liverpool", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "RoleId1", "UserId1" },
                values: new object[] { new Guid("3c44e4e1-78b8-471f-9f08-5081a0a534e9"), new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089"), null, null });
        }
    }
}
