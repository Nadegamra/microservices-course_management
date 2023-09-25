
using CourseManagement.Data.Models;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleGetList
{
    public class CourseSubtitleGetListResponse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}