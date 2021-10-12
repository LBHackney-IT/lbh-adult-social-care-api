using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class ClearPackages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Delete from ""CarePackages"" cascade;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
