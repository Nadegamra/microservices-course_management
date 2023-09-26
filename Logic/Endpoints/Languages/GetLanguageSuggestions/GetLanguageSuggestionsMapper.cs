using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.GetLanguageSuggestions
{
    public class GetLanguageSuggestionsMapper : ResponseMapper<List<GetLanguageSuggestionsResponse>, List<Language>>
    {
        public override List<GetLanguageSuggestionsResponse> FromEntity(List<Language> e)
        {
            return e.Select(x => new GetLanguageSuggestionsResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}