﻿// <auto-generated />
using System;
using HIT339_Assignment1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HIT339_Assignment1.Migrations
{
    [DbContext(typeof(HIT339_Assignment1Context))]
    [Migration("20210929050313_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HIT339_Assignment1.Models.Duration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("LessonDuration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Duration");
                });

            modelBuilder.Entity("HIT339_Assignment1.Models.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InstrumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instrument");
                });

            modelBuilder.Entity("HIT339_Assignment1.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("durationID")
                        .HasColumnType("int");

                    b.Property<int>("instrumentID")
                        .HasColumnType("int");

                    b.Property<bool>("isPaid")
                        .HasColumnType("bit");

                    b.Property<int?>("letterId")
                        .HasColumnType("int");

                    b.Property<int>("studentID")
                        .HasColumnType("int");

                    b.Property<int>("tutorID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("durationID");

                    b.HasIndex("instrumentID");

                    b.HasIndex("letterId");

                    b.HasIndex("studentID");

                    b.HasIndex("tutorID");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("HIT339_Assignment1.Models.Letter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("accountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("accountNumber")
                        .HasColumnType("int");

                    b.Property<string>("bankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("bsb")
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("currentTerm")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<int>("currentYear")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("termStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Letter");
                });

            modelBuilder.Entity("HIT339_Assignment1.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GuardianName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("HIT339_Assignment1.Models.Tutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tutor");
                });

            modelBuilder.Entity("HIT339_Assignment1.Models.Lesson", b =>
                {
                    b.HasOne("HIT339_Assignment1.Models.Duration", "duration")
                        .WithMany()
                        .HasForeignKey("durationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HIT339_Assignment1.Models.Instrument", "instrument")
                        .WithMany()
                        .HasForeignKey("instrumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HIT339_Assignment1.Models.Letter", "letter")
                        .WithMany("lessons")
                        .HasForeignKey("letterId");

                    b.HasOne("HIT339_Assignment1.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HIT339_Assignment1.Models.Tutor", "tutor")
                        .WithMany()
                        .HasForeignKey("tutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("duration");

                    b.Navigation("instrument");

                    b.Navigation("letter");

                    b.Navigation("student");

                    b.Navigation("tutor");
                });

            modelBuilder.Entity("HIT339_Assignment1.Models.Letter", b =>
                {
                    b.HasOne("HIT339_Assignment1.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");
                });

            modelBuilder.Entity("HIT339_Assignment1.Models.Letter", b =>
                {
                    b.Navigation("lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
