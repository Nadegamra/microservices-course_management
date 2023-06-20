using CourseManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Data
{
    public class CourseDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Creator> Creators { get; set; }
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
        }
    }
}
