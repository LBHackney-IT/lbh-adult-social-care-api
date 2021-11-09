using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AddBaseEntityOnHeldInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "HeldInvoices",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "HeldInvoices",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "HeldInvoices",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "HeldInvoices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeldInvoices_CreatorId",
                table: "HeldInvoices",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HeldInvoices_UpdaterId",
                table: "HeldInvoices",
                column: "UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeldInvoices_AspNetUsers_CreatorId",
                table: "HeldInvoices",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeldInvoices_AspNetUsers_UpdaterId",
                table: "HeldInvoices",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeldInvoices_AspNetUsers_CreatorId",
                table: "HeldInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_HeldInvoices_AspNetUsers_UpdaterId",
                table: "HeldInvoices");

            migrationBuilder.DropIndex(
                name: "IX_HeldInvoices_CreatorId",
                table: "HeldInvoices");

            migrationBuilder.DropIndex(
                name: "IX_HeldInvoices_UpdaterId",
                table: "HeldInvoices");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "HeldInvoices");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "HeldInvoices");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HeldInvoices");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "HeldInvoices");
        }
    }
}
