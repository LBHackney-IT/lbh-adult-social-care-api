using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class PayRunHistoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Status",
                table: "Payruns");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Status",
                table: "Payruns",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8)");

            migrationBuilder.CreateTable(
                name: "PayrunHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdaterId = table.Column<Guid>(nullable: true),
                    PayRunId = table.Column<Guid>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrunHistory", x => x.Id);
                    table.CheckConstraint("CK_PayrunHistory_Status", "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7, 8)");
                    table.ForeignKey(
                        name: "FK_PayrunHistory_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrunHistory_Payruns_PayRunId",
                        column: x => x.PayRunId,
                        principalTable: "Payruns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrunHistory_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayrunHistory_CreatorId",
                table: "PayrunHistory",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrunHistory_PayRunId",
                table: "PayrunHistory",
                column: "PayRunId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrunHistory_UpdaterId",
                table: "PayrunHistory",
                column: "UpdaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrunHistory");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Payruns_Status",
                table: "Payruns");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_Payruns_Status",
                table: "Payruns",
                sql: "\"Status\" IN (0, 1, 2, 3, 4, 5, 6, 7)");
        }
    }
}
