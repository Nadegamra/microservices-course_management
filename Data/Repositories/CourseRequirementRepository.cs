using CourseManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Data.Repositories
{
    public class CourseRequirementRepository : IRepository<CourseRequirement>
    {
        public CourseRequirementRepository(CourseDbContext dbContext) : base(dbContext)
        {

        }
        public override CourseRequirement? Get(int id)
        {
            return dbContext.CourseRequirements.Include(x => x.Skill).Where(x => x.Id == id).FirstOrDefault();
        }

        public override IQueryable<CourseRequirement> GetAll()
        {
            return dbContext.CourseRequirements.Include(x => x.Skill);
        }
    }
}