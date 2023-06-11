using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseLanguages.CourseLanguageCreate
{
    public class CourseLanguageCreateMapper: RequestMapper<CourseLanguageCreateRequest, CourseLanguage>
    {
        public override CourseLanguage ToEntity(CourseLanguageCreateRequest r)
        {
            return new CourseLanguage()
            {
                CourseId = r.CourseId,
                Language = r.Language,
            };
        }
    }
}
