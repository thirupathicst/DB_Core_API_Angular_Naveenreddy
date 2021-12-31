using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class professionaldetails_table_columnsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Professiondetails",
                table: "Tbl_ProfessionalDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Professiontype",
                table: "Tbl_ProfessionalDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Tbl_PersonalInfo",
                type: "decimal(2,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Professiondetails",
                table: "Tbl_ProfessionalDetails");

            migrationBuilder.DropColumn(
                name: "Professiontype",
                table: "Tbl_ProfessionalDetails");

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Tbl_PersonalInfo",
                type: "decimal(2,1)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldNullable: true);
        }
    }
}
