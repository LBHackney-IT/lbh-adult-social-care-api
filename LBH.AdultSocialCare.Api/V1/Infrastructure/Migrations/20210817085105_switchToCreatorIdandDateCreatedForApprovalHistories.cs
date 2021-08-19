using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class switchToCreatorIdandDateCreatedForApprovalHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_NursingCareApprovalHistories_AspNetUsers_UserId",
            //     table: "NursingCareApprovalHistories");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_ResidentialCareApprovalHistories_AspNetUsers_UserId",
            //     table: "ResidentialCareApprovalHistories");

            // migrationBuilder.DropIndex(
            //     name: "IX_ResidentialCareApprovalHistories_UserId",
            //     table: "ResidentialCareApprovalHistories");

            // migrationBuilder.DropIndex(
            //     name: "IX_NursingCareApprovalHistories_UserId",
            //     table: "NursingCareApprovalHistories");

            migrationBuilder.RenameColumn(
                name: "UserId",
                newName: "CreatorId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.RenameColumn(
                name: "ApprovedDate",
                newName: "DateCreated",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "ResidentialCareApprovalHistories",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "ResidentialCareApprovalHistories",
                nullable: true);

            migrationBuilder.RenameColumn(
                name: "UserId",
                newName: "CreatorId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.RenameColumn(
                name: "ApprovedDate",
                newName: "DateCreated",
                table: "NursingCareApprovalHistories");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "NursingCareApprovalHistories",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "NursingCareApprovalHistories",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(5410), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(5421), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6213), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6219), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6280), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6282), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6287), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6288), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6293), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6294), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6299), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 51, 4, 152, DateTimeKind.Unspecified).AddTicks(6300), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareApprovalHistories_CreatorId",
                table: "ResidentialCareApprovalHistories",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareApprovalHistories_UpdaterId",
                table: "ResidentialCareApprovalHistories",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareApprovalHistories_CreatorId",
                table: "NursingCareApprovalHistories",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareApprovalHistories_UpdaterId",
                table: "NursingCareApprovalHistories",
                column: "UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareApprovalHistories_AspNetUsers_CreatorId",
                table: "NursingCareApprovalHistories",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareApprovalHistories_AspNetUsers_UpdaterId",
                table: "NursingCareApprovalHistories",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareApprovalHistories_AspNetUsers_CreatorId",
                table: "ResidentialCareApprovalHistories",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareApprovalHistories_AspNetUsers_UpdaterId",
                table: "ResidentialCareApprovalHistories",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareApprovalHistories_AspNetUsers_CreatorId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareApprovalHistories_AspNetUsers_UpdaterId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareApprovalHistories_AspNetUsers_CreatorId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareApprovalHistories_AspNetUsers_UpdaterId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareApprovalHistories_CreatorId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareApprovalHistories_UpdaterId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareApprovalHistories_CreatorId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareApprovalHistories_UpdaterId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "ResidentialCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "NursingCareApprovalHistories");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "NursingCareApprovalHistories");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ApprovedDate",
                table: "ResidentialCareApprovalHistories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ResidentialCareApprovalHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ApprovedDate",
                table: "NursingCareApprovalHistories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "NursingCareApprovalHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(1355), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(1370), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2086), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2091), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2152), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2154), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2158), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2159), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2163), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2164), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2168), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 17, 8, 27, 40, 473, DateTimeKind.Unspecified).AddTicks(2169), new TimeSpan(0, 0, 0, 0, 0)) });

            // migrationBuilder.CreateIndex(
            //     name: "IX_ResidentialCareApprovalHistories_UserId",
            //     table: "ResidentialCareApprovalHistories",
            //     column: "UserId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_NursingCareApprovalHistories_UserId",
            //     table: "NursingCareApprovalHistories",
            //     column: "UserId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_NursingCareApprovalHistories_AspNetUsers_UserId",
            //     table: "NursingCareApprovalHistories",
            //     column: "UserId",
            //     principalTable: "AspNetUsers",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_ResidentialCareApprovalHistories_AspNetUsers_UserId",
            //     table: "ResidentialCareApprovalHistories",
            //     column: "UserId",
            //     principalTable: "AspNetUsers",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}
