using CourseManagement.Data.Enums;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.CreateCourse
{
    public class CreateCourseRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string ShortDescription { get; set; }
        public required string DetailedDescription { get; set; }
        public required int LengthInDays { get; set; }
        public required decimal Price { get; set; }
        public required bool GrantsCertificate { get; set; }
        public required decimal CertificatePrice { get; set; }
        public required ActivityFormat ActivityFormat { get; set; }
        public required ScheduleType ScheduleType { get; set; }
        public required Difficulty Difficulty { get; set; }
    }
}
