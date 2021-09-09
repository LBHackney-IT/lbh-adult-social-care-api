using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class NursingCarePackageCareChargesUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM ""CareChargeElements"";
DELETE FROM ""PackageCareCharges"";");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_Clients_ClientId",
                table: "NursingCarePackages");

            migrationBuilder.DropColumn(
                name: "ClaimReasons",
                table: "PackageCareCharges");

            migrationBuilder.DropColumn(
                name: "NursingCarePackageId",
                table: "PackageCareCharges");

            migrationBuilder.DropForeignKey(name: "FK_CareChargeElements_PackageCareCharges_CareChargeId", table: "CareChargeElements");

            migrationBuilder.DropPrimaryKey(name: "PK_CareChargeElements", table: "CareChargeElements");

            migrationBuilder.DropPrimaryKey(name: "PK_PackageCareCharges", table: "PackageCareCharges");

            migrationBuilder.DropColumn("CareChargeId", "CareChargeElements");
            migrationBuilder.AddColumn<Guid>(name: "CareChargeId", table: "CareChargeElements", nullable: false);

            migrationBuilder.DropColumn("Id", "CareChargeElements");
            migrationBuilder.AddColumn<Guid>(name: "Id", table: "CareChargeElements", nullable: false);
            migrationBuilder.AddPrimaryKey(name: "PK_CareChargeElements", table: "CareChargeElements", column: "Id");

            migrationBuilder.DropColumn("Id", "PackageCareCharges");
            migrationBuilder.AddColumn<Guid>(name: "Id", table: "PackageCareCharges", nullable: false);
            migrationBuilder.AddPrimaryKey(name: "PK_PackageCareCharges", table: "PackageCareCharges", column: "Id");

            migrationBuilder.AddForeignKey(name: "FK_CareChargeElements_PackageCareCharges_CareChargeId", table: "CareChargeElements", column: "CareChargeId", principalTable: "PackageCareCharges", principalColumn: "Id", onDelete: ReferentialAction.Cascade);


            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "PackageCareCharges",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "NursingCarePackages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClaimReasons",
                table: "CareChargeElements",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CareChargeStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusName",
                value: "Ended");

            migrationBuilder.UpdateData(
                table: "CareChargeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "OptionName",
                value: "Provisional");

            migrationBuilder.UpdateData(
                table: "CareChargeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "OptionName",
                value: "Without Property 1-12 Weeks");

            migrationBuilder.InsertData(
                table: "CareChargeTypes",
                columns: new[] { "Id", "OptionName" },
                values: new object[] { 3, "Without Property 13+ Weeks" });

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_Clients_ClientId",
                table: "NursingCarePackages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_Clients_ClientId",
                table: "NursingCarePackages");

            migrationBuilder.DeleteData(
                table: "CareChargeTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "PackageCareCharges");

            migrationBuilder.DropColumn(
                name: "ClaimReasons",
                table: "CareChargeElements");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PackageCareCharges",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "ClaimReasons",
                table: "PackageCareCharges",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NursingCarePackageId",
                table: "PackageCareCharges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "NursingCarePackages",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "CareChargeId",
                table: "CareChargeElements",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CareChargeElements",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "CareChargeStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusName",
                value: "End");

            migrationBuilder.UpdateData(
                table: "CareChargeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "OptionName",
                value: "Without Property 1-12 Weeks");

            migrationBuilder.UpdateData(
                table: "CareChargeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "OptionName",
                value: "Without Property 13+ Weeks");

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_Clients_ClientId",
                table: "NursingCarePackages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
