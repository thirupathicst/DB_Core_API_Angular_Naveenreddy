using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class datetime_columns_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Tbl_Story",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_Story",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Tbl_ReligiousDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_ReligiousDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Tbl_ProfessionalDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_ProfessionalDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dateofbirth",
                table: "Tbl_PersonalInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Tbl_PersonalInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProfileStage",
                table: "Tbl_PersonalInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_PersonalInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Tbl_FamilyDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_FamilyDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Tbl_EducationDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_EducationDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Tbl_AddressDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_AddressDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Tbl_Story");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Tbl_Story");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Tbl_ReligiousDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Tbl_ReligiousDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Tbl_ProfessionalDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Tbl_ProfessionalDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Tbl_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "ProfileStage",
                table: "Tbl_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Tbl_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Tbl_FamilyDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Tbl_FamilyDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Tbl_EducationDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Tbl_EducationDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Tbl_AddressDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Tbl_AddressDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dateofbirth",
                table: "Tbl_PersonalInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
