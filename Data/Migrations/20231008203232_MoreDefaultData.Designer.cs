﻿// <auto-generated />
using System;
using CourseManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseManagement.Migrations
{
    [DbContext(typeof(CourseDbContext))]
    [Migration("20231008203232_MoreDefaultData")]
    partial class MoreDefaultData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CourseManagement.Data.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActivityFormat")
                        .HasColumnType("int");

                    b.Property<decimal>("CertificatePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("DetailedDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<bool>("GrantsCertificate")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LengthInDays")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ScheduleType")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActivityFormat = 2,
                            CertificatePrice = 0.00m,
                            DetailedDescription = "Introduction to basic concepts of python",
                            Difficulty = 0,
                            GrantsCertificate = false,
                            ImageId = "1d2wbDS7WVGR9Qxk1fkUtTVq1qkrAeq6q",
                            IsDeleted = false,
                            IsHidden = false,
                            LengthInDays = 30,
                            Name = "Python Basics",
                            Price = 39.99m,
                            ScheduleType = 1,
                            ShortDescription = "Introduction to python",
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            ActivityFormat = 0,
                            CertificatePrice = 0.00m,
                            DetailedDescription = "Everything needed to dockerize a basic web app",
                            Difficulty = 1,
                            GrantsCertificate = true,
                            ImageId = "",
                            IsDeleted = false,
                            IsHidden = false,
                            LengthInDays = 15,
                            Name = "Introduction to Docker",
                            Price = 19.99m,
                            ScheduleType = 0,
                            ShortDescription = "Base knowledge of Docker",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("CourseManagement.Data.Models.CourseLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("LanguageId");

                    b.ToTable("CourseLanguages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            IsPrimary = true,
                            LanguageId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            IsPrimary = false,
                            LanguageId = 2
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            IsPrimary = false,
                            LanguageId = 1
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            IsPrimary = true,
                            LanguageId = 2
                        });
                });

            modelBuilder.Entity("CourseManagement.Data.Models.CourseRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("CustomDescription")
                        .HasColumnType("longtext");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("SkillId");

                    b.ToTable("CourseRequirements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            SkillId = 3
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            CustomDescription = "Problem Solving"
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            SkillId = 13
                        });
                });

            modelBuilder.Entity("CourseManagement.Data.Models.CourseSubtitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("LanguageId");

                    b.ToTable("CourseSubtitles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            LanguageId = 3
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            LanguageId = 4
                        });
                });

            modelBuilder.Entity("CourseManagement.Data.Models.Creator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUsername")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Creators");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Bio = "",
                            Email = "creator@example.com",
                            NormalizedEmail = "CREATOR@EXAMPLE.COM",
                            NormalizedUsername = "CREATOR@EXAMPLE.COM",
                            Username = "creator@example.com",
                            Website = ""
                        });
                });

            modelBuilder.Entity("CourseManagement.Data.Models.GainedSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("CustomDescription")
                        .HasColumnType("longtext");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("SkillId");

                    b.ToTable("GainedSkills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            SkillId = 12
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            CustomDescription = "Agile methodologies"
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            SkillId = 5
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            CustomDescription = "Compilation"
                        });
                });

            modelBuilder.Entity("CourseManagement.Data.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lithuanian"
                        },
                        new
                        {
                            Id = 2,
                            Name = "English"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Latvian"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Estonian"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Polish"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ukrainian"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Russian"
                        },
                        new
                        {
                            Id = 8,
                            Name = "German"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Spanish"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Portugalish"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Italian"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Norwegian"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Swedish"
                        });
                });

            modelBuilder.Entity("CourseManagement.Data.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Programming language",
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Programming language",
                            Name = "C"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Programming language",
                            Name = "C++"
                        },
                        new
                        {
                            Id = 4,
                            Description = "C# Framework",
                            Name = ".NET"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Containerization technology",
                            Name = "Docker"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Design pattern",
                            Name = "Redux"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Javascript library",
                            Name = "React.js"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Programming language",
                            Name = "Javascript"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Programming language",
                            Name = "Typescript"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Relational database",
                            Name = "MySQL"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Key-value noSQL database",
                            Name = "Redis"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Programming language",
                            Name = "Python"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Command line interface",
                            Name = "CLI"
                        });
                });

            modelBuilder.Entity("CourseManagement.Data.Models.CourseLanguage", b =>
                {
                    b.HasOne("CourseManagement.Data.Models.Course", null)
                        .WithMany("Languages")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseManagement.Data.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("CourseManagement.Data.Models.CourseRequirement", b =>
                {
                    b.HasOne("CourseManagement.Data.Models.Course", null)
                        .WithMany("Requirements")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseManagement.Data.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("CourseManagement.Data.Models.CourseSubtitle", b =>
                {
                    b.HasOne("CourseManagement.Data.Models.Course", null)
                        .WithMany("Subtitles")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseManagement.Data.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("CourseManagement.Data.Models.GainedSkill", b =>
                {
                    b.HasOne("CourseManagement.Data.Models.Course", null)
                        .WithMany("GainedSkills")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseManagement.Data.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("CourseManagement.Data.Models.Course", b =>
                {
                    b.Navigation("GainedSkills");

                    b.Navigation("Languages");

                    b.Navigation("Requirements");

                    b.Navigation("Subtitles");
                });
#pragma warning restore 612, 618
        }
    }
}
