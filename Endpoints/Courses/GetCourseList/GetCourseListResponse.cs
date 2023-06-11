using CourseManagement.Enums;
using CourseManagement.Models;

namespace CourseManagement.Endpoints.Courses.GetCourseList
{
    public class GetCourseListResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string ShortDescription { get; set; }
        public required string DetailedDescription { get; set; }
        public int LengthInDays { get; set; }
        public decimal Price { get; set; }
        public bool GrantsCertificate { get; set; }
        public decimal CertificatePrice { get; set; }
        public ActivityFormat ActivityFormat { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public Difficulty Difficulty { get; set; }
        public ICollection<CourseRequirement>? Requirements { get; set; }
        public ICollection<GainedSkill>? GainedSkills { get; set; }
        public ICollection<CourseLanguage>? Languages { get; set; }
        public ICollection<CourseSubtitle>? Subtitles { get; set; }
    }
}
