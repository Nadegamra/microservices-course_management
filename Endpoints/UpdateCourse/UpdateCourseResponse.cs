namespace CourseManagement.Endpoints.UpdateCourse
{
    public class UpdateCourseResponse
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal CoursePrice { get; set; }
        public required int LengthInDays { get; set; }
        public required bool GrantsCertificate { get; set; }
        public required decimal CertificatePrice { get; set; }
        public required bool IsHidden { get; set; }
    }
}
