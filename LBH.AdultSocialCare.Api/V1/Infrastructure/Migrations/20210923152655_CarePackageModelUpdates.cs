using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class CarePackageModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE ""NursingCarePackages"" SET ""StatusId"" = 1;
UPDATE ""ResidentialCarePackages"" SET ""StatusId"" = 1;
UPDATE ""DayCarePackages"" SET ""StatusId"" = 1;
UPDATE ""HomeCarePackage"" SET ""StatusId"" = 1;");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageStatuses_AspNetUsers_CreatorId",
                table: "PackageStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageStatuses_AspNetUsers_UpdaterId",
                table: "PackageStatuses");

            migrationBuilder.DropTable(
                name: "NursingCarePackageSettings");

            migrationBuilder.DropTable(
                name: "ResidentialCarePackageSettings");

            migrationBuilder.DropIndex(
                name: "IX_PackageStatuses_CreatorId",
                table: "PackageStatuses");

            migrationBuilder.DropIndex(
                name: "IX_PackageStatuses_UpdaterId",
                table: "PackageStatuses");

            migrationBuilder.DeleteData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "PackageStatuses");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "PackageStatuses");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "PackageStatuses");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "PackageStatuses");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "PackagingScheduling",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "Stage",
                table: "CarePackages");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "CarePackages");

            migrationBuilder.AddColumn<string>(
                name: "StatusDisplayName",
                table: "PackageStatuses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarePackageSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    CarePackageId = table.Column<Guid>(nullable: false),
                    HasRespiteCare = table.Column<bool>(nullable: false),
                    HasDischargePackage = table.Column<bool>(nullable: false),
                    IsImmediate = table.Column<bool>(nullable: false),
                    IsReEnablement = table.Column<bool>(nullable: false),
                    IsS117Client = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackageSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarePackageSettings_CarePackages_CarePackageId",
                        column: x => x.CarePackageId,
                        principalTable: "CarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageSettings_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarePackageSettings_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusDisplayName",
                value: "Draft");

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "New", "New" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Submitted for Approval", "SubmittedForApproval" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Reject Package", "Rejected" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Clarification Needed", "ClarificationNeeded" });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "StatusDisplayName", "StatusName" },
                values: new object[] { "Approved", "Approved" });

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageSettings_CarePackageId",
                table: "CarePackageSettings",
                column: "CarePackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageSettings_CreatorId",
                table: "CarePackageSettings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePackageSettings_UpdaterId",
                table: "CarePackageSettings",
                column: "UpdaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarePackageSettings");

            migrationBuilder.DropColumn(
                name: "StatusDisplayName",
                table: "PackageStatuses");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "PackageStatuses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "PackageStatuses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "PackageStatuses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdaterId",
                table: "PackageStatuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndDate",
                table: "CarePackages",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackagingScheduling",
                table: "CarePackages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stage",
                table: "CarePackages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartDate",
                table: "CarePackages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "NursingCarePackageSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    HasFnc = table.Column<bool>(type: "boolean", nullable: false),
                    IsDischarge = table.Column<bool>(type: "boolean", nullable: false),
                    IsImmediate = table.Column<bool>(type: "boolean", nullable: false),
                    IsReEnablement = table.Column<bool>(type: "boolean", nullable: false),
                    IsRespiteCare = table.Column<bool>(type: "boolean", nullable: false),
                    IsS117Client = table.Column<bool>(type: "boolean", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCarePackageSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NursingCarePackageSettings_CarePackages_CarePackageId",
                        column: x => x.CarePackageId,
                        principalTable: "CarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackageSettings_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCarePackageSettings_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCarePackageSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarePackageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    HasDischargePackage = table.Column<bool>(type: "boolean", nullable: false),
                    HasRespiteCare = table.Column<bool>(type: "boolean", nullable: false),
                    IsImmediate = table.Column<bool>(type: "boolean", nullable: false),
                    IsReEnablement = table.Column<bool>(type: "boolean", nullable: false),
                    IsS117Client = table.Column<bool>(type: "boolean", nullable: false),
                    UpdaterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCarePackageSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageSettings_CarePackages_CarePackageId",
                        column: x => x.CarePackageId,
                        principalTable: "CarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageSettings_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCarePackageSettings_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatorId", "DateCreated", "DateUpdated", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatorId", "DateCreated", "DateUpdated", "StatusName", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "For Contents Approval", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatorId", "DateCreated", "DateUpdated", "StatusName", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Clarification Needed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatorId", "DateCreated", "DateUpdated", "StatusName", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Contents Approved", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatorId", "DateCreated", "DateUpdated", "StatusName", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Brokering", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.UpdateData(
                table: "PackageStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatorId", "DateCreated", "DateUpdated", "StatusName", "UpdaterId" },
                values: new object[] { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Commercially Approved Needed", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") });

            migrationBuilder.InsertData(
                table: "PackageStatuses",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "StatusName", "UpdaterId" },
                values: new object[,]
                {
                    { 7, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Clarifying Commercials", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 8, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Commercials Approved", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 9, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PO Issued", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 10, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Suspended", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") },
                    { 11, new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Ended", new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageStatuses_CreatorId",
                table: "PackageStatuses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageStatuses_UpdaterId",
                table: "PackageStatuses",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageSettings_CarePackageId",
                table: "NursingCarePackageSettings",
                column: "CarePackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageSettings_CreatorId",
                table: "NursingCarePackageSettings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageSettings_UpdaterId",
                table: "NursingCarePackageSettings",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageSettings_CarePackageId",
                table: "ResidentialCarePackageSettings",
                column: "CarePackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageSettings_CreatorId",
                table: "ResidentialCarePackageSettings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageSettings_UpdaterId",
                table: "ResidentialCarePackageSettings",
                column: "UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageStatuses_AspNetUsers_CreatorId",
                table: "PackageStatuses",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageStatuses_AspNetUsers_UpdaterId",
                table: "PackageStatuses",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
