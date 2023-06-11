using CourseManagement.Enums;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseSubtitles.CourseSubtitleCreate
{
    public class CourseSubtitleCreateRequest
    {
        [FromClaim("UserId")]
        public required int UserId { get; set; }
        public required int CourseId { get; set; }
        public required Language Language { get; set; }
    }
}
