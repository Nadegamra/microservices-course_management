namespace CourseManagement.Logic.Endpoints.Courses.GetCourseList
{
    public class GetCourseListResponse
    {
        public GetCourseListItem[] Items { get; set; }
        public RouteDTO[] Routes { get; set; }
    }
}
