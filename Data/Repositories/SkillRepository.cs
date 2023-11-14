using CourseManagement.Data.Models;

namespace CourseManagement.Data.Repositories
{
    public class SkillRepository : IRepository<Skill>
    {
        public SkillRepository(CourseDbContext dbContext) : base(dbContext)
        {

        }
        public override Skill? Get(int id)
        {
            return dbContext.Skills.Where(x => x.Id == id).FirstOrDefault();
        }

        public override IQueryable<Skill> GetAll()
        {
            return dbContext.Skills;
        }
    }
}