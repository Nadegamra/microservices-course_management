using FastEndpoints;

namespace CourseManagement.Endpoints.GetUserCourseList
{
    public class GetUserCourseListRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
    }
}
