using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Invitation_table_created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Invitation",
                columns: table => new
                {
                    InvitationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acceptedstatus = table.Column<short>(type: "smallint", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sentto = table.Column<int>(type: "int", nullable: false),
                    Invitationdatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Invitation", x => x.InvitationId);
                    table.ForeignKey(
                        name: "FK_Tbl_Invitation_Tbl_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Invitation_PersonId",
                table: "Tbl_Invitation",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Invitation");
        }
    }
}
