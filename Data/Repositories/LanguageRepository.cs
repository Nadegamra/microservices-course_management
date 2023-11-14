using CourseManagement.Data.Models;

namespace CourseManagement.Data.Repositories
{
    public class LanguageRepository : IRepository<Language>
    {
        public LanguageRepository(CourseDbContext dbContext) : base(dbContext)
        {

        }
        public override Language? Get(int id)
        {
            return dbContext.Languages.Where(x => x.Id == id).FirstOrDefault();
        }

        public override IQueryable<Language> GetAll()
        {
            return dbContext.Languages;
        }
    }
}