﻿// <auto-generated />
using CourseManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseManagement.Migrations
{
    [DbContext(typeof(CourseDbContext))]
    partial class CourseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CourseManagement.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("CertificatePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("CoursePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("GrantsCertificate")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LengthInDays")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
