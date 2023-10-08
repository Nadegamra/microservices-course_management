namespace CourseManagement.Logic.Endpoints.Courses.GetCourseCount
{
    public class GetCourseCountRequest
    {
        public string Phrase { get; set; } = "";
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 20;
    }
}