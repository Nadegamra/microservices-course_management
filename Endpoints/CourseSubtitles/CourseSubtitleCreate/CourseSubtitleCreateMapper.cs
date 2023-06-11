using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseSubtitles.CourseSubtitleCreate
{
    public class CourseSubtitleCreateMapper: RequestMapper<CourseSubtitleCreateRequest, CourseSubtitle>
    {
        public override CourseSubtitle ToEntity(CourseSubtitleCreateRequest r)
        {
            return new CourseSubtitle()
            {
                CourseId = r.CourseId,
                Language = r.Language,
            };
        }
    }
}
