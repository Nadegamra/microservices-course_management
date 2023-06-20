using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.GetUserCourseList
{
    public class GetUserCourseListRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
    }
}
