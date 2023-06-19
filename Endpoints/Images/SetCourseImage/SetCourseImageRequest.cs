using FastEndpoints;

namespace CourseManagement.Endpoints.Images.AddCourseImage
{
    public class SetCourseImageRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set;}
        public required IFormFile Image { get; set; }
    }
}
