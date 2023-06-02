using CourseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement
{
    public class CourseDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public CourseDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
