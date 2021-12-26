using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_PersonalInfo",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Timeofbirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complexion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emailid = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobileno = table.Column<long>(type: "bigint", nullable: true),
                    Yourself = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Generatedby = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Maritalstatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Placeofbirth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Profileid = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ProfileStage = table.Column<int>(type: "int", nullable: false),
                    Createddatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updateddatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PersonalInfo", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_AddressDetails",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permanentaddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Contactaddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Visa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settled = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Native = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Createddatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updateddatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AddressDetails", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Tbl_AddressDetails_Tbl_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EducationDetails",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    College = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Graducation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Heightqualification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Createddatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updateddatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EducationDetails", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Tbl_EducationDetails_Tbl_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_FamilyDetails",
                columns: table => new
                {
                    FamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fathername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mothername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Brotheroccupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Noofbrothers = table.Column<short>(type: "smallint", nullable: false),
                    Noofbrothersunmarrried = table.Column<short>(type: "smallint", nullable: false),
                    Noofbrothersmarrried = table.Column<short>(type: "smallint", nullable: false),
                    Fatheroccupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Motheroccupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Noofsisters = table.Column<short>(type: "smallint", nullable: false),
                    Noofsistersmarrried = table.Column<short>(type: "smallint", nullable: false),
                    Noofsistersunmarrried = table.Column<short>(type: "smallint", nullable: false),
                    Sisteroccupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Createddatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updateddatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_FamilyDetails", x => x.FamilyId);
                    table.ForeignKey(
                        name: "FK_Tbl_FamilyDetails_Tbl_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Physicalpath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shortpath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Createddatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updateddatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Tbl_Images_Tbl_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_LoginDetails",
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
                    table.PrimaryKey("PK_Tbl_LoginDetails", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_Tbl_LoginDetails_Tbl_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Createddatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updateddatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Tbl_ReligiousDetails",
                columns: table => new
                {
                    ReligiousId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subcaste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Star = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Raasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gothram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mothertongue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Createddatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updateddatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ReligiousDetails", x => x.ReligiousId);
                    table.ForeignKey(
                        name: "FK_Tbl_ReligiousDetails_Tbl_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_PersonalInfo",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Story",
                columns: table => new
                {
                    StoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Marriagedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Createddatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updateddatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Tbl_LoginHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logindatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPaddress = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Browsername = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Logoutdatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoginId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_LoginHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_LoginHistory_Tbl_LoginDetails_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Tbl_LoginDetails",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AddressDetails_PersonId",
                table: "Tbl_AddressDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EducationDetails_PersonId",
                table: "Tbl_EducationDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_FamilyDetails_PersonId",
                table: "Tbl_FamilyDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Images_PersonId",
                table: "Tbl_Images",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_LoginDetails_PersonId",
                table: "Tbl_LoginDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_LoginHistory_LoginId",
                table: "Tbl_LoginHistory",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProfessionalDetails_PersonId",
                table: "Tbl_ProfessionalDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ReligiousDetails_PersonId",
                table: "Tbl_ReligiousDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Story_PersonId",
                table: "Tbl_Story",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_AddressDetails");

            migrationBuilder.DropTable(
                name: "Tbl_EducationDetails");

            migrationBuilder.DropTable(
                name: "Tbl_FamilyDetails");

            migrationBuilder.DropTable(
                name: "Tbl_Images");

            migrationBuilder.DropTable(
                name: "Tbl_LoginHistory");

            migrationBuilder.DropTable(
                name: "Tbl_ProfessionalDetails");

            migrationBuilder.DropTable(
                name: "Tbl_ReligiousDetails");

            migrationBuilder.DropTable(
                name: "Tbl_Story");

            migrationBuilder.DropTable(
                name: "Tbl_LoginDetails");

            migrationBuilder.DropTable(
                name: "Tbl_PersonalInfo");
        }
    }
}
