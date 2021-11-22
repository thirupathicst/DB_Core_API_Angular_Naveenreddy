using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Tablesname_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginDetails",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emailid = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDetails", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_LoginDetails_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_LoginHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logindatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Browsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logoutdatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoginId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_LoginHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_LoginHistory_LoginDetails_LoginId",
                        column: x => x.LoginId,
                        principalTable: "LoginDetails",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginDetails_PersonId",
                table: "LoginDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_LoginHistory_LoginId",
                table: "Tbl_LoginHistory",
                column: "LoginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_LoginHistory");

            migrationBuilder.DropTable(
                name: "LoginDetails");
        }
    }
}
