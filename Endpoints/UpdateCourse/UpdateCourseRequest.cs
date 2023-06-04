using FastEndpoints;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Endpoints.UpdateCourse
{
    public class UpdateCourseRequest
    {
        public int Id { get; set; }
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal CoursePrice { get; set; }
        public required int LengthInDays { get; set; }
        public required bool GrantsCertificate { get; set; }
        public required decimal CertificatePrice { get; set; }
        public required bool IsHidden { get; set; }
    }
}
