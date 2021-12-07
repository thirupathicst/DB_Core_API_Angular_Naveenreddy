using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Image_Story_DefaultVaues_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhysicalPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Story",
                columns: table => new
                {
                    StoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MarriageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Story", x => x.StoryId);
                    table.ForeignKey(
                        name: "FK_Tbl_Story_Tbl_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Story_PersonId",
                table: "Tbl_Story",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Images");

            migrationBuilder.DropTable(
                name: "Tbl_Story");
        }
    }
}
