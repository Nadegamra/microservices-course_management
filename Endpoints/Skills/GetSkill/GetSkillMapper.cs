using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Skills.GetSkill
{
    public class GetSkillMapper: ResponseMapper<GetSkillResponse, Skill>
    {
        public override GetSkillResponse FromEntity(Skill e)
        {
            return new GetSkillResponse()
            {
                Id = e.Id,
                Description = e.Description,
                Name = e.Name,
            };
        }
    }
}
