using FastEndpoints;

namespace CourseManagement.Endpoints.Courses.GetUserCourseList
{
    public class GetUserCourseListRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
    }
}
