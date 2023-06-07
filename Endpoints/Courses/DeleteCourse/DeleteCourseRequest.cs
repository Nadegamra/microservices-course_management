using FastEndpoints;

namespace CourseManagement.Endpoints.Courses.DeleteCourse
{
    public class DeleteCourseRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}
