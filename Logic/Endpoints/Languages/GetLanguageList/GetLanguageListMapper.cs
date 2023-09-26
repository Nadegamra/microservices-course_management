using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.GetLanguageList
{
    public class GetLanguageListMapper : ResponseMapper<List<GetLanguageListResponse>, List<Language>>
    {
        public override List<GetLanguageListResponse> FromEntity(List<Language> e)
        {
            return e.Select(x => new GetLanguageListResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}