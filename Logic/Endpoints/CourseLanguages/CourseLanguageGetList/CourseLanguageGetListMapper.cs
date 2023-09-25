using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageGetList
{
    public class CourseLanguageGetListMapper : ResponseMapper<List<CourseLanguageGetListResponse>, List<CourseLanguage>>
    {
        public override List<CourseLanguageGetListResponse> FromEntity(List<CourseLanguage> e)
        {
            return e.Select(x => new CourseLanguageGetListResponse
            {
                Id = x.Id,
                CourseId = x.CourseId,
                LanguageId = x.LanguageId,
                Language = x.Language
            }).ToList();
        }
    }
}