using CourseManagement.Enums;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseLanguages.CourseLanguageCreate
{
    public class CourseLanguageCreateRequest
    {
        [FromClaim("UserId")]
        public required int UserId { get; set; }
        public required int CourseId { get; set; }
        public required Language Language { get; set; }
    }
}
