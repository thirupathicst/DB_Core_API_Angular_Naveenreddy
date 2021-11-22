using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class PersonalInfo_Maritalstatus_Placeofbirth_columns_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Maritalstatus",
                table: "Tbl_PersonalInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placeofbirth",
                table: "Tbl_PersonalInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maritalstatus",
                table: "Tbl_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Placeofbirth",
                table: "Tbl_PersonalInfo");
        }
    }
}
