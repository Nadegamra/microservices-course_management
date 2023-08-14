using CourseManagement.Data.Enums;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.UpdateCourse
{
    public class UpdateCourseRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? DetailedDescription { get; set; }
        public int? LengthInDays { get; set; }
        public decimal? Price { get; set; }
        public bool? GrantsCertificate { get; set; }
        public decimal? CertificatePrice { get; set; }
        public ActivityFormat? ActivityFormat { get; set; }
        public ScheduleType? ScheduleType { get; set; }
        public Difficulty? Difficulty { get; set; }
        public bool? IsHidden { get; set; }
    }
}
