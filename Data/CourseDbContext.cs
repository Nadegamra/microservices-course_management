using CourseManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Data
{
    public class CourseDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<CourseLanguage> CourseLanguages { get; set; }
        public DbSet<CourseSubtitle> CourseSubtitles { get; set; }
        public DbSet<CourseRequirement> CourseRequirements { get; set; }
        public DbSet<GainedSkill> GainedSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public CourseDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Creator>().HasData(new Creator { Id = 2, Email = "creator@example.com", NormalizedEmail = "CREATOR@EXAMPLE.COM", Username = "creator@example.com", NormalizedUsername = "CREATOR@EXAMPLE.COM", Bio = "", Website = "" });

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#", Description = "Programming language" },
                new Skill { Id = 2, Name = "C", Description = "Programming language" },
                new Skill { Id = 3, Name = "C++", Description = "Programming language" },
                new Skill { Id = 4, Name = ".NET", Description = "C# Framework" },
                new Skill { Id = 5, Name = "Docker", Description = "Containerization technology" },
                new Skill { Id = 6, Name = "Redux", Description = "Design pattern" },
                new Skill { Id = 7, Name = "React.js", Description = "Javascript library" },
                new Skill { Id = 8, Name = "Javascript", Description = "Programming language" },
                new Skill { Id = 9, Name = "Typescript", Description = "Programming language" },
                new Skill { Id = 10, Name = "MySQL", Description = "Relational database" },
                new Skill { Id = 11, Name = "Redis", Description = "Key-value noSQL database" },
                new Skill { Id = 12, Name = "Python", Description = "Programming language" }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Name = "Lithuanian" },
                new Language { Id = 2, Name = "English" },
                new Language { Id = 3, Name = "Latvian" },
                new Language { Id = 4, Name = "Estonian" },
                new Language { Id = 5, Name = "Polish" },
                new Language { Id = 6, Name = "Ukrainian" },
                new Language { Id = 7, Name = "Russian" },
                new Language { Id = 8, Name = "German" },
                new Language { Id = 9, Name = "Spanish" },
                new Language { Id = 10, Name = "Portugalish" },
                new Language { Id = 11, Name = "Italian" },
                new Language { Id = 12, Name = "Norwegian" },
                new Language { Id = 13, Name = "Swedish" }
            );
        }
    }
}
