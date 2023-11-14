using CourseManagement.Data.Models;

namespace CourseManagement.Data.Repositories
{
    public class CreatorRepository : IRepository<Creator>
    {
        public CreatorRepository(CourseDbContext dbContext) : base(dbContext)
        {

        }
        public override Creator? Get(int id)
        {
            return dbContext.Creators.Where(x => x.Id == id).FirstOrDefault();
        }

        public override IQueryable<Creator> GetAll()
        {
            return dbContext.Creators;
        }
    }
}