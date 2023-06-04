using FastEndpoints;

namespace CourseManagement.Endpoints.GetUserCourse
{
    public class GetUserCourseRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public required int Id { get; set; }
    }
}
