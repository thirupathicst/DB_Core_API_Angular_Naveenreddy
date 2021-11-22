using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Loginhistory_ColumnsChanges_Renaming_AllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressDetails_PersonalInfo_PersonId",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationDetails_PersonalInfo_PersonId",
                table: "EducationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyDetails_PersonalInfo_PersonId",
                table: "FamilyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginDetails_PersonalInfo_PersonId",
                table: "LoginDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReligiousDetails_PersonalInfo_PersonId",
                table: "ReligiousDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_LoginHistory_LoginDetails_LoginId",
                table: "Tbl_LoginHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReligiousDetails",
                table: "ReligiousDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInfo",
                table: "PersonalInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyDetails",
                table: "FamilyDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationDetails",
                table: "EducationDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressDetails",
                table: "AddressDetails");

            migrationBuilder.RenameTable(
                name: "ReligiousDetails",
                newName: "Tbl_ReligiousDetails");

            migrationBuilder.RenameTable(
                name: "PersonalInfo",
                newName: "Tbl_PersonalInfo");

            migrationBuilder.RenameTable(
                name: "LoginDetails",
                newName: "Tbl_LoginDetails");

            migrationBuilder.RenameTable(
                name: "FamilyDetails",
                newName: "Tbl_FamilyDetails");

            migrationBuilder.RenameTable(
                name: "EducationDetails",
                newName: "Tbl_EducationDetails");

            migrationBuilder.RenameTable(
                name: "AddressDetails",
                newName: "Tbl_AddressDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ReligiousDetails_PersonId",
                table: "Tbl_ReligiousDetails",
                newName: "IX_Tbl_ReligiousDetails_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginDetails_PersonId",
                table: "Tbl_LoginDetails",
                newName: "IX_Tbl_LoginDetails_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyDetails_PersonId",
                table: "Tbl_FamilyDetails",
                newName: "IX_Tbl_FamilyDetails_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_EducationDetails_PersonId",
                table: "Tbl_EducationDetails",
                newName: "IX_Tbl_EducationDetails_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressDetails_PersonId",
                table: "Tbl_AddressDetails",
                newName: "IX_Tbl_AddressDetails_PersonId");

            migrationBuilder.AlterColumn<string>(
                name: "IPaddress",
                table: "Tbl_LoginHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Browsername",
                table: "Tbl_LoginHistory",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_ReligiousDetails",
                table: "Tbl_ReligiousDetails",
                column: "ReligiousId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_PersonalInfo",
                table: "Tbl_PersonalInfo",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_LoginDetails",
                table: "Tbl_LoginDetails",
                column: "LoginId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_FamilyDetails",
                table: "Tbl_FamilyDetails",
                column: "FamilyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_EducationDetails",
                table: "Tbl_EducationDetails",
                column: "EducationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_AddressDetails",
                table: "Tbl_AddressDetails",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_AddressDetails_Tbl_PersonalInfo_PersonId",
                table: "Tbl_AddressDetails",
                column: "PersonId",
                principalTable: "Tbl_PersonalInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_EducationDetails_Tbl_PersonalInfo_PersonId",
                table: "Tbl_EducationDetails",
                column: "PersonId",
                principalTable: "Tbl_PersonalInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_FamilyDetails_Tbl_PersonalInfo_PersonId",
                table: "Tbl_FamilyDetails",
                column: "PersonId",
                principalTable: "Tbl_PersonalInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_LoginDetails_Tbl_PersonalInfo_PersonId",
                table: "Tbl_LoginDetails",
                column: "PersonId",
                principalTable: "Tbl_PersonalInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_LoginHistory_Tbl_LoginDetails_LoginId",
                table: "Tbl_LoginHistory",
                column: "LoginId",
                principalTable: "Tbl_LoginDetails",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_ReligiousDetails_Tbl_PersonalInfo_PersonId",
                table: "Tbl_ReligiousDetails",
                column: "PersonId",
                principalTable: "Tbl_PersonalInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_AddressDetails_Tbl_PersonalInfo_PersonId",
                table: "Tbl_AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_EducationDetails_Tbl_PersonalInfo_PersonId",
                table: "Tbl_EducationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_FamilyDetails_Tbl_PersonalInfo_PersonId",
                table: "Tbl_FamilyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_LoginDetails_Tbl_PersonalInfo_PersonId",
                table: "Tbl_LoginDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_LoginHistory_Tbl_LoginDetails_LoginId",
                table: "Tbl_LoginHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_ReligiousDetails_Tbl_PersonalInfo_PersonId",
                table: "Tbl_ReligiousDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_ReligiousDetails",
                table: "Tbl_ReligiousDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_PersonalInfo",
                table: "Tbl_PersonalInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_LoginDetails",
                table: "Tbl_LoginDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_FamilyDetails",
                table: "Tbl_FamilyDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_EducationDetails",
                table: "Tbl_EducationDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_AddressDetails",
                table: "Tbl_AddressDetails");

            migrationBuilder.RenameTable(
                name: "Tbl_ReligiousDetails",
                newName: "ReligiousDetails");

            migrationBuilder.RenameTable(
                name: "Tbl_PersonalInfo",
                newName: "PersonalInfo");

            migrationBuilder.RenameTable(
                name: "Tbl_LoginDetails",
                newName: "LoginDetails");

            migrationBuilder.RenameTable(
                name: "Tbl_FamilyDetails",
                newName: "FamilyDetails");

            migrationBuilder.RenameTable(
                name: "Tbl_EducationDetails",
                newName: "EducationDetails");

            migrationBuilder.RenameTable(
                name: "Tbl_AddressDetails",
                newName: "AddressDetails");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_ReligiousDetails_PersonId",
                table: "ReligiousDetails",
                newName: "IX_ReligiousDetails_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_LoginDetails_PersonId",
                table: "LoginDetails",
                newName: "IX_LoginDetails_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_FamilyDetails_PersonId",
                table: "FamilyDetails",
                newName: "IX_FamilyDetails_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_EducationDetails_PersonId",
                table: "EducationDetails",
                newName: "IX_EducationDetails_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_AddressDetails_PersonId",
                table: "AddressDetails",
                newName: "IX_AddressDetails_PersonId");

            migrationBuilder.AlterColumn<string>(
                name: "IPaddress",
                table: "Tbl_LoginHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Browsername",
                table: "Tbl_LoginHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReligiousDetails",
                table: "ReligiousDetails",
                column: "ReligiousId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInfo",
                table: "PersonalInfo",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails",
                column: "LoginId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyDetails",
                table: "FamilyDetails",
                column: "FamilyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationDetails",
                table: "EducationDetails",
                column: "EducationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressDetails",
                table: "AddressDetails",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_PersonalInfo_PersonId",
                table: "AddressDetails",
                column: "PersonId",
                principalTable: "PersonalInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationDetails_PersonalInfo_PersonId",
                table: "EducationDetails",
                column: "PersonId",
                principalTable: "PersonalInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyDetails_PersonalInfo_PersonId",
                table: "FamilyDetails",
                column: "PersonId",
                principalTable: "PersonalInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginDetails_PersonalInfo_PersonId",
                table: "LoginDetails",
                column: "PersonId",
                principalTable: "PersonalInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReligiousDetails_PersonalInfo_PersonId",
                table: "ReligiousDetails",
                column: "PersonId",
                principalTable: "PersonalInfo",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_LoginHistory_LoginDetails_LoginId",
                table: "Tbl_LoginHistory",
                column: "LoginId",
                principalTable: "LoginDetails",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
