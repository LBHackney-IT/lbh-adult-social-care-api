using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class NursingCareBrokerageUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NursingCareBrokerageInfos",
                columns: table => new
                {
                    NursingCareBrokerageId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    NursingCarePackageId = table.Column<Guid>(nullable: false),
                    NursingCore = table.Column<decimal>(nullable: false),
                    AdditionalNeedsPayment = table.Column<decimal>(nullable: false),
                    AdditionalNeedsPaymentOneOff = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareBrokerageInfos", x => x.NursingCareBrokerageId);
                    table.ForeignKey(
                        name: "FK_NursingCareBrokerageInfos_NursingCarePackages_NursingCarePa~",
                        column: x => x.NursingCarePackageId,
                        principalTable: "NursingCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareBrokerageInfos_NursingCarePackageId",
                table: "NursingCareBrokerageInfos",
                column: "NursingCarePackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NursingCareBrokerageInfos");
        }
    }
}
