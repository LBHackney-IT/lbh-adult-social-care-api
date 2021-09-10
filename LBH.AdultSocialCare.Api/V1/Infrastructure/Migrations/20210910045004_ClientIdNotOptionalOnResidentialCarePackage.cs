using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class ClientIdNotOptionalOnResidentialCarePackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackages_Clients_ClientId",
                table: "ResidentialCarePackages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "ResidentialCarePackages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackages_Clients_ClientId",
                table: "ResidentialCarePackages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackages_Clients_ClientId",
                table: "ResidentialCarePackages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "ResidentialCarePackages",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackages_Clients_ClientId",
                table: "ResidentialCarePackages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
