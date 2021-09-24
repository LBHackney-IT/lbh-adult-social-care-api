using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class CarePackageSchedulingLookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarePackageSchedulingOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(nullable: true),
                    OptionPeriod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePackageSchedulingOptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CarePackageSchedulingOptions",
                columns: new[] { "Id", "OptionName", "OptionPeriod" },
                values: new object[,]
                {
                    { 1, "Interim or immediate service", "6 weeks and under" },
                    { 2, "Temporary", "Expected 52 weeks or under" },
                    { 3, "Long term", "52+ weeks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarePackageSchedulingOptions");
        }
    }
}
