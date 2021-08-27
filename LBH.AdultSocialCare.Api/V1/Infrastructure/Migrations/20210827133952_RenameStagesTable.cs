using Microsoft.EntityFrameworkCore.Migrations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class RenameStagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackage_HomeCareStages_StageId",
                table: "HomeCarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareStages_AspNetUsers_CreatorId",
                table: "HomeCareStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareStages_AspNetUsers_UpdaterId",
                table: "HomeCareStages");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_HomeCareStages_StageId",
                table: "NursingCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackages_HomeCareStages_StageId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeCareStages",
                table: "HomeCareStages");

            migrationBuilder.RenameTable(
                name: "HomeCareStages",
                newName: "PackageStages");

            migrationBuilder.RenameIndex(
                name: "IX_HomeCareStages_UpdaterId",
                table: "PackageStages",
                newName: "IX_PackageStages_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeCareStages_CreatorId",
                table: "PackageStages",
                newName: "IX_PackageStages_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageStages",
                table: "PackageStages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackage_PackageStages_StageId",
                table: "HomeCarePackage",
                column: "StageId",
                principalTable: "PackageStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_PackageStages_StageId",
                table: "NursingCarePackages",
                column: "StageId",
                principalTable: "PackageStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageStages_AspNetUsers_CreatorId",
                table: "PackageStages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageStages_AspNetUsers_UpdaterId",
                table: "PackageStages",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackages_PackageStages_StageId",
                table: "ResidentialCarePackages",
                column: "StageId",
                principalTable: "PackageStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackage_PackageStages_StageId",
                table: "HomeCarePackage");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_PackageStages_StageId",
                table: "NursingCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageStages_AspNetUsers_CreatorId",
                table: "PackageStages");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageStages_AspNetUsers_UpdaterId",
                table: "PackageStages");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackages_PackageStages_StageId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageStages",
                table: "PackageStages");

            migrationBuilder.RenameTable(
                name: "PackageStages",
                newName: "HomeCareStages");

            migrationBuilder.RenameIndex(
                name: "IX_PackageStages_UpdaterId",
                table: "HomeCareStages",
                newName: "IX_HomeCareStages_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_PackageStages_CreatorId",
                table: "HomeCareStages",
                newName: "IX_HomeCareStages_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeCareStages",
                table: "HomeCareStages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackage_HomeCareStages_StageId",
                table: "HomeCarePackage",
                column: "StageId",
                principalTable: "HomeCareStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCareStages_AspNetUsers_CreatorId",
                table: "HomeCareStages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCareStages_AspNetUsers_UpdaterId",
                table: "HomeCareStages",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_HomeCareStages_StageId",
                table: "NursingCarePackages",
                column: "StageId",
                principalTable: "HomeCareStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackages_HomeCareStages_StageId",
                table: "ResidentialCarePackages",
                column: "StageId",
                principalTable: "HomeCareStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
