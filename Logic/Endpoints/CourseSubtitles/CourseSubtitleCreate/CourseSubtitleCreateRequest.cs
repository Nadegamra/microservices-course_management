using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleCreate
{
    public class CourseSubtitleCreateRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int LanguageId { get; set; }
    }
}
