using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Address_Table_Modification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Street",
                table: "Tbl_AddressDetails");

            migrationBuilder.DropColumn(
                name: "Hno",
                table: "Tbl_AddressDetails");

            migrationBuilder.AddColumn<string>(
                name: "Settled",
                table: "Tbl_AddressDetails",
                type: "nvarchar(50)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactAddress",
                table: "Tbl_AddressDetails",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Native",
                table: "Tbl_AddressDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "Tbl_AddressDetails",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Visa",
                table: "Tbl_AddressDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactAddress",
                table: "Tbl_AddressDetails");

            migrationBuilder.DropColumn(
                name: "Native",
                table: "Tbl_AddressDetails");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "Tbl_AddressDetails");

            migrationBuilder.DropColumn(
                name: "Visa",
                table: "Tbl_AddressDetails");

            migrationBuilder.RenameColumn(
                name: "Settled",
                table: "Tbl_AddressDetails",
                newName: "Hno");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Tbl_AddressDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
