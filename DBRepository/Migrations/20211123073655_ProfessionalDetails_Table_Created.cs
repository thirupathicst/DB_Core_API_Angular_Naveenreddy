using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class ProfessionalDetails_Table_Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fatheroccupation",
                table: "Tbl_FamilyDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tbl_ProfessionalDetails",
                columns: table => new
                {
                    ProfessionalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yearofstart = table.Column<short>(type: "smallint", nullable: false),
                    Joblocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Income = table.Column<int>(type: "int", nullable: false),
                    Companydetails = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Jobtype = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProfessionalDetails", x => x.ProfessionalId);
                    table.ForeignKey(
                        name: "FK_Tbl_ProfessionalDetails_Tbl_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProfessionalDetails_PersonId",
                table: "Tbl_ProfessionalDetails",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ProfessionalDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Fatheroccupation",
                table: "Tbl_FamilyDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
