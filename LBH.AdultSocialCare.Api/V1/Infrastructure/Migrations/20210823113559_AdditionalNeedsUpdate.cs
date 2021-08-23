using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Migrations
{
    public partial class AdditionalNeedsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalNeedsPayment",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.DropColumn(
                name: "AdditionalNeedsPaymentOneOff",
                table: "ResidentialCareBrokerageInfos");

            migrationBuilder.DropColumn(
                name: "IsOneOffCost",
                table: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropColumn(
                name: "IsWeeklyCost",
                table: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropColumn(
                name: "AdditionalNeedsPayment",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropColumn(
                name: "AdditionalNeedsPaymentOneOff",
                table: "NursingCareBrokerageInfos");

            migrationBuilder.DropColumn(
                name: "IsOneOffCost",
                table: "NursingCareAdditionalNeeds");

            migrationBuilder.DropColumn(
                name: "IsWeeklyCost",
                table: "NursingCareAdditionalNeeds");

            migrationBuilder.AddColumn<int>(
                name: "AdditionalNeedsPaymentTypeId",
                table: "ResidentialCareAdditionalNeeds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalNeedsPaymentTypeId",
                table: "NursingCareAdditionalNeeds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdditionalNeedsPaymentTypes",
                columns: table => new
                {
                    AdditionalNeedsPaymentTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalNeedsPaymentTypes", x => x.AdditionalNeedsPaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "NursingCareAdditionalNeedsCosts",
                columns: table => new
                {
                    NursingCareAdditionalNeedsCostId = table.Column<Guid>(nullable: false),
                    NursingCareBrokerageId = table.Column<Guid>(nullable: false),
                    AdditionalNeedsPaymentTypeId = table.Column<int>(nullable: false),
                    AdditionalNeedsCost = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdatorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingCareAdditionalNeedsCosts", x => x.NursingCareAdditionalNeedsCostId);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeedsCosts_AdditionalNeedsPaymentTypes~",
                        column: x => x.AdditionalNeedsPaymentTypeId,
                        principalTable: "AdditionalNeedsPaymentTypes",
                        principalColumn: "AdditionalNeedsPaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeedsCosts_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeedsCosts_NursingCareBrokerageInfos_N~",
                        column: x => x.NursingCareBrokerageId,
                        principalTable: "NursingCareBrokerageInfos",
                        principalColumn: "NursingCareBrokerageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursingCareAdditionalNeedsCosts_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialCareAdditionalNeedsCosts",
                columns: table => new
                {
                    ResidentialCareAdditionalNeedsCostId = table.Column<Guid>(nullable: false),
                    ResidentialCareBrokerageId = table.Column<Guid>(nullable: false),
                    AdditionalNeedsPaymentTypeId = table.Column<int>(nullable: false),
                    AdditionalNeedsCost = table.Column<decimal>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    UpdatorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialCareAdditionalNeedsCosts", x => x.ResidentialCareAdditionalNeedsCostId);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeedsCosts_AdditionalNeedsPaymentT~",
                        column: x => x.AdditionalNeedsPaymentTypeId,
                        principalTable: "AdditionalNeedsPaymentTypes",
                        principalColumn: "AdditionalNeedsPaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeedsCosts_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeedsCosts_ResidentialCareBrokerag~",
                        column: x => x.ResidentialCareBrokerageId,
                        principalTable: "ResidentialCareBrokerageInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialCareAdditionalNeedsCosts_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AdditionalNeedsPaymentTypes",
                columns: new[] { "AdditionalNeedsPaymentTypeId", "OptionName" },
                values: new object[,]
                {
                    { 1, "Weekly" },
                    { 2, "One Off" },
                    { 3, "Fixed Period" }
                });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(4415), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(4448), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(5945), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(6031), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(6033), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(6041), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(6047), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(6048), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(6054), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 23, 11, 35, 55, 881, DateTimeKind.Unspecified).AddTicks(6055), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeeds_AdditionalNeedsPaymentTypeId",
                table: "ResidentialCareAdditionalNeeds",
                column: "AdditionalNeedsPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeeds_AdditionalNeedsPaymentTypeId",
                table: "NursingCareAdditionalNeeds",
                column: "AdditionalNeedsPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_AdditionalNeedsPaymentTypeId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "AdditionalNeedsPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_CreatorId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_NursingCareBrokerageId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "NursingCareBrokerageId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingCareAdditionalNeedsCosts_UpdatorId",
                table: "NursingCareAdditionalNeedsCosts",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_AdditionalNeedsPaymentT~",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "AdditionalNeedsPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_CreatorId",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_ResidentialCareBrokerag~",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "ResidentialCareBrokerageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialCareAdditionalNeedsCosts_UpdatorId",
                table: "ResidentialCareAdditionalNeedsCosts",
                column: "UpdatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NursingCareAdditionalNeeds_AdditionalNeedsPaymentTypes_Addi~",
                table: "NursingCareAdditionalNeeds",
                column: "AdditionalNeedsPaymentTypeId",
                principalTable: "AdditionalNeedsPaymentTypes",
                principalColumn: "AdditionalNeedsPaymentTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialCareAdditionalNeeds_AdditionalNeedsPaymentTypes_~",
                table: "ResidentialCareAdditionalNeeds",
                column: "AdditionalNeedsPaymentTypeId",
                principalTable: "AdditionalNeedsPaymentTypes",
                principalColumn: "AdditionalNeedsPaymentTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NursingCareAdditionalNeeds_AdditionalNeedsPaymentTypes_Addi~",
                table: "NursingCareAdditionalNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialCareAdditionalNeeds_AdditionalNeedsPaymentTypes_~",
                table: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropTable(
                name: "NursingCareAdditionalNeedsCosts");

            migrationBuilder.DropTable(
                name: "ResidentialCareAdditionalNeedsCosts");

            migrationBuilder.DropTable(
                name: "AdditionalNeedsPaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialCareAdditionalNeeds_AdditionalNeedsPaymentTypeId",
                table: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropIndex(
                name: "IX_NursingCareAdditionalNeeds_AdditionalNeedsPaymentTypeId",
                table: "NursingCareAdditionalNeeds");

            migrationBuilder.DropColumn(
                name: "AdditionalNeedsPaymentTypeId",
                table: "ResidentialCareAdditionalNeeds");

            migrationBuilder.DropColumn(
                name: "AdditionalNeedsPaymentTypeId",
                table: "NursingCareAdditionalNeeds");

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalNeedsPayment",
                table: "ResidentialCareBrokerageInfos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalNeedsPaymentOneOff",
                table: "ResidentialCareBrokerageInfos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsOneOffCost",
                table: "ResidentialCareAdditionalNeeds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWeeklyCost",
                table: "ResidentialCareAdditionalNeeds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalNeedsPayment",
                table: "NursingCareBrokerageInfos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalNeedsPaymentOneOff",
                table: "NursingCareBrokerageInfos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsOneOffCost",
                table: "NursingCareAdditionalNeeds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWeeklyCost",
                table: "NursingCareAdditionalNeeds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(730), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(747), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1578), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1586), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1648), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1650), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1656), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1661), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1663), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "HomeCareStages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1667), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 18, 13, 29, 44, 808, DateTimeKind.Unspecified).AddTicks(1669), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
