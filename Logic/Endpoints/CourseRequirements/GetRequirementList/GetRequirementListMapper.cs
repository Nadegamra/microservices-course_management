using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.GetRequirementList
{
    public class GetRequirementListMapper : ResponseMapper<List<GetRequirementListResponse>, List<CourseRequirement>>
    {
        public override List<GetRequirementListResponse> FromEntity(List<CourseRequirement> e)
        {
            return e.Select(x => new GetRequirementListResponse
            {
                Id = x.Id,
                CourseId = x.CourseId,
                SkillId = x.SkillId,
                Skill = x.Skill,
                CustomDescription = x.CustomDescription
            }).ToList();
        }
    }
}