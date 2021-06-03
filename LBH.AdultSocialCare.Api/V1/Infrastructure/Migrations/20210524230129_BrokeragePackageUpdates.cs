using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class BrokeragePackageUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResidentialCareBrokerageInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    ResidentialCarePackageId = table.Column<Guid>(nullable: false),
                    ResidentialCore = table.Column<decimal>(nullable: false),
                    AdditionalNeedsPayment = table.Column<decimal>(nullable: false),
                    AdditionalNeedsPaymentOneOff = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    UpdatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareBrokerageInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialCareBrokerageInfos_ResidentialCarePackages_Resid~",
                        column: x => x.ResidentialCarePackageId,
                        principalTable: "ResidentialCarePackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareBrokerageInfos_ResidentialCarePackageId",
                table: "ResidentialCareBrokerageInfos",
                column: "ResidentialCarePackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentialCareBrokerageInfos");
        }
    }
}
