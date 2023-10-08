using CourseManagement.Data.Models;

namespace CourseManagement.Data
{
    public static class DefaultData
    {
        public static List<Creator> Creators = new List<Creator> {
            new Creator { Id = 2, Email = "creator@example.com", NormalizedEmail = "CREATOR@EXAMPLE.COM", Username = "creator@example.com", NormalizedUsername = "CREATOR@EXAMPLE.COM", Bio = "", Website = "" }
        };

        public static List<Course> Courses = new List<Course> {
            new Course { Id = 1, UserId = 2, Name = "Python Basics", ShortDescription="Introduction to python", Price = 39.99m, LengthInDays = 30, GrantsCertificate = false, CertificatePrice = 0.00m, IsDeleted = false, IsHidden = false, ActivityFormat = Enums.ActivityFormat.Mixed, DetailedDescription="Introduction to basic concepts of python", Difficulty = Enums.Difficulty.Beginner, ScheduleType = Enums.ScheduleType.Flexible, ImageId = "1d2wbDS7WVGR9Qxk1fkUtTVq1qkrAeq6q" },
            new Course { Id = 2, UserId = 2, Name = "Introduction to Docker", ShortDescription="Base knowledge of Docker", Price = 19.99m, LengthInDays = 15, GrantsCertificate = true, CertificatePrice = 0.00m, IsDeleted = false, IsHidden = false, ActivityFormat = Enums.ActivityFormat.Online, DetailedDescription="Everything needed to dockerize a basic web app", Difficulty = Enums.Difficulty.Intermediate, ScheduleType = Enums.ScheduleType.Fixed, ImageId = "" },
        };

        public static List<Skill> Skills = new List<Skill> {
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
            new Skill { Id = 12, Name = "Python", Description = "Programming language" },
            new Skill { Id = 13, Name = "CLI", Description = "Command line interface"}
        };
        public static List<GainedSkill> GainedSkills = new List<GainedSkill> {
            new GainedSkill { Id = 1, CourseId = 1, SkillId = 12},
            new GainedSkill { Id = 2, CourseId = 1, CustomDescription = "Agile methodologies"},
            new GainedSkill { Id = 3, CourseId = 2, SkillId = 5},
            new GainedSkill { Id = 4, CourseId = 2, CustomDescription = "Compilation"}
        };
        public static List<CourseRequirement> CourseRequirements = new List<CourseRequirement> {
            new CourseRequirement { Id = 1, CourseId = 1, SkillId = 3},
            new CourseRequirement { Id = 2, CourseId = 1, CustomDescription = "Problem Solving"},
            new CourseRequirement { Id = 3, CourseId = 2, SkillId = 13}
        };

        public static List<Language> Languages = new List<Language> {
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
        };
        public static List<CourseLanguage> CourseLanguages = new List<CourseLanguage> {
            new CourseLanguage { Id = 1, CourseId = 1, LanguageId = 1, IsPrimary = true},
            new CourseLanguage { Id = 2, CourseId = 1, LanguageId = 2, IsPrimary = false},
            new CourseLanguage { Id = 3, CourseId = 2, LanguageId = 1, IsPrimary = false},
            new CourseLanguage { Id = 4, CourseId = 2, LanguageId = 2, IsPrimary = true},
        };
        public static List<CourseSubtitle> CourseSubtitles = new List<CourseSubtitle> {
            new CourseSubtitle { Id = 1, CourseId = 1, LanguageId = 3},
            new CourseSubtitle { Id = 2, CourseId = 2, LanguageId = 4},
        };
    }
}