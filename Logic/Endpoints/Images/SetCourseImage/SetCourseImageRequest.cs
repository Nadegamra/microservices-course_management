using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Images.AddCourseImage
{
    public class SetCourseImageRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set;}
        public required IFormFile Image { get; set; }
    }
}
