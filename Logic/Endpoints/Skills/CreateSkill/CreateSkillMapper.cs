using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.CreateSkill
{
    public class CreateSkillMapper : Mapper<CreateSkillRequest, CreateSkillResponse, Skill>
    {
        public override CreateSkillResponse FromEntity(Skill e)
        {
            return new CreateSkillResponse()
            {
                Id = e.Id,
                Description = e.Description,
                Name = e.Name,
            };
        }

        public override Skill ToEntity(CreateSkillRequest r)
        {
            return new Skill()
            {
                Name = r.Name,
                Description = r.Description,
            };
        }
    }
}
