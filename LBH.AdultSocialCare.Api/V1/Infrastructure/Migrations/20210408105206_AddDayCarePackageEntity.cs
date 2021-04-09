using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AddDayCarePackageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TermTimeConsiderationOptions",
                columns: table => new
                {
                    OptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermTimeConsiderationOptions", x => x.OptionId);
                });

            migrationBuilder.CreateTable(
                name: "DayCarePackages",
                columns: table => new
                {
                    DayCarePackageId = table.Column<Guid>(nullable: false),
                    PackageId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    IsFixedPeriodOrOngoing = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    IsThisAnImmediateService = table.Column<bool>(nullable: false),
                    IsThisUserUnderS117 = table.Column<bool>(nullable: false),
                    NeedToAddress = table.Column<string>(nullable: true),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    TransportNeeded = table.Column<bool>(nullable: false),
                    EscortNeeded = table.Column<bool>(nullable: false),
                    TermTimeConsiderationOptionId = table.Column<int>(nullable: false),
                    HowLong = table.Column<string>(nullable: true),
                    HowManyTimesPerMonth = table.Column<string>(nullable: true),
                    OpportunitiesNeedToAddress = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: true),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCarePackages", x => x.DayCarePackageId);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_TermTimeConsiderationOptions_TermTimeConsiderationOptionId",
                        column: x => x.TermTimeConsiderationOptionId,
                        principalTable: "TermTimeConsiderationOptions",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayCarePackages_Users_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_ClientId",
                table: "DayCarePackages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_CreatorId",
                table: "DayCarePackages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_PackageId",
                table: "DayCarePackages",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_StatusId",
                table: "DayCarePackages",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_TermTimeConsiderationOptionId",
                table: "DayCarePackages",
                column: "TermTimeConsiderationOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackages_UpdaterId",
                table: "DayCarePackages",
                column: "UpdaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayCarePackages");

            migrationBuilder.DropTable(
                name: "TermTimeConsiderationOptions");
        }
    }
}
