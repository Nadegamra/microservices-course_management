using CourseManagement.Data.Models;

namespace CourseManagement.Data.Repositories
{
    public class CourseLanguageRepository : IRepository<CourseLanguage>
    {
        public CourseLanguageRepository(CourseDbContext dbContext) : base(dbContext)
        {

        }
        public override CourseLanguage? Get(int id)
        {
            return dbContext.CourseLanguages.Where(x => x.Id == id).FirstOrDefault();
        }

        public override IQueryable<CourseLanguage> GetAll()
        {
            return dbContext.CourseLanguages;
        }
    }
}