using CourseManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Data.Repositories
{
    public class GainedSkillRepository : IRepository<GainedSkill>
    {
        public GainedSkillRepository(CourseDbContext dbContext) : base(dbContext)
        {

        }
        public override GainedSkill? Get(int id)
        {
            return dbContext.GainedSkills.Include(x => x.Skill).Where(x => x.Id == id).FirstOrDefault();
        }

        public override IQueryable<GainedSkill> GetAll()
        {
            return dbContext.GainedSkills.Include(x => x.Skill);
        }
    }
}