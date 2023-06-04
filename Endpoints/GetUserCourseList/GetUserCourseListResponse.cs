namespace CourseManagement.Endpoints.GetUserCourseList
{
    public class GetUserCourseListResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CoursePrice { get; set; }
        public int LengthInDays { get; set; }
        public bool GrantsCertificate { get; set; }
        public decimal CertificatePrice { get; set; }
        public bool IsHidden { get; set; }
    }
}
