﻿// <auto-generated />
using System;
using DBRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBRepository.Migrations
{
    [DbContext(typeof(NaveenReddyDbContext))]
    [Migration("20211116075156_nullablevaluesaddedtotable")]
    partial class nullablevaluesaddedtotable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DBRepository.AddressDetails", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Hno")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AddressId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_AddressDetails");
                });

            modelBuilder.Entity("DBRepository.EducationDetails", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("College")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.HasKey("EducationId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_EducationDetails");
                });

            modelBuilder.Entity("DBRepository.FamilyDetails", b =>
                {
                    b.Property<int>("FamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Brotheroccupation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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
                        .HasMaxLength(50)
                        .HasColumnType("smallint");

                    b.Property<short>("Noofsisters")
                        .HasColumnType("smallint");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Sisteroccupation")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FamilyId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_FamilyDetails");
                });

            modelBuilder.Entity("DBRepository.LoginDetails", b =>
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

            modelBuilder.Entity("DBRepository.LoginHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Browsername")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

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

            modelBuilder.Entity("DBRepository.PersonalInfo", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Complexion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dateofbirth")
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

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Mobileno")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Profileid")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Timeofbirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yourself")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("PersonId");

                    b.ToTable("Tbl_PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.ReligiousDetails", b =>
                {
                    b.Property<int>("ReligiousId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Caste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gothram")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MotherTongue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Raasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Star")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subcaste")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReligiousId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tbl_ReligiousDetails");
                });

            modelBuilder.Entity("DBRepository.AddressDetails", b =>
                {
                    b.HasOne("DBRepository.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.EducationDetails", b =>
                {
                    b.HasOne("DBRepository.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.FamilyDetails", b =>
                {
                    b.HasOne("DBRepository.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.LoginDetails", b =>
                {
                    b.HasOne("DBRepository.PersonalInfo", "PersonalInfo")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DBRepository.LoginHistory", b =>
                {
                    b.HasOne("DBRepository.LoginDetails", "LoginDetails")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoginDetails");
                });

            modelBuilder.Entity("DBRepository.ReligiousDetails", b =>
                {
                    b.HasOne("DBRepository.PersonalInfo", "PersonalInfo")
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
