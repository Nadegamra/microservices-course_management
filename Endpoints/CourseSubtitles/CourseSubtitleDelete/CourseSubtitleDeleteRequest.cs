using FastEndpoints;

namespace CourseManagement.Endpoints.CourseSubtitles.CourseSubtitleDelete
{
    public class CourseSubtitleDeleteRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Id { get; set; }
    }
}
