using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class SeedXYZSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareBrokerageInfos_ResidentialCarePackageId",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("80f1ea68-9335-4efe-b247-7aa58cc45af0"),
                column: "ConcurrencyStamp",
                value: "7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089"), "5", "Approver", "APPROVER" },
                    { new Guid("74b93ac7-1778-485d-a482-d76893f31aff"), "6", "Finance", "FINANCE" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                column: "ConcurrencyStamp",
                value: "f9429ddd-eb87-4c55-ac37-a52c36684beb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                column: "ConcurrencyStamp",
                value: "1a91b524-2051-4b13-938a-d83d1206bf8b");

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "HasSupplierFrameworkContractedRates", "IsSupplierInternal", "PackageTypeId", "SupplierName", "UpdatorId" },
                values: new object[] { 2, 0, new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, true, 1, "XYZ Ltd", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareBrokerageInfos_ResidentialCarePackageId",
                table: "ResidentialCareBrokerageInfos",
                column: "ResidentialCarePackageId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareBrokerageInfos_ResidentialCarePackageId",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("74b93ac7-1778-485d-a482-d76893f31aff"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7cb6746-1211-4cc2-9244-f4faaef25089"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("80f1ea68-9335-4efe-b247-7aa58cc45af0"),
                column: "ConcurrencyStamp",
                value: "5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                column: "ConcurrencyStamp",
                value: "f1e945af-8146-458f-adc5-f4d45bf59f90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                column: "ConcurrencyStamp",
                value: "87db33aa-900d-448f-a726-840b3599f9be");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareBrokerageInfos_ResidentialCarePackageId",
                table: "ResidentialCareBrokerageInfos",
                column: "ResidentialCarePackageId");
        }
    }
}
