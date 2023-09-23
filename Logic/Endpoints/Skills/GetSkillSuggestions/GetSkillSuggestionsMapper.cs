using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkillSuggestions
{
    public class GetSkillSuggestionsMapper : ResponseMapper<List<GetSkillSuggestionsResponse>, List<Skill>>
    {
        public override List<GetSkillSuggestionsResponse> FromEntity(List<Skill> e)
        {
            return e.Select(x => new GetSkillSuggestionsResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}