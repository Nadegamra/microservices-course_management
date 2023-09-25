using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleCreate
{
    public class CourseSubtitleCreateMapper : RequestMapper<CourseSubtitleCreateRequest, CourseSubtitle>
    {
        public override CourseSubtitle ToEntity(CourseSubtitleCreateRequest r)
        {
            return new CourseSubtitle()
            {
                CourseId = r.CourseId,
                LanguageId = r.LanguageId
            };
        }
    }
}
