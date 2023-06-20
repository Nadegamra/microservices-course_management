using CourseManagement.Data.Enums;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageCreate
{
    public class CourseLanguageCreateRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public required Language Language { get; set; }
    }
}
