using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.DeleteSkill
{
    public class DeleteSkillMapper: Mapper<DeleteSkillRequest, DeleteSkillResponse, Skill>
    {
        public override DeleteSkillResponse FromEntity(Skill e)
        {
            return new DeleteSkillResponse()
            {
                Routes = new[] { RoutesConfig.GetRouteDTO("getSkillList") }
            };
        }
    }
}
