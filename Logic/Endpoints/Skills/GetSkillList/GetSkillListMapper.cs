using CourseManagement.Data.Models;
using FastEndpoints;
using Infrastructure.Routes;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkillList
{
    public class GetSkillListMapper : ResponseMapper<GetSkillListResponse, List<Skill>>
    {
        public override GetSkillListResponse FromEntity(List<Skill> e)
        {
            return new GetSkillListResponse()
            {
                Items = e.Select(x => new GetSkillListItem
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                }).ToArray(),
                Routes = new[] { RoutesConfig.GetRouteDTO("getSkill"),
                                 RoutesConfig.GetRouteDTO("createSkill"),
                                 RoutesConfig.GetRouteDTO("deleteSkill"),
                                 RoutesConfig.GetRouteDTO("updateSkill") }
            };
        }
    }
}
