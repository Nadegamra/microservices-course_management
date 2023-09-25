using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleGetList
{
    public class CourseSubtitleGetListMapper : ResponseMapper<List<CourseSubtitleGetListResponse>, List<CourseSubtitle>>
    {
        public override List<CourseSubtitleGetListResponse> FromEntity(List<CourseSubtitle> e)
        {
            return e.Select(x => new CourseSubtitleGetListResponse
            {
                Id = x.Id,
                CourseId = x.CourseId,
                LanguageId = x.LanguageId,
                Language = x.Language
            }).ToList();
        }
    }
}