using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.GetUserCourseCount
{
    public class GetUserCourseCountRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public string Phrase { get; set; } = "";
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 20;
    }
}