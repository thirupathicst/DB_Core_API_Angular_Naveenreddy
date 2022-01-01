using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Religoustable_subcaste_removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subcaste",
                table: "Tbl_ReligiousDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subcaste",
                table: "Tbl_ReligiousDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
