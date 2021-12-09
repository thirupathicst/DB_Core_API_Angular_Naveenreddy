using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class createddatetime_column_defaultvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_Story",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                defaultValueSql: "GetDate()",
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_ReligiousDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                defaultValueSql: "GetDate()",
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_ProfessionalDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                defaultValueSql: "GetDate()",
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_PersonalInfo",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                defaultValueSql: "GetDate()",
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_Images",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                defaultValueSql: "GetDate()",
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_FamilyDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                defaultValueSql: "GetDate()",
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_EducationDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                defaultValueSql: "GetDate()",
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_AddressDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                defaultValueSql: "GetDate()",
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_Story",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_ReligiousDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_ProfessionalDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_PersonalInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_FamilyDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_EducationDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Tbl_AddressDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
