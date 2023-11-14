using CourseManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Data.Repositories
{
    public class CourseSubtitleRepository : IRepository<CourseSubtitle>
    {
        public CourseSubtitleRepository(CourseDbContext dbContext) : base(dbContext)
        {

        }
        public override CourseSubtitle? Get(int id)
        {
            return dbContext.CourseSubtitles.Include(x => x.Language).Where(x => x.Id == id).FirstOrDefault();
        }

        public override IQueryable<CourseSubtitle> GetAll()
        {
            return dbContext.CourseSubtitles.Include(x => x.Language);
        }
    }
}