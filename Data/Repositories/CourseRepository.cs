using CourseManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Data.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        public CourseRepository(CourseDbContext dbContext) : base(dbContext)
        {

        }
        public override Course? Get(int id)
        {
            return dbContext.Courses.Where(x => x.Id == id).FirstOrDefault();
        }

        public override IQueryable<Course> GetAll()
        {
            return dbContext.Courses
                    .Include(x => x.Requirements).ThenInclude(x => x.Skill)
                    .Include(x => x.GainedSkills).ThenInclude(x => x.Skill)
                    .Include(x => x.Languages).ThenInclude(x => x.Language)
                    .Include(x => x.Subtitles).ThenInclude(x => x.Language);
        }
    }
}