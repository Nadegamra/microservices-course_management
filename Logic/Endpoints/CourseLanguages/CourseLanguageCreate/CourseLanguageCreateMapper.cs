using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageCreate
{
    public class CourseLanguageCreateMapper : RequestMapper<CourseLanguageCreateRequest, CourseLanguage>
    {
        public override CourseLanguage ToEntity(CourseLanguageCreateRequest r)
        {
            return new CourseLanguage()
            {
                CourseId = r.CourseId,
                LanguageId = r.LanguageId
            };
        }
    }
}
