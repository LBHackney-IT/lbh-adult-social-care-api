using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class CareChargeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareChargeStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareChargeStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CareChargeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareChargeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageCareCharges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    NursingCarePackageId = table.Column<Guid>(nullable: false),
                    PackageTypeId = table.Column<int>(nullable: false),
                    ClaimReasons = table.Column<string>(nullable: true),
                    ClaimCollectorId = table.Column<int>(nullable: false),
                    IsProvisional = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageCareCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageCareCharges_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageCareCharges_Packages_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageCareCharges_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProvisionalCareChargeAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: false),
                    AgeFrom = table.Column<int>(nullable: false),
                    AgeTo = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(13, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvisionalCareChargeAmounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CareChargeElements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    CareChargeId = table.Column<int>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    PaidUpTo = table.Column<DateTimeOffset>(nullable: true),
                    PreviousPaidUpTo = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareChargeElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_PackageCareCharges_CareChargeId",
                        column: x => x.CareChargeId,
                        principalTable: "PackageCareCharges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_CareChargeStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "CareChargeStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_CareChargeTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CareChargeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareChargeElements_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CareChargeStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "End" },
                    { 3, "Cancelled" },
                    { 4, "Future" }
                });

            migrationBuilder.InsertData(
                table: "CareChargeTypes",
                columns: new[] { "Id", "OptionName" },
                values: new object[,]
                {
                    { 1, "Without Property 1-12 Weeks" },
                    { 2, "Without Property 13+ Weeks" }
                });

            migrationBuilder.InsertData(
                table: "ProvisionalCareChargeAmounts",
                columns: new[] { "Id", "AgeFrom", "AgeTo", "Amount", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, 18, 24, 68.95m, new DateTimeOffset(new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, 25, 59, 84.40m, new DateTimeOffset(new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, 60, null, 148.45m, new DateTimeOffset(new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, 18, 24, 69.40m, new DateTimeOffset(new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, 25, 59, 84.90m, new DateTimeOffset(new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, 60, null, 152.20m, new DateTimeOffset(new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_CareChargeId",
                table: "CareChargeElements",
                column: "CareChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_ClientId",
                table: "CareChargeElements",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_CreatorId",
                table: "CareChargeElements",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_StatusId",
                table: "CareChargeElements",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_TypeId",
                table: "CareChargeElements",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CareChargeElements_UpdaterId",
                table: "CareChargeElements",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageCareCharges_CreatorId",
                table: "PackageCareCharges",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageCareCharges_PackageTypeId",
                table: "PackageCareCharges",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageCareCharges_UpdaterId",
                table: "PackageCareCharges",
                column: "UpdaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareChargeElements");

            migrationBuilder.DropTable(
                name: "ProvisionalCareChargeAmounts");

            migrationBuilder.DropTable(
                name: "PackageCareCharges");

            migrationBuilder.DropTable(
                name: "CareChargeStatuses");

            migrationBuilder.DropTable(
                name: "CareChargeTypes");
        }
    }
}
