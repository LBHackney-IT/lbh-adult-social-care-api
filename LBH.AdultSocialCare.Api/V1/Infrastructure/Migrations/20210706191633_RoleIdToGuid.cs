using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class RoleIdToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayCareApprovalHistory_Users_CreatorId",
                table: "DayCareApprovalHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareBrokerageInfo_Users_CreatorId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareBrokerageInfo_Users_UpdaterId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareColleges_Users_CreatorId",
                table: "DayCareColleges");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareColleges_Users_UpdaterId",
                table: "DayCareColleges");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackages_Users_CreatorId",
                table: "DayCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackages_Users_UpdaterId",
                table: "DayCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackageStatuses_Users_CreatorId",
                table: "DayCarePackageStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackageStatuses_Users_UpdaterId",
                table: "DayCarePackageStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareStages_Users_CreatorId",
                table: "HomeCareStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareStages_Users_UpdaterId",
                table: "HomeCareStages");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareAdditionalNeeds_Users_CreatorId",
                table: "NursingCareAdditionalNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareAdditionalNeeds_Users_UpdaterId",
                table: "NursingCareAdditionalNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_Users_CreatorId",
                table: "NursingCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_Users_UpdaterId",
                table: "NursingCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageStatuses_Users_CreatorId",
                table: "PackageStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageStatuses_Users_UpdaterId",
                table: "PackageStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareAdditionalNeeds_Users_CreatorId",
                table: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareAdditionalNeeds_Users_UpdaterId",
                table: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackages_Users_CreatorId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackages_Users_UpdaterId",
                table: "ResidentialCarePackages");

            /*migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");*/

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressLine3",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HackneyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatorId",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            migrationBuilder.Sql(@"
ALTER TABLE ""Roles"" ADD COLUMN ""IdTwo"" uuid;
UPDATE ""Roles"" set ""IdTwo"" = '4defe6f2-09cf-43f2-8c1f-f4cad04a582d' where ""Id"" = 1;
UPDATE ""Roles"" set ""IdTwo"" = '97c46919-fd10-47f1-bcb9-fa6b513c4c83' where ""Id"" = 2;
ALTER TABLE ""Roles"" ALTER COLUMN ""IdTwo"" SET NOT NULL;
ALTER TABLE ""Roles"" DROP CONSTRAINT IF EXISTS ""PK_Roles"" CASCADE;
ALTER TABLE ""Roles"" DROP COLUMN ""Id"";
ALTER TABLE ""Roles"" RENAME COLUMN ""IdTwo"" to ""Id"";
            ");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            /*migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetRoles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);*/

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "AspNetRoles",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7335e791-1d08-437a-974e-809944d29bc6"), "SuperAdministrator", "Super Administrator", "SUPER ADMINISTRATOR" },
                    { new Guid("66e830f6-ea42-44ad-beed-bbede0ff69df"), "Administrator", "Administrator", "ADMINISTRATOR" },
                    { new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d"), "SocialWorker", "Social Worker", "SOCIAL WORKER" },
                    { new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83"), "Broker", "Broker", "BROKER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "PhoneNumber", "UserName" },
                values: new object[] { "8a013c09-dba1-4514-83e7-d285c5f9e9ab", "duncan@gmail.com", "Duncan Okeno", "12345678910", "duncan@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "PhoneNumber", "UserName" },
                values: new object[] { "578c865c-a932-44a1-b999-d4e78d1f644c", "furkan@gmail.com", "Furkan Kuyar", "1234567890", "furkan@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("7335e791-1d08-437a-974e-809944d29bc6") },
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d") },
                    { new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"), new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCarePackageReclaims_ResidentialCarePackageId",
                table: "ResidentialCarePackageReclaims",
                column: "ResidentialCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCarePackageReclaims_NursingCarePackageId",
                table: "NursingCarePackageReclaims",
                column: "NursingCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCarePackageReclaims_HomeCarePackageId",
                table: "HomeCarePackageReclaims",
                column: "HomeCarePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DayCarePackageReclaims_DayCarePackageId",
                table: "DayCarePackageReclaims",
                column: "DayCarePackageId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareApprovalHistory_AspNetUsers_CreatorId",
                table: "DayCareApprovalHistory",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareBrokerageInfo_AspNetUsers_CreatorId",
                table: "DayCareBrokerageInfo",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareBrokerageInfo_AspNetUsers_UpdaterId",
                table: "DayCareBrokerageInfo",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareColleges_AspNetUsers_CreatorId",
                table: "DayCareColleges",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareColleges_AspNetUsers_UpdaterId",
                table: "DayCareColleges",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackageReclaims_DayCarePackages_DayCarePackageId",
                table: "DayCarePackageReclaims",
                column: "DayCarePackageId",
                principalTable: "DayCarePackages",
                principalColumn: "DayCarePackageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackages_AspNetUsers_CreatorId",
                table: "DayCarePackages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackages_AspNetUsers_UpdaterId",
                table: "DayCarePackages",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackageStatuses_AspNetUsers_CreatorId",
                table: "DayCarePackageStatuses",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackageStatuses_AspNetUsers_UpdaterId",
                table: "DayCarePackageStatuses",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCarePackageReclaims_HomeCarePackage_HomeCarePackageId",
                table: "HomeCarePackageReclaims",
                column: "HomeCarePackageId",
                principalTable: "HomeCarePackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_NursingCareAdditionalNeeds_AspNetUsers_CreatorId",
                table: "NursingCareAdditionalNeeds",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareAdditionalNeeds_AspNetUsers_UpdaterId",
                table: "NursingCareAdditionalNeeds",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackageReclaims_NursingCarePackages_NursingCareP~",
                table: "NursingCarePackageReclaims",
                column: "NursingCarePackageId",
                principalTable: "NursingCarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_AspNetUsers_CreatorId",
                table: "NursingCarePackages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_AspNetUsers_UpdaterId",
                table: "NursingCarePackages",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareAdditionalNeeds_AspNetUsers_CreatorId",
                table: "ResidentialCareAdditionalNeeds",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareAdditionalNeeds_AspNetUsers_UpdaterId",
                table: "ResidentialCareAdditionalNeeds",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackageReclaims_ResidentialCarePackages_Resi~",
                table: "ResidentialCarePackageReclaims",
                column: "ResidentialCarePackageId",
                principalTable: "ResidentialCarePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackages_AspNetUsers_CreatorId",
                table: "ResidentialCarePackages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackages_AspNetUsers_UpdaterId",
                table: "ResidentialCarePackages",
                column: "UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayCareApprovalHistory_AspNetUsers_CreatorId",
                table: "DayCareApprovalHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareBrokerageInfo_AspNetUsers_CreatorId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareBrokerageInfo_AspNetUsers_UpdaterId",
                table: "DayCareBrokerageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareColleges_AspNetUsers_CreatorId",
                table: "DayCareColleges");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCareColleges_AspNetUsers_UpdaterId",
                table: "DayCareColleges");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackageReclaims_DayCarePackages_DayCarePackageId",
                table: "DayCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackages_AspNetUsers_CreatorId",
                table: "DayCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackages_AspNetUsers_UpdaterId",
                table: "DayCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackageStatuses_AspNetUsers_CreatorId",
                table: "DayCarePackageStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_DayCarePackageStatuses_AspNetUsers_UpdaterId",
                table: "DayCarePackageStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCarePackageReclaims_HomeCarePackage_HomeCarePackageId",
                table: "HomeCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareStages_AspNetUsers_CreatorId",
                table: "HomeCareStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeCareStages_AspNetUsers_UpdaterId",
                table: "HomeCareStages");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareAdditionalNeeds_AspNetUsers_CreatorId",
                table: "NursingCareAdditionalNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareAdditionalNeeds_AspNetUsers_UpdaterId",
                table: "NursingCareAdditionalNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackageReclaims_NursingCarePackages_NursingCareP~",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_AspNetUsers_CreatorId",
                table: "NursingCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingCarePackages_AspNetUsers_UpdaterId",
                table: "NursingCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageStatuses_AspNetUsers_CreatorId",
                table: "PackageStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageStatuses_AspNetUsers_UpdaterId",
                table: "PackageStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareAdditionalNeeds_AspNetUsers_CreatorId",
                table: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareAdditionalNeeds_AspNetUsers_UpdaterId",
                table: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackageReclaims_ResidentialCarePackages_Resi~",
                table: "ResidentialCarePackageReclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackages_AspNetUsers_CreatorId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCarePackages_AspNetUsers_UpdaterId",
                table: "ResidentialCarePackages");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCarePackageReclaims_ResidentialCarePackageId",
                table: "ResidentialCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_NursingCarePackageReclaims_NursingCarePackageId",
                table: "NursingCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_HomeCarePackageReclaims_HomeCarePackageId",
                table: "HomeCarePackageReclaims");

            migrationBuilder.DropIndex(
                name: "IX_DayCarePackageReclaims_DayCarePackageId",
                table: "DayCarePackageReclaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4defe6f2-09cf-43f2-8c1f-f4cad04a582d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66e830f6-ea42-44ad-beed-bbede0ff69df"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7335e791-1d08-437a-974e-809944d29bc6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97c46919-fd10-47f1-bcb9-fa6b513c4c83"));

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine3",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HackneyId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            /*migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Roles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);*/

            migrationBuilder.Sql(@"
ALTER TABLE ""Roles"" ADD COLUMN ""IdTwo"" int;
UPDATE ""Roles"" set ""IdTwo"" = 1 where ""Id"" = '4defe6f2-09cf-43f2-8c1f-f4cad04a582d';
UPDATE ""Roles"" set ""IdTwo"" = 2 where ""Id"" = '97c46919-fd10-47f1-bcb9-fa6b513c4c83';
ALTER TABLE ""Roles"" ALTER COLUMN ""IdTwo"" SET NOT NULL;
ALTER TABLE ""Roles"" DROP CONSTRAINT IF EXISTS ""PK_Roles"" CASCADE;
ALTER TABLE ""Roles"" DROP COLUMN ""Id"";
ALTER TABLE ""Roles"" RENAME COLUMN ""IdTwo"" to ""Id"";
            ");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Roles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Roles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Roles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "Roles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatorId",
                table: "Roles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatorId", "DateCreated", "DateUpdated", "IsDefault", "RoleName", "Sequence", "UpdatorId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, "Social Worker", 1, 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "Broker", 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                columns: new[] { "AddressLine1", "DateCreated", "DateUpdated", "FirstName", "HackneyId", "LastName", "PostCode", "RoleId", "Town" },
                values: new object[] { "Nairobi", new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Duncan", 4444, "Okeno", "W11", 2, "Nairobi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                columns: new[] { "AddressLine1", "DateCreated", "DateUpdated", "FirstName", "HackneyId", "LastName", "PostCode", "RoleId", "Town" },
                values: new object[] { "Queens Gate", new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 21, 9, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Furkan", 1111, "Kayar", "W11", 1, "London" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareApprovalHistory_Users_CreatorId",
                table: "DayCareApprovalHistory",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareBrokerageInfo_Users_CreatorId",
                table: "DayCareBrokerageInfo",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareBrokerageInfo_Users_UpdaterId",
                table: "DayCareBrokerageInfo",
                column: "UpdaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareColleges_Users_CreatorId",
                table: "DayCareColleges",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCareColleges_Users_UpdaterId",
                table: "DayCareColleges",
                column: "UpdaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackages_Users_CreatorId",
                table: "DayCarePackages",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackages_Users_UpdaterId",
                table: "DayCarePackages",
                column: "UpdaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackageStatuses_Users_CreatorId",
                table: "DayCarePackageStatuses",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCarePackageStatuses_Users_UpdaterId",
                table: "DayCarePackageStatuses",
                column: "UpdaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCareStages_Users_CreatorId",
                table: "HomeCareStages",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCareStages_Users_UpdaterId",
                table: "HomeCareStages",
                column: "UpdaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareAdditionalNeeds_Users_CreatorId",
                table: "NursingCareAdditionalNeeds",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareAdditionalNeeds_Users_UpdaterId",
                table: "NursingCareAdditionalNeeds",
                column: "UpdaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_Users_CreatorId",
                table: "NursingCarePackages",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCarePackages_Users_UpdaterId",
                table: "NursingCarePackages",
                column: "UpdaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageStatuses_Users_CreatorId",
                table: "PackageStatuses",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageStatuses_Users_UpdaterId",
                table: "PackageStatuses",
                column: "UpdaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareAdditionalNeeds_Users_CreatorId",
                table: "ResidentialCareAdditionalNeeds",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareAdditionalNeeds_Users_UpdaterId",
                table: "ResidentialCareAdditionalNeeds",
                column: "UpdaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackages_Users_CreatorId",
                table: "ResidentialCarePackages",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCarePackages_Users_UpdaterId",
                table: "ResidentialCarePackages",
                column: "UpdaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
