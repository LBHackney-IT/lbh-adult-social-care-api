using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class PayRunHistoriesInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrunHistory_AspNetUsers_CreatorId",
                table: "PayrunHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrunHistory_Payruns_PayRunId",
                table: "PayrunHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrunHistory_AspNetUsers_UpdaterId",
                table: "PayrunHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayrunHistory",
                table: "PayrunHistory");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistory_Status",
                table: "PayrunHistory");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistory_Type",
                table: "PayrunHistory");

            migrationBuilder.RenameTable(
                name: "PayrunHistory",
                newName: "PayrunHistories");

            migrationBuilder.RenameIndex(
                name: "IX_PayrunHistory_UpdaterId",
                table: "PayrunHistories",
                newName: "IX_PayrunHistories_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_PayrunHistory_PayRunId",
                table: "PayrunHistories",
                newName: "IX_PayrunHistories_PayRunId");

            migrationBuilder.RenameIndex(
                name: "IX_PayrunHistory_CreatorId",
                table: "PayrunHistories",
                newName: "IX_PayrunHistories_CreatorId");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistories_Status",
                table: "PayrunHistories",
                sql: "\"Status\" IN (1, 2, 3, 4, 5, 6, 7, 8)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistories_Type",
                table: "PayrunHistories",
                sql: "\"Type\" IN (1, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayrunHistories",
                table: "PayrunHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunHistories_AspNetUsers_CreatorId",
                table: "PayrunHistories",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunHistories_Payruns_PayRunId",
                table: "PayrunHistories",
                column: "PayRunId",
                principalTable: "Payruns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunHistories_AspNetUsers_UpdaterId",
                table: "PayrunHistories",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrunHistories_AspNetUsers_CreatorId",
                table: "PayrunHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrunHistories_Payruns_PayRunId",
                table: "PayrunHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrunHistories_AspNetUsers_UpdaterId",
                table: "PayrunHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayrunHistories",
                table: "PayrunHistories");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistories_Status",
                table: "PayrunHistories");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PayrunHistories_Type",
                table: "PayrunHistories");

            migrationBuilder.RenameTable(
                name: "PayrunHistories",
                newName: "PayrunHistory");

            migrationBuilder.RenameIndex(
                name: "IX_PayrunHistories_UpdaterId",
                table: "PayrunHistory",
                newName: "IX_PayrunHistory_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_PayrunHistories_PayRunId",
                table: "PayrunHistory",
                newName: "IX_PayrunHistory_PayRunId");

            migrationBuilder.RenameIndex(
                name: "IX_PayrunHistories_CreatorId",
                table: "PayrunHistory",
                newName: "IX_PayrunHistory_CreatorId");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistory_Status",
                table: "PayrunHistory",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8)");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PayrunHistory_Type",
                table: "PayrunHistory",
                sql: "\"Type\" IN (0, 1, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayrunHistory",
                table: "PayrunHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunHistory_AspNetUsers_CreatorId",
                table: "PayrunHistory",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunHistory_Payruns_PayRunId",
                table: "PayrunHistory",
                column: "PayRunId",
                principalTable: "Payruns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayrunHistory_AspNetUsers_UpdaterId",
                table: "PayrunHistory",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
