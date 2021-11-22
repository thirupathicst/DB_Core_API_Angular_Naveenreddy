using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalInfo",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timeofbirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complexion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emailid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobileno = table.Column<long>(type: "bigint", nullable: false),
                    Yourself = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfo", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "AddressDetails",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDetails", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_AddressDetails_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationDetails",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    College = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Graducation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heightqualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationDetails", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_EducationDetails_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDetails",
                columns: table => new
                {
                    FamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fathername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mothername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brotheroccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Noofbrothers = table.Column<int>(type: "int", nullable: false),
                    Fatheroccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motheroccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Noofsisters = table.Column<int>(type: "int", nullable: false),
                    Sisteroccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDetails", x => x.FamilyId);
                    table.ForeignKey(
                        name: "FK_FamilyDetails_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReligiousDetails",
                columns: table => new
                {
                    ReligiousId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subcaste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Star = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Raasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gothram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherTongue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligiousDetails", x => x.ReligiousId);
                    table.ForeignKey(
                        name: "FK_ReligiousDetails_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_PersonId",
                table: "AddressDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationDetails_PersonId",
                table: "EducationDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetails_PersonId",
                table: "FamilyDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReligiousDetails_PersonId",
                table: "ReligiousDetails",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressDetails");

            migrationBuilder.DropTable(
                name: "EducationDetails");

            migrationBuilder.DropTable(
                name: "FamilyDetails");

            migrationBuilder.DropTable(
                name: "ReligiousDetails");

            migrationBuilder.DropTable(
                name: "PersonalInfo");
        }
    }
}
