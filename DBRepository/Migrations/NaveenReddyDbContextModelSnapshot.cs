﻿// <auto-generated />
using System;
using DBRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBRepository.Migrations
{
    [DbContext(typeof(NaveenReddyDbContext))]
    partial class NaveenReddyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DBRepository.Tables.AddressDetails", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Contactaddress")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Createddatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Native")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Permanentaddress")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Settled")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updateddatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Visa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_AddressDetails");
                });

            modelBuilder.Entity("DBRepository.Tables.Audit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("KeyValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Audits");
                });

            modelBuilder.Entity("DBRepository.Tables.EducationDetails", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("College")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Createddatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Graducation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Heightqualification")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("School")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updateddatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("EducationId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_EducationDetails");
                });

            modelBuilder.Entity("DBRepository.Tables.FamilyDetails", b =>
                {
                    b.Property<int>("FamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Brotheroccupation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Createddatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fathername")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Fatheroccupation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mothername")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Motheroccupation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<short>("Noofbrothers")
                        .HasColumnType("smallint");

                    b.Property<short>("Noofbrothersmarrried")
                        .HasColumnType("smallint");

                    b.Property<short>("Noofbrothersunmarrried")
                        .HasColumnType("smallint");

                    b.Property<short>("Noofsisters")
                        .HasColumnType("smallint");

                    b.Property<short>("Noofsistersmarrried")
                        .HasColumnType("smallint");

                    b.Property<short>("Noofsistersunmarrried")
                        .HasColumnType("smallint");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Sisteroccupation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updateddatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("FamilyId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_FamilyDetails");
                });

            modelBuilder.Entity("DBRepository.Tables.Images", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Createddatetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Physicalpath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shortpath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updateddatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("ImageId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_Images");
                });

            modelBuilder.Entity("DBRepository.Tables.LoginDetails", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Emailid")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("LoginId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_LoginDetails");
                });

            modelBuilder.Entity("DBRepository.Tables.LoginHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Browsername")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("IPaddress")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("LoginId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Logindatetime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Logoutdatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LoginId");

                    b.ToTable("Tbl_LoginHistory");
                });

            modelBuilder.Entity("DBRepository.Tables.PartnerInfo", b =>
                {
                    b.Property<int>("PartnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Caste")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Citizen")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Complexion")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Country")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("Createddatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Education")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(2,1)");

                    b.Property<string>("Maritalstatus")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Mothertongue")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Occupation")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Religion")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("Updateddatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("PartnerId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_Partner");
                });

            modelBuilder.Entity("DBRepository.Tables.PersonalInfo", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Complexion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Createddatetime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Dateofbirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Emailid")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Generatedby")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(2,1)");

                    b.Property<string>("Maritalstatus")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long?>("Mobileno")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Placeofbirth")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProfileStage")
                        .HasColumnType("int");

                    b.Property<string>("Profileid")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Timeofbirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updateddatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Yourself")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("PersonId");

                    b.ToTable("Tbl_PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.Tables.ProfessionalDetails", b =>
                {
                    b.Property<int>("ProfessionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Companydetails")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Createddatetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Income")
                        .HasColumnType("int");

                    b.Property<string>("Joblocation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Jobtype")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Professiondetails")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Professiontype")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Updateddatetime")
                        .HasColumnType("datetime2");

                    b.Property<short>("Yearofstart")
                        .HasColumnType("smallint");

                    b.HasKey("ProfessionalId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_ProfessionalDetails");
                });

            modelBuilder.Entity("DBRepository.Tables.ReligiousDetails", b =>
                {
                    b.Property<int>("ReligiousId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Caste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Createddatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gothram")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mothertongue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Raasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Star")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updateddatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("ReligiousId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_ReligiousDetails");
                });

            modelBuilder.Entity("DBRepository.Tables.Story", b =>
                {
                    b.Property<int>("StoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Createddatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Marriagedate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updateddatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("StoryId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_Story");
                });

            modelBuilder.Entity("DBRepository.Tables.AddressDetails", b =>
                {
                    b.HasOne("DBRepository.Tables.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.Tables.EducationDetails", b =>
                {
                    b.HasOne("DBRepository.Tables.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.Tables.FamilyDetails", b =>
                {
                    b.HasOne("DBRepository.Tables.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.Tables.Images", b =>
                {
                    b.HasOne("DBRepository.Tables.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.Tables.LoginDetails", b =>
                {
                    b.HasOne("DBRepository.Tables.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.Tables.LoginHistory", b =>
                {
                    b.HasOne("DBRepository.Tables.LoginDetails", "LoginDetails")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoginDetails");
                });

            modelBuilder.Entity("DBRepository.Tables.PartnerInfo", b =>
                {
                    b.HasOne("DBRepository.Tables.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.Tables.ProfessionalDetails", b =>
                {
                    b.HasOne("DBRepository.Tables.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.Tables.ReligiousDetails", b =>
                {
                    b.HasOne("DBRepository.Tables.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.Tables.Story", b =>
                {
                    b.HasOne("DBRepository.Tables.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
