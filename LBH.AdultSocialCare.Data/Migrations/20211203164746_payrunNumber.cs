using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class payrunNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Payruns",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payruns_Number",
                table: "Payruns",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payruns_Number",
                table: "Payruns");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Payruns");
        }
    }
}
