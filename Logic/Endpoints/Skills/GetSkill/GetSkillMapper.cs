using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkill
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
                Routes = new[] { RoutesConfig.GetRouteDTO("getSkillList")}
            };
        }
    }
}
