using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class PartnerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Partner",
                columns: table => new
                {
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Maritalstatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Complexion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mothertongue = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Caste = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Education = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Citizen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Createddatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updateddatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Partner", x => x.PartnerId);
                    table.ForeignKey(
                        name: "FK_Tbl_Partner_Tbl_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Partner_PersonId",
                table: "Tbl_Partner",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Partner");
        }
    }
}
