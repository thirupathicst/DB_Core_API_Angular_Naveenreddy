using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Address_Table_Columns_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Noofbrothersmarrried",
                table: "Tbl_FamilyDetails",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Noofbrothersunmarrried",
                table: "Tbl_FamilyDetails",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Noofsistersmarrried",
                table: "Tbl_FamilyDetails",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Noofsistersunmarrried",
                table: "Tbl_FamilyDetails",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Noofbrothersmarrried",
                table: "Tbl_FamilyDetails");

            migrationBuilder.DropColumn(
                name: "Noofbrothersunmarrried",
                table: "Tbl_FamilyDetails");

            migrationBuilder.DropColumn(
                name: "Noofsistersmarrried",
                table: "Tbl_FamilyDetails");

            migrationBuilder.DropColumn(
                name: "Noofsistersunmarrried",
                table: "Tbl_FamilyDetails");

        }
    }
}
