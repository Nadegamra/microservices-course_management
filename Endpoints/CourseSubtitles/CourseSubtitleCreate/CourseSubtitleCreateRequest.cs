using CourseManagement.Enums;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseSubtitles.CourseSubtitleCreate
{
    public class CourseSubtitleCreateRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public required Language Language { get; set; }
    }
}
