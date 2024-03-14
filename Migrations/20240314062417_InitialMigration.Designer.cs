﻿// <auto-generated />
using System;
using CureWell.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CureWell.Migrations
{
    [DbContext(typeof(CureWellDbContext))]
    [Migration("20240314062417_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CureWell.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .HasColumnType("longtext");

                    b.HasKey("DoctorID");

                    b.ToTable("Doctors");

                    b
                        .HasAnnotation("AutoIncrement", true)
                        .HasAnnotation("StartValue", 1000);
                });

            modelBuilder.Entity("CureWell.Models.DoctorSpecification", b =>
                {
                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("SpecializationCode")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<int>("SpecializationCode1")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("SpecializationDate")
                        .HasColumnType("date");

                    b.HasKey("DoctorID", "SpecializationCode");

                    b.HasIndex("SpecializationCode1");

                    b.ToTable("DoctorSpecifications");
                });

            modelBuilder.Entity("CureWell.Models.Specialization", b =>
                {
                    b.Property<int>("SpecializationCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SpecializationName")
                        .HasColumnType("longtext");

                    b.HasKey("SpecializationCode");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("CureWell.Models.Surgery", b =>
                {
                    b.Property<int>("SurgeryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SurgeryCategory")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("SurgeryDate")
                        .HasColumnType("date");

                    b.HasKey("SurgeryID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Surgeries");
                });

            modelBuilder.Entity("CureWell.Models.DoctorSpecification", b =>
                {
                    b.HasOne("CureWell.Models.Doctor", "Doctor")
                        .WithMany("DoctorSpecifications")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CureWell.Models.Specialization", "Specialization")
                        .WithMany("DoctorSpecification")
                        .HasForeignKey("SpecializationCode1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("CureWell.Models.Surgery", b =>
                {
                    b.HasOne("CureWell.Models.Doctor", "Doctor")
                        .WithMany("Surgery")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("CureWell.Models.Doctor", b =>
                {
                    b.Navigation("DoctorSpecifications");

                    b.Navigation("Surgery");
                });

            modelBuilder.Entity("CureWell.Models.Specialization", b =>
                {
                    b.Navigation("DoctorSpecification");
                });
#pragma warning restore 612, 618
        }
    }
}