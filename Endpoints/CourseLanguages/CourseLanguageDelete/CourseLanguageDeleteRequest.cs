using FastEndpoints;

namespace CourseManagement.Endpoints.CourseLanguages.CourseLanguageDelete
{
    public class CourseLanguageDeleteRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Id { get; set; }
    }
}
