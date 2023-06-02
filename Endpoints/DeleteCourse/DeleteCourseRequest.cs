using FastEndpoints;

namespace CourseManagement.Endpoints.DeleteCourse
{
    public class DeleteCourseRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}
